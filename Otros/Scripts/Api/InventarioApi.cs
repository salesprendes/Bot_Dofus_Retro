using Bot_Dofus_Retro.Otros.Game.Personaje.Inventario;
using Bot_Dofus_Retro.Otros.Game.Personaje.Inventario.Enums;
using Bot_Dofus_Retro.Otros.Scripts.Acciones.Inventario;
using Bot_Dofus_Retro.Otros.Scripts.Manejadores;
using MoonSharp.Interpreter;
using System;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Scripts.Api
{
    [MoonSharpUserData]
    public class InventarioApi : IDisposable
    {
        private Cuenta cuenta;
        private ManejadorAcciones manejar_acciones;
        private bool disposed;

        public InventarioApi(Cuenta _cuenta, ManejadorAcciones _manejar_acciones)
        {
            cuenta = _cuenta;
            manejar_acciones = _manejar_acciones;
        }

        public int pods() => cuenta.juego.personaje.inventario.pods_actuales;
        public int podsMaximos() => cuenta.juego.personaje.inventario.pods_maximos;
        public int podsPorcentaje() => cuenta.juego.personaje.inventario.porcentaje_pods;
        public bool tieneObjeto(int modelo_id) => cuenta.juego.personaje.inventario.get_Objeto_Modelo_Id(modelo_id) != null;

        public bool utilizar(int modelo_id)
        {
            ObjetosInventario objeto = cuenta.juego.personaje.inventario.get_Objeto_Modelo_Id(modelo_id);

            if (objeto == null)
                return false;

            manejar_acciones.enqueue_Accion(new UtilizarObjetoAccion(modelo_id), true);
            return true;
        }

        public bool equipar(int modelo_id)
        {
            ObjetosInventario objeto = cuenta.juego.personaje.inventario.get_Objeto_Modelo_Id(modelo_id);

            if (objeto == null || objeto.posicion != InventarioPosiciones.NO_EQUIPADO)
                return false;

            manejar_acciones.enqueue_Accion(new EquiparItemAccion(modelo_id), true);
            return true;
        }

        #region Zona Dispose
        ~InventarioApi() => Dispose(false);
        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                cuenta = null;
                manejar_acciones = null;
                disposed = true;
            }
        }
        #endregion
    }
}
