using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones.Npc
{
    class CerrarDialogo : AccionesScript
    {
        internal override Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            if (cuenta.esta_Dialogando())
            {
                cuenta.conexion.enviar_Paquete("DV", true);
                return resultado_procesado;
            }

            return resultado_hecho;
        }
    }
}
