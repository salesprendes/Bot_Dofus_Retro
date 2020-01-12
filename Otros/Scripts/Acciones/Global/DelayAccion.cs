using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones.Global
{
    public class DelayAccion : AccionesScript
    {
        public int milisegundos { get; private set; }

        public DelayAccion(int ms) => milisegundos = ms;

        internal override async Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            await Task.Delay(milisegundos);
            return ResultadosAcciones.HECHO;
        }
    }
}
