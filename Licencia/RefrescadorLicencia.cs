using System.Threading;

namespace Bot_Dofus_Retro.Licencia
{
    public static class RefrescadorLicencia
    {
        public static void iniciar() => new Timer(refrescar, null, 300000, 300000);
        private static void refrescar(object state) => VerificadorLicencia.verificar();
    }
}
