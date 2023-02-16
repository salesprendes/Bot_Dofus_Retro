using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones
{
    public abstract class AccionesScript
    {
        protected static Task<ResultadosAcciones> resultado_hecho => Task.FromResult(ResultadosAcciones.HECHO);
        protected static Task<ResultadosAcciones> resultado_procesado => Task.FromResult(ResultadosAcciones.PROCESANDO);
        protected static Task<ResultadosAcciones> resultado_fallado => Task.FromResult(ResultadosAcciones.FALLO);

        abstract internal Task<ResultadosAcciones> proceso(Cuenta cuenta);
    }

    public enum ResultadosAcciones
    {
        HECHO,
        PROCESANDO,
        FALLO
    }
}
