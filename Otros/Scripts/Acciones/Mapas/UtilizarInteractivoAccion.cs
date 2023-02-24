using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones.Mapas
{
    public class UtilizarInteractivoAccion : AccionesScript
    {
        public int celda_id { get; private set; }
        public int habilidad { get; private set; }

        public UtilizarInteractivoAccion(int _celda_id, int skillInstanceUid)
        {
            celda_id = _celda_id;
            habilidad = skillInstanceUid;
        }

        internal override Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            if (!cuenta.juego.manejador.interactivos.get_Utilizar_Interactivo(celda_id, habilidad))
            {
                cuenta.script.detener_Script($"Error al utilizar el interactivo en la celda {celda_id}");
                return resultado_fallado;
            }

            return resultado_procesado;
        }
    }
}
