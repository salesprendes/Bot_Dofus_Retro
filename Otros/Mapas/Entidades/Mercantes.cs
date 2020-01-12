namespace Bot_Dofus_Retro.Otros.Mapas.Entidades
{
    public class Mercantes : Entidad
    {
        public int id { get; set; }
        public Celda celda { get; set; }
        private bool disposed;

        public Mercantes(int _id, Celda _celda)
        {
            id = _id;
            celda = _celda;
        }

        #region Zona Dispose
        ~Mercantes() => Dispose(false);
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
