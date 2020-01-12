using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones.Npc
{
    public class ResponderDialogo : AccionesScript
    {
        public short respuesta { get; private set; }

        public ResponderDialogo(short _respuesta) => respuesta = _respuesta;

        internal override Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            if (!cuenta.juego.npcs.responder(respuesta))
            {
                cuenta.script.detener_Script($"Error al responder a la respuesta {respuesta}");
                return resultado_fallado;
            }

            return resultado_procesado;
        }
    }
}
