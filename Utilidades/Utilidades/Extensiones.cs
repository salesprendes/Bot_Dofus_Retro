using Bot_Dofus_Retro.Otros.Enums;
using MoonSharp.Interpreter;
using System;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Utilidades.Extensiones
{
    public static class Extensiones
    {
        public static string cadena_Amigable(this EstadoCuenta estado)
        {
            switch (estado)
            {
                case EstadoCuenta.CONECTANDO:
                    return "Conectando";
                case EstadoCuenta.DESCONECTADO:
                    return "Desconectado";
                case EstadoCuenta.INTERCAMBIO:
                    return "Intercambiando";
                case EstadoCuenta.LUCHANDO:
                    return "Combate";
                case EstadoCuenta.RECOLECTANDO:
                    return "Recolectando";
                case EstadoCuenta.MOVIMIENTO:
                    return "Desplazando";
                case EstadoCuenta.CONECTADO_INACTIVO:
                    return "Inactivo";
                case EstadoCuenta.ALMACENAMIENTO:
                    return "Almacenamiento";
                case EstadoCuenta.DIALOGANDO:
                    return "Dialogando";
                case EstadoCuenta.COMPRANDO:
                    return "Comprando";
                case EstadoCuenta.VENDIENDO:
                    return "Vendiendo";
                case EstadoCuenta.REGENERANDO:
                    return "Regenerando Vida";
                default:
                    return "-";
            }
        }

        public static T get_Or<T>(this Table table, string key, DataType type, T orValue)
        {
            DynValue bandera = table.Get(key);

            if (bandera.IsNil() || bandera.Type != type)
                return orValue;

            try
            {
                return (T)bandera.ToObject(typeof(T));
            }
            catch
            {
                return orValue;
            }
        }

        public static int get_Nuevo_Random(int min, int max)
        {
            int seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
            return new Random(seed).Next(min, max);
        }
        
        #region Socket Task
        public static Task ConnectAsync(this Socket socket, string host, int port)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(socket);
            socket.BeginConnect(host, port, BeginConnectCallback, tcs);
            return tcs.Task;
        }

        private static readonly AsyncCallback BeginConnectCallback = ar =>
        {
            var tcs = (TaskCompletionSource<bool>)ar.AsyncState;
            try
            {
                ((Socket)tcs.Task.AsyncState).EndConnect(ar);
                tcs.TrySetResult(true);
            }
            catch (Exception e)
            {
                tcs.TrySetException(e);
            }
        };
        #endregion
    }
}
