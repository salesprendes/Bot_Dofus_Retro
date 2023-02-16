/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

using Bot_Dofus_Retro.Otros.Game.Personaje;

namespace Bot_Dofus_Retro.Otros.Mapas.Entidades
{
    public class Personajes : Entidad
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; }
        public byte sexo { get; set; } = 0;
        public Celda celda { get; set; }
        public Restricciones restricciones { get; private set; }
        private bool disposed;

        public Personajes(int _id, string _nombre_personaje, byte _sexo, Celda _celda, int _restricciones)
        {
            id = _id;
            nombre = _nombre_personaje;
            sexo = _sexo;
            celda = _celda;
            restricciones = new Restricciones(_restricciones);
        }

        #region Zona Dispose
        ~Personajes() => Dispose(false);
        public void Dispose() => Dispose(true);

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                celda = null;
                disposed = true;
                restricciones = null;
            }
        }
        #endregion
    }
}
