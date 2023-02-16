using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones.Npc
{
    public class NpcBanco : AccionesScript
    {
        public int id { get; private set; }
        public short respuesta { get; private set; }

        public NpcBanco(int _id, short _respuesta)
        {
            id = _id;
            respuesta = _respuesta;
        }

        internal override Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            if (!cuenta.juego.npcs.utilizar(id))
            {
                cuenta.script.detener_Script($"Error al dialogar con el npc id: {id}");
                return resultado_fallado;
            }

            return resultado_procesado;
        }
    }
}
