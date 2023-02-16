using MoonSharp.Interpreter;
using System;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Scripts.Api
{
    [MoonSharpUserData]
    public class PersonajeApi : IDisposable
    {
        private Cuenta cuenta;
        private bool disposed;

        public PersonajeApi(Cuenta _cuenta) => cuenta = _cuenta;

        public string nombre() => cuenta.juego.personaje.nombre;
        public byte nivel() => cuenta.juego.personaje.nivel;
        public int experiencia() => cuenta.juego.personaje.porcentaje_experiencia;
        public int kamas() => cuenta.juego.personaje.kamas;

        #region Zona Dispose
        ~PersonajeApi() => Dispose(false);
        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                cuenta = null;
                disposed = true;
            }
        }
        #endregion
    }
}
