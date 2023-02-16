using System.Collections.Generic;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones
{
    internal class RecoleccionAccion : AccionesScript
    {
        public List<short> elementos { get; private set; }

        public RecoleccionAccion(List<short> _elementos) => elementos = _elementos;

        internal override Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            if (cuenta.juego.manejador.recoleccion.get_Puede_Recolectar(elementos))
            {
                if (!cuenta.juego.manejador.recoleccion.get_Intentar_Recolectar(elementos))
                {
                    cuenta.script.detener_Script("Error al recolectar");
                    return resultado_fallado;
                }

                return resultado_procesado;
            }
            return resultado_hecho;
        }
    }
}
