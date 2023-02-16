using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones
{
    class CerrarVentanaAccion : AccionesScript
    {
        internal override Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            if (cuenta.esta_Dialogando())
            {
                cuenta.conexion.enviar_Paquete_Async("EV").Wait();
                return resultado_procesado;
            }

            return resultado_hecho;
        }
    }
}
