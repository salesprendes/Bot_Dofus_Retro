using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Mapas.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Juego
{
    class NPCFrame : Frame
    {
        [PaqueteAtributo("DCK")]
        public Task get_Dialogo_Creado(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            Cuenta cuenta = cliente.cuenta;
            sbyte npc_id = sbyte.Parse(paquete.Substring(3));
            cuenta.juego.npcs.get_Dialogo_Creado(npc_id);
        });

        [PaqueteAtributo("DQ")]
        public Task get_Lista_Respuestas(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            Cuenta cuenta = cliente.cuenta;

            string[] pregunta_separada = paquete.Substring(2).Split('|');
            List<short> respuestas = new List<short>(0);

            if (pregunta_separada.Count() > 1)
            {
                string[] respuestas_disponibles = pregunta_separada[1].Split(';');
                respuestas = new List<short>(respuestas_disponibles.Count());

                foreach (string respuesta in respuestas_disponibles)
                    respuestas.Add(short.Parse(respuesta));
            }

            short pregunta = short.Parse(pregunta_separada[0]);
            cuenta.juego.npcs.get_Respuestas_Recibidas(pregunta, respuestas);
        });
    }
}
