/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Mapas.Entidades
{
    public class Npc : Entidad
    {
        public int id { get; set; }
        public int modelo_id { get; private set; }
        public Celda celda { get; set; }
        private bool disposed;

        public Npc(int _id, int _modelo_id, Celda _celda)
        {
            id = _id;
            modelo_id = _modelo_id;
            celda = _celda;
        }

        #region Zona Dispose
        ~Npc() => Dispose(false);
        public void Dispose() => Dispose(true);

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                celda = null;
                disposed = true;
            }
        }
        #endregion
    }
}
