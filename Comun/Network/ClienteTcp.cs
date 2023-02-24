using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Utilidades.Criptografia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Network
{
    public class ClienteTcp : IDisposable
    {
        /** TCP **/
        private Socket socket { get; set; }
        private byte[] buffer { get; set; }
        public Ping ping { get; private set; }
        private StringBuilder buffer_paquete { get; set; }

        /** Otros **/
        public Cuenta cuenta;
        private SemaphoreSlim semaforo;
        public bool disposed { get; private set; } = false;
        public event Action<string> socket_informacion;

        /** API **/
        public string api_key { get; private set; }
        public string auth_getGameToken { get; private set; }
        private bool api_conectada = false;


        public ClienteTcp(Cuenta _cuenta)
        {
            semaforo = new SemaphoreSlim(1);
            ping = new Ping();
            cuenta = _cuenta;
            buffer_paquete = new StringBuilder();
        }

        public async Task conectar(string ip, int puerto)
        {
            try
            {
                //Conectar para obtener api y token
                api_conectada = await conexion_Zaap();

                if (!api_conectada)
                {
                    socket_informacion?.Invoke("La api no esta conectada con ankama");
                    return;
                }

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                buffer = new byte[socket.ReceiveBufferSize];

                await socket.ConnectAsync(ip, puerto);

                if (get_Esta_Conectado() && api_conectada)
                {
                    socket_informacion?.Invoke("Socket conectado correctamente");
                    socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, recibir_CallBack, socket);
                }
            }
            catch (SocketException)
            {
                socket_informacion?.Invoke("Impossible conectar el socket con el host");
                cuenta.desconectar();
            }
        }

        public async Task<bool> conexion_Zaap()
        {
            if (!string.IsNullOrEmpty(api_key) && !string.IsNullOrEmpty(auth_getGameToken))
                return true;

            api_key = await ZaapConnect.get_ApiKey(cuenta.configuracion.nombre_cuenta, cuenta.configuracion.password);

            if (!string.IsNullOrEmpty(api_key))
                socket_informacion?.Invoke($"Conectado API Ankama API_KEY: {api_key}");
            else
                socket_informacion?.Invoke($"Error obteniendo la api");

            await Task.Delay(Hash.get_Nuevo_Random(1000, 3000));//Para evitar ban ip

            auth_getGameToken = await ZaapConnect.get_Token(api_key);

            if (!string.IsNullOrEmpty(auth_getGameToken) && auth_getGameToken.Length == 36)
                socket_informacion?.Invoke($"Conectado API Ankama TOKEN_KEY: {auth_getGameToken}");
            else
                socket_informacion?.Invoke($"Error obteniendo el token");

            return !string.IsNullOrEmpty(api_key) && !string.IsNullOrEmpty(auth_getGameToken);
        }

        public async Task enviar(string paquete)
        {
            if (cuenta == null)
                return;

            if (!get_Esta_Conectado())
            {
                cuenta.desconectar();
                return;
            }

            await semaforo.WaitAsync().ConfigureAwait(false);
            byte[] byte_paquete = Encoding.UTF8.GetBytes(string.Format($"{paquete}\n\x00"));

            socket.Send(byte_paquete);
            ping.set_ticks();

            semaforo.Release();
        }

        public void get_Desconectar_Socket()
        {
            if (get_Esta_Conectado())
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Disconnect(true);
                ping.set_Limpiar_latencias();
                socket_informacion?.Invoke("Socket desconectado del host");
            }
        }

        public bool get_Esta_Conectado()
        {
            try
            {
                return !(disposed || socket == null || !socket.Connected && socket.Available == 0);
            }
            catch (SocketException)
            {
                return false;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }

        public void recibir_CallBack(IAsyncResult ar)
        {
            if (cuenta == null || cuenta.esta_Cambiando_A_Juego())
                return;

            if (!get_Esta_Conectado())
            {
                cuenta.desconectar();
                return;
            }

            int bytes_leidos = socket.EndReceive(ar, out SocketError respuesta);
            if (bytes_leidos < 1 || respuesta != SocketError.Success)
            {
                cuenta.desconectar();
                return;
            }

            byte[] _buffer = new byte[bytes_leidos];
            Array.Copy(buffer, _buffer, _buffer.Length);

            string datos = Encoding.UTF8.GetString(_buffer, 0, bytes_leidos);
            List<string> paquetes = datos.Replace("\x0a", string.Empty).Split('\0').Where(x => x != string.Empty).ToList();

            foreach (string paquete in paquetes)
            {
                if (paquetes.IndexOf(paquete) != paquetes.Count - 1 || datos.EndsWith("\0"))
                {
                    ping.set_Agregar_Latencia();
                    PaqueteRecibido.Recibir(this, buffer_paquete.Append(paquete).ToString());
                    Console.WriteLine(buffer_paquete.ToString());
                    buffer_paquete.Clear();
                }
                else
                {
                    buffer_paquete.Append(paquete);
                }
            }

            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, recibir_CallBack, socket);
        }

        #region Zona Dispose
        ~ClienteTcp() => Dispose(false);
        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (socket != null && socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Disconnect(false);
                    socket.Close();
                }

                if (disposing)
                {
                    socket?.Dispose();
                    semaforo?.Dispose();
                    buffer_paquete.Clear();
                }

                semaforo = null;
                buffer_paquete = null;
                api_key = null;
                auth_getGameToken = null;
                api_conectada = false;
                cuenta = null;
                socket = null;
                buffer = null;
                ping = null;
                ping = null;
                disposed = true;
            }
        }
        #endregion
    }
}
