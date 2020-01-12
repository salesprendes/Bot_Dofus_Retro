using Bot_Dofus_Retro.Otros.Game.Personaje.Configuracion;
using Bot_Dofus_Retro.Otros.Game.Personaje.Hechizos;
using Bot_Dofus_Retro.Otros.Game.Personaje.Inventario;
using Bot_Dofus_Retro.Otros.Game.Personaje.Inventario.Enums;
using Bot_Dofus_Retro.Otros.Mapas;
using Bot_Dofus_Retro.Otros.Mapas.Movimiento.Peleas;
using Bot_Dofus_Retro.Otros.Peleas.Enums;
using Bot_Dofus_Retro.Otros.Peleas.Peleadores;
using Bot_Dofus_Retro.Utilidades.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Peleas
{
    public class ManejadorHechizos : IDisposable
    {
        private Cuenta cuenta;
        private Mapa mapa;
        private Pelea pelea;
        private bool disposed;

        /** AOE **/
        private short celda_objetivo;
        private int hechizo_para_lanzar;
        private byte enemigos_tocados;

        public ManejadorHechizos(Cuenta _cuenta)
        {
            cuenta = _cuenta;
            mapa = cuenta.juego.mapa;
            pelea = cuenta.juego.pelea;
            hechizo_para_lanzar = -1;
            celda_objetivo = -1;
        }

        public async Task<ResultadoLanzandoHechizo> manejador_Hechizos(PeleaHechizos hechizo)
        {
            if (hechizo_para_lanzar != -1 && hechizo_para_lanzar == hechizo.id)
            {
                if (GlobalConf.mostrar_mensajes_debug)
                    cuenta.logger.log_informacion("DEBUG", $"Se ha lanzado el hechizo {hechizo.nombre} atacando a {enemigos_tocados} enemigos en la celda {celda_objetivo}");

                await pelea.get_Lanzar_Hechizo(hechizo.id, celda_objetivo);

                hechizo_para_lanzar = -1;
                celda_objetivo = -1;
                enemigos_tocados = 0;

                return ResultadoLanzandoHechizo.LANZADO;
            }

            if (!get_Condiciones_Principales(hechizo))
                return ResultadoLanzandoHechizo.NO_LANZADO;

            if (hechizo.focus == HechizoFocus.CELDA_VACIA)
                return await lanzar_Hechizo_Celda_Vacia(hechizo);

            if (hechizo.metodo_lanzamiento == MetodoLanzamiento.AMBOS && !hechizo.es_aoe)
                return await get_Lanzar_Hechizo_Simple(hechizo);

            if (hechizo.metodo_lanzamiento == MetodoLanzamiento.ALEJADO && !hechizo.es_aoe && !pelea.esta_Cuerpo_A_Cuerpo_Con_Enemigo())
                return await get_Lanzar_Hechizo_Simple(hechizo);

            if (hechizo.metodo_lanzamiento == MetodoLanzamiento.CAC && !hechizo.es_aoe && pelea.esta_Cuerpo_A_Cuerpo_Con_Enemigo())
                return await get_Lanzar_Hechizo_Simple(hechizo);

            if (hechizo.metodo_lanzamiento == MetodoLanzamiento.CAC && !hechizo.es_aoe && !pelea.esta_Cuerpo_A_Cuerpo_Con_Enemigo())
                return await get_Mover_Lanzar_hechizo_Simple(hechizo, get_Objetivo_Mas_Cercano(hechizo));

            if(hechizo.es_aoe)
            {
                if(pelea.total_enemigos_vivos > 1)
                    return await lanzar_Hechizo_AOE(hechizo);
                else
                    return await get_Lanzar_Hechizo_Simple(hechizo);
            }

            return ResultadoLanzandoHechizo.NO_LANZADO;
        }

        private async Task<ResultadoLanzandoHechizo> get_Lanzar_Hechizo_Simple(PeleaHechizos hechizo)
        {
            if (pelea.get_Puede_Lanzar_hechizo(hechizo.id) != FallosLanzandoHechizo.NINGUNO)
                return ResultadoLanzandoHechizo.NO_LANZADO;

            Luchadores enemigo = get_Objetivo_Mas_Cercano(hechizo);
            if (enemigo != null)
            {
                FallosLanzandoHechizo resultado = pelea.get_Puede_Lanzar_hechizo(hechizo.id, pelea.jugador_luchador.celda, enemigo.celda, mapa);

                if (resultado == FallosLanzandoHechizo.NINGUNO)
                {
                    await pelea.get_Lanzar_Hechizo(hechizo.id, enemigo.celda.id);
                    return ResultadoLanzandoHechizo.LANZADO;
                }

                if (resultado == FallosLanzandoHechizo.NO_ESTA_EN_RANGO)
                    return await get_Mover_Lanzar_hechizo_Simple(hechizo, enemigo);
            }
            else if (hechizo.focus == HechizoFocus.CELDA_VACIA)
                return await lanzar_Hechizo_Celda_Vacia(hechizo);

            return ResultadoLanzandoHechizo.NO_LANZADO;
        }

        private async Task<ResultadoLanzandoHechizo> get_Mover_Lanzar_hechizo_Simple(PeleaHechizos hechizo_pelea, Luchadores enemigo)
        {
            KeyValuePair<short, MovimientoNodo>? nodo = null;
            int pm_utilizados = 99;

            foreach (KeyValuePair<short, MovimientoNodo> movimiento in PeleasPathfinder.get_Celdas_Accesibles(pelea, mapa, pelea.jugador_luchador.celda))
            {
                if (!movimiento.Value.alcanzable)
                    continue;

                if (hechizo_pelea.metodo_lanzamiento == MetodoLanzamiento.CAC && !pelea.esta_Cuerpo_A_Cuerpo_Con_Enemigo(mapa.get_Celda_Id(movimiento.Key)))
                    continue;

                if (pelea.get_Puede_Lanzar_hechizo(hechizo_pelea.id, mapa.get_Celda_Id(movimiento.Key), enemigo.celda, mapa) != FallosLanzandoHechizo.NINGUNO)
                    continue;

                if (movimiento.Value.camino.celdas_accesibles.Count <= pm_utilizados)
                {
                    nodo = movimiento;
                    pm_utilizados = movimiento.Value.camino.celdas_accesibles.Count;
                }
            }

            if (nodo != null)
            {
                await cuenta.juego.manejador.movimientos.get_Mover_Celda_Pelea(nodo);
                return ResultadoLanzandoHechizo.MOVIDO;
            }

            return ResultadoLanzandoHechizo.NO_LANZADO;
        }

        private async Task<ResultadoLanzandoHechizo> lanzar_Hechizo_Celda_Vacia(PeleaHechizos hechizo_pelea)
        {
            if (pelea.get_Puede_Lanzar_hechizo(hechizo_pelea.id) != FallosLanzandoHechizo.NINGUNO)
                return ResultadoLanzandoHechizo.NO_LANZADO;

            if (hechizo_pelea.focus == HechizoFocus.CELDA_VACIA && pelea.get_Cuerpo_A_Cuerpo_Enemigo().Count() == 4)
                return ResultadoLanzandoHechizo.NO_LANZADO;

            Hechizo hechizo = cuenta.juego.personaje.get_Hechizo(hechizo_pelea.id);
            HechizoStats hechizo_stats = hechizo.get_Stats();

            List<short> rangos_disponibles = pelea.get_Rango_Hechizo(pelea.jugador_luchador.celda, hechizo_stats, mapa);
            foreach (short rango in rangos_disponibles)
            {
                if (pelea.get_Puede_Lanzar_hechizo(hechizo_pelea.id, pelea.jugador_luchador.celda, mapa.get_Celda_Id(rango), mapa) == FallosLanzandoHechizo.NINGUNO)
                {
                    if (hechizo_pelea.metodo_lanzamiento == MetodoLanzamiento.CAC || hechizo_pelea.metodo_lanzamiento == MetodoLanzamiento.AMBOS && mapa.get_Celda_Id(rango).get_Distancia(pelea.jugador_luchador.celda) != 1)
                        continue;

                    await pelea.get_Lanzar_Hechizo(hechizo_pelea.id, rango);
                    return ResultadoLanzandoHechizo.LANZADO;
                }
            }

            return ResultadoLanzandoHechizo.NO_LANZADO;
        }

        private async Task<ResultadoLanzandoHechizo> lanzar_Hechizo_AOE(PeleaHechizos hechizo_pelea)
        {
            if (hechizo_pelea.focus == HechizoFocus.ALIADO || hechizo_pelea.focus == HechizoFocus.CELDA_VACIA)
                return ResultadoLanzandoHechizo.NO_LANZADO;

            if (pelea.get_Puede_Lanzar_hechizo(hechizo_pelea.id) != FallosLanzandoHechizo.NINGUNO)
                return ResultadoLanzandoHechizo.NO_LANZADO;

            Hechizo hechizo = cuenta.juego.personaje.get_Hechizo(hechizo_pelea.id);
            HechizoStats hechizo_stats = hechizo.get_Stats();
            List<NodoRango> entradas = new List<NodoRango>();
            NodoRango entrada;

            //Celda actual del jugador
            entrada = get_Nodo_Rango(pelea.jugador_luchador.celda, null, hechizo_stats);
            if (entrada.enemigos_atacos_en_celda.Count > 0)
                entradas.Add(entrada);

            foreach (KeyValuePair<short, MovimientoNodo> kvp in PeleasPathfinder.get_Celdas_Accesibles(pelea, mapa, pelea.jugador_luchador.celda))
            {
                if (!kvp.Value.alcanzable)
                    continue;

                entrada = get_Nodo_Rango(mapa.get_Celda_Id(kvp.Key), kvp.Value, hechizo_stats);
                if (entrada.enemigos_atacos_en_celda.Count > 0)
                    entradas.Add(entrada);
            }

            short celda_id = -1;
            short desde_celda_id = -1;
            KeyValuePair<short, MovimientoNodo>? node = null;
            byte enemigos_atacos = 0;
            int pm_utilizados = 99;

            foreach (NodoRango nodo in entradas)
            {
                foreach (KeyValuePair<short, byte> kvp in nodo.enemigos_atacos_en_celda)
                {
                    if (hechizo_pelea.metodo_lanzamiento == MetodoLanzamiento.CAC && !pelea.esta_Cuerpo_A_Cuerpo_Con_Enemigo(nodo.celda))
                        continue;

                    if (pelea.get_Puede_Lanzar_hechizo(hechizo_pelea.id, nodo.celda, mapa.get_Celda_Id(kvp.Key), mapa) != FallosLanzandoHechizo.NINGUNO)
                        continue;

                    if (kvp.Value >= enemigos_atacos)
                    {
                        if (kvp.Value > enemigos_atacos || (kvp.Value == enemigos_atacos && nodo.pm_utilizados <= pm_utilizados))
                        {
                            enemigos_atacos = kvp.Value;
                            celda_id = kvp.Key;
                            desde_celda_id = nodo.celda.id;
                            pm_utilizados = nodo.pm_utilizados;

                            if (nodo.nodo != null)
                                node = new KeyValuePair<short, MovimientoNodo>(desde_celda_id, nodo.nodo);
                        }
                    }
                }
            }

            if (celda_id != -1)
            {
                if (node == null)
                {
                    if (GlobalConf.mostrar_mensajes_debug)
                        cuenta.logger.log_informacion("DEBUG", $"Se ha lanzado el hechizo {hechizo.nombre} tocando a {enemigos_atacos} enemigos en la celda {celda_id}");
                    
                    await pelea.get_Lanzar_Hechizo(hechizo_pelea.id, celda_id);
                    return ResultadoLanzandoHechizo.LANZADO;
                }
                else
                {
                    hechizo_para_lanzar = hechizo.id;
                    celda_objetivo = celda_id;
                    enemigos_tocados = enemigos_atacos;

                    await cuenta.juego.manejador.movimientos.get_Mover_Celda_Pelea(node);
                    return ResultadoLanzandoHechizo.MOVIDO;
                }
            }

            return ResultadoLanzandoHechizo.NO_LANZADO;
        }

        private NodoRango get_Nodo_Rango(Celda celda, MovimientoNodo node, HechizoStats hechizo_stats)
        {
            Dictionary<short, byte> touchedEnnemiesByCell = new Dictionary<short, byte>();
            List<short> rango = pelea.get_Rango_Hechizo(celda, hechizo_stats, mapa);

            for (int i = 0; i < rango.Count; i++)
            {
                byte tec = get_Total_Enemigos_Atacados(celda, mapa.get_Celda_Id(rango[i]), hechizo_stats);
                if (tec > 0)
                    touchedEnnemiesByCell.Add(rango[i], tec);
            }

            return new NodoRango(celda, touchedEnnemiesByCell, node);
        }

        private byte get_Total_Enemigos_Atacados(Celda celda_actual, Celda celda_objetivo, HechizoStats hechizo_stats)
        {
            byte n = 0;
            List<Celda> zona = pelea.get_Zona_Hechizo(celda_actual, celda_objetivo, hechizo_stats, mapa);

            if (zona != null)
            {
                foreach (Celda celda in zona)
                {
                    //No tocarse a si mismo
                    if (celda.id == celda_actual.id)
                        return 0;

                    //No tocar a aliados
                    foreach (Luchadores ally in pelea.get_Aliados)
                    {
                        if (ally.celda.id == celda.id)
                            return 0;
                    }

                    foreach (Luchadores ennemy in pelea.get_Enemigos)
                    {
                        if (ennemy.celda.id == celda.id)
                            n++;
                    }
                }
            }

            return n;
        }

        private Luchadores get_Objetivo_Mas_Cercano(PeleaHechizos hechizo)
        {
            if (hechizo.focus == HechizoFocus.ENCIMA)
                return pelea.jugador_luchador;

            if (hechizo.focus == HechizoFocus.CELDA_VACIA)
                return null;

            //TODO: esta vivo, evitar invocaciones, % vida, % resistencias
            bool filtro(Luchadores luchador)
            {
                if (cuenta.pelea_extension.configuracion.ignorar_invocaciones && luchador.es_invocacion)
                    return false;

                return true;
            }

            return hechizo.focus == HechizoFocus.ENEMIGO ? pelea.get_Enemigo_Mas_Cercano(filtro) : pelea.get_Obtener_Aliado_Mas_Cercano(filtro);
        }

        private bool get_Condiciones_Principales(PeleaHechizos hechizo)
        {
            if (hechizo.distancia_minima == 0)
                return true;

            if (hechizo.necesita_piedra)//Para capturar en dungs
            {
                ObjetosInventario arma = cuenta.juego.personaje.inventario.get_Objeto_en_Posicion(InventarioPosiciones.ARMA);
                if(arma != null && arma.id_modelo != 83)
                    return false;
            }

            Luchadores enemigo_cercano = hechizo.metodo_distancia == MetodoDistanciaLanzamiento.CERCANO ? pelea.get_Enemigo_Mas_Cercano() : pelea.get_Enemigo_Mas_Lejano();

            if (enemigo_cercano == null)
                return false;

            if (hechizo.distancia_operador)
                return pelea.jugador_luchador.celda.get_Distancia(enemigo_cercano.celda) >= hechizo.distancia_minima;
            else
                return pelea.jugador_luchador.celda.get_Distancia(enemigo_cercano.celda) <= hechizo.distancia_minima;
        }

        #region Zona Dispose
        public void Dispose() => Dispose(true);
        ~ManejadorHechizos() => Dispose(false);

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                cuenta = null;
                mapa = null;
                pelea = null;
                disposed = true;
            }
        }
        #endregion
    }

    internal struct NodoRango
    {
        public Celda celda { get; private set; }
        public Dictionary<short, byte> enemigos_atacos_en_celda { get; private set; }
        public MovimientoNodo nodo { get; private set; }
        public int pm_utilizados => nodo == null ? 0 : nodo.camino.celdas_accesibles.Count;

        internal NodoRango(Celda _celda, Dictionary<short, byte> _enemigos_atacos_en_celda, MovimientoNodo _nodo)
        {
            celda = _celda;
            enemigos_atacos_en_celda = _enemigos_atacos_en_celda;
            nodo = _nodo;
        }
    }
}
