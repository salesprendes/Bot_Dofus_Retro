using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Game.Personaje;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Juego
{
    internal class ServidorSeleccionFrame : Frame
    {
        [PaqueteAtributo("HG")]
        public Task get_Bienvenida_juego(ClienteTcp cliente, string paquete) => Task.Run(async () => await cliente.enviar_Paquete_Async("AT" + cliente.cuenta.tiquet_game));

        [PaqueteAtributo("ATK0")]
        public Task resultado_Servidor_Seleccion(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            await cliente.enviar_Paquete_Async("Ak0");
            await cliente.enviar_Paquete_Async("AV");
        });

        [PaqueteAtributo("AV0")]
        public Task get_Idioma_Core(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            await cliente.enviar_Paquete_Async("Ages");
            await cliente.enviar_Paquete_Async("AL");
            await cliente.enviar_Paquete_Async("Af");
        });

        [PaqueteAtributo("ALK")]
        public Task get_Lista_Personajes(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            string[] _loc6_ = paquete.Substring(3).Split('|');
            int contador = 2, id_personaje = 0;
            bool encontrado = false;

            while (contador < _loc6_.Length && !encontrado)
            {
                string[] _loc11_ = _loc6_[contador].Split(';');
                id_personaje = int.Parse(_loc11_[0]);
                string nombre = _loc11_[1];

                if (nombre.ToLower().Equals(cuenta.configuracion.nombre_personaje.ToLower()) || string.IsNullOrEmpty(cuenta.configuracion.nombre_personaje))
                    encontrado = true;

                contador++;
            }

            await Task.Delay(1000);

            if (!cuenta.juego.personaje.esta_conectado && encontrado)
                await cliente.enviar_Paquete_Async("AS" + id_personaje, true);
        });

        [PaqueteAtributo("ASK")]
        public Task get_Personaje_Seleccionado(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            PersonajeJuego personaje = cuenta.juego.personaje;
            string[] _loc4 = paquete.Substring(4).Split('|');

            int id = int.Parse(_loc4[0]);
            string nombre = _loc4[1];
            byte nivel = byte.Parse(_loc4[2]);
            byte raza_id = byte.Parse(_loc4[3]);
            byte sexo = byte.Parse(_loc4[4]);

            personaje.set_Datos_Personaje(id, nombre, nivel, sexo, raza_id);
            personaje.esta_conectado = true;
            personaje.inventario.agregar_Objetos(_loc4[9]);

            cuenta.juego.personaje.timer_afk.Change(1200000, 1200000);
            cuenta.juego.personaje.evento_Personaje_Seleccionado();

            await cliente.enviar_Paquete_Async("BYA");//Modo Ausente
            await cliente.enviar_Paquete_Async("GC1");
        });

        [PaqueteAtributo("GCK")]
        public Task get_Crear_Pantalla_Juego(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.Estado_Cuenta = EstadoCuenta.CONECTADO_INACTIVO);
    }
}
