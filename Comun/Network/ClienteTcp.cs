using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Network
{
    public class ClienteTcp : IDisposable
    {
        private Socket socket { get; set; }
        private byte[] buffer { get; set; }
        public Cuenta cuenta;
        private SemaphoreSlim semaforo;
        private bool disposed;

        public event Action<string> paquete_recibido;
        public event Action<string> paquete_enviado;
        public event Action<string> socket_informacion;

        /** ping **/
        private bool esperando_paquete;
        private int ticks;
        private List<int> pings;

        public ClienteTcp(Cuenta _cuenta) => cuenta = _cuenta;

        public async Task conexion_Servidor(string ip, int puerto)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                buffer = new byte[socket.ReceiveBufferSize];
                semaforo = new SemaphoreSlim(1);
                pings = new List<int>(50);
                await socket.ConnectAsync(ip, puerto);

                if (get_Esta_Conectado())
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
            byte[] _buffer = new byte[bytes_leidos];
            Array.Copy(buffer, _buffer, _buffer.Length);

            if (bytes_leidos < 1 || respuesta != SocketError.Success)
            {
                cuenta.desconectar();
                return;
            }

            string datos = Encoding.UTF8.GetString(_buffer, 0, bytes_leidos);
            foreach (string paquete in datos.Replace("\x0a", string.Empty).Split('\0').Where(x => x != string.Empty))
            {
                paquete_recibido?.Invoke(paquete);
                if (esperando_paquete)
                {
                    pings.Add(Environment.TickCount - ticks);

                    if (pings.Count > 48)
                        pings.Clear();

                    esperando_paquete = false;
                }
                PaqueteRecibido.Recibir(this, paquete);
            }
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, recibir_CallBack, socket);
        }

        public async Task enviar_Paquete_Async(string paquete, bool necesita_respuesta = false)
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

            if (necesita_respuesta)
            {
                esperando_paquete = true;
                ticks = Environment.TickCount;
            }

            socket.Send(byte_paquete);
            paquete_enviado?.Invoke(paquete);
            semaforo.Release();
        }

        public void enviar_Paquete(string paquete, bool necesita_respuesta = false) => enviar_Paquete_Async(paquete, necesita_respuesta).Wait();

        public void get_Desconectar_Socket()
        {
            if (get_Esta_Conectado())
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Disconnect(true);
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

        #region Pings
        public int get_Total_Pings() => pings.Count();
        public int get_Actual_Ping() => Environment.TickCount - ticks;
        public int get_Promedio_Pings()
        {
            int total_pings = 0, contador = 0;
            while (contador < pings.Count)
            {
                total_pings += pings[contador];
                contador++;
            }
            return total_pings / pings.Count;
        }
        #endregion

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
                }

                semaforo = null;
                cuenta = null;
                socket = null;
                buffer = null;
                paquete_recibido = null;
                paquete_enviado = null;
                disposed = true;
            }
        }
        #endregion
    }
}
