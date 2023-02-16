using System;
using System.Management;
using System.Net.Http;
using System.Windows.Forms;

namespace Bot_Dofus_Retro.Licencia
{
    public static class VerificadorLicencia
    {
        private static TiposLicencia tipo_licencia = TiposLicencia.NINGUNO;

        public static void verificar()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage respuesta = client.GetAsync("https://drive.google.com/uc?export=download&id=1GS-TwCjToU1BsOVnOTKH_jtDAlE0FSHO").Result)
                    {
                        string content = respuesta.Content.ReadAsStringAsync().Result;
                        string mac = get_Direccion_Mac();
                       
                        if (mac != null)
                        {
                            foreach (string x in content.Split(';'))
                            {
                                if (mac == x)
                                {
                                    tipo_licencia = TiposLicencia.TESTER;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Environment.Exit(0);
                return;
            }

            if (tipo_licencia == TiposLicencia.NINGUNO)
            {
                MessageBox.Show("No tienes una licencia valida para utilizar el bot", "Licencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }

            comprobar();
        }

        public static bool comprobar() => tipo_licencia == TiposLicencia.TESTER;

        private static string get_Direccion_Mac()
        {
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        if (moc != null)
                        {
                            foreach (ManagementObject mo in moc)
                            {
                                if (mo["MacAddress"] != null && mo["IPEnabled"] != null && (bool)mo["IPEnabled"] == true)
                                    return mo["MacAddress"].ToString().Replace(":", "");

                                mo.Dispose();
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }
    }
}
