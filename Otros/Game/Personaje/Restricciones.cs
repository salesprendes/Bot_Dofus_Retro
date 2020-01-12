using System.Text;

namespace Bot_Dofus_Retro.Otros.Game.Personaje
{
    public class Restricciones
    {
        public bool PUEDE_SER_AGREDIDO { get; private set; }
        public bool PUEDE_SER_DESAFIADO { get; private set; }
        public bool PUEDE_HACER_INTERCAMBIO { get; private set; }
        public bool PUEDE_SER_ATACADO { get; private set; }
        public bool PUEDE_CORRER { get; private set; }
        public bool ES_FANTASMA { get; private set; }
        public bool PUEDE_CAMBIAR_MODO_CRIATURA { get; private set; }
        public bool ES_TUMBA { get; private set; }

        public Restricciones(int restriccion) => set_Restricciones(restriccion);

        public void set_Restricciones(int restriccion)
        {
            PUEDE_SER_AGREDIDO = (restriccion & 1) != 1;
            PUEDE_SER_DESAFIADO = (restriccion & 2) != 2;
            PUEDE_HACER_INTERCAMBIO = (restriccion & 4) != 4;
            PUEDE_SER_ATACADO = (restriccion & 8) != 8;
            PUEDE_CORRER = (restriccion & 16) == 16;
            ES_FANTASMA = (restriccion & 32) == 32;
            PUEDE_CAMBIAR_MODO_CRIATURA = (restriccion & 64) != 64;
            ES_TUMBA = (restriccion & 128) == 128;
        }

        public string toString()
        {
            StringBuilder restricciones = new StringBuilder();

            restricciones.Append("RESTRICCIONES:");
            restricciones.Append($"\nPUEDDE SER AGREDIDO: {PUEDE_SER_AGREDIDO}");
            restricciones.Append($"\nPUEDE SER DESAFIADO: {PUEDE_SER_DESAFIADO}");
            restricciones.Append($"\nPUEDE HACER INTERCAMBIO: {PUEDE_HACER_INTERCAMBIO}");
            restricciones.Append($"\nPUEDE SER ATACADO: {PUEDE_SER_ATACADO}");
            restricciones.Append($"\nPUEDE CORRER: {PUEDE_CORRER}");
            restricciones.Append($"\nES FANTASMA: {ES_FANTASMA}");
            restricciones.Append($"\nPUEDE SWITCH MODO CRIATURA: {PUEDE_CAMBIAR_MODO_CRIATURA}");
            restricciones.Append($"\nES TUMBA: {ES_TUMBA}");

            return restricciones.ToString();
        }
    }
}
