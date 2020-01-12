using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Game.Servidor;
using Bot_Dofus_Retro.Utilidades.Configuracion;
using Bot_Dofus_Retro.Utilidades.Criptografia;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.LoginCuenta
{
    public class LoginCuenta : Frame
    {
        [PaqueteAtributo("HC")]
        public Task get_Key_Bienvenida_Login(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            cuenta.key_bienvenida = paquete.Substring(2);

            await cliente.enviar_Paquete_Async(GlobalConf.version_dofus);
            await cliente.enviar_Paquete_Async($"{cliente.cuenta.configuracion.nombre_cuenta}\n{Hash.encriptar_Password(cliente.cuenta.configuracion.password, cliente.cuenta.key_bienvenida)}");
            await cliente.enviar_Paquete_Async("Af");
        });

        [PaqueteAtributo("Ad")]
        public Task get_Apodo(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.apodo = paquete.Substring(2));

        [PaqueteAtributo("Af")]
        public Task get_Fila_Espera_Login(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("FILA DE ESPERA", "Posición " + paquete[2] + "/" + paquete[4]));

        [PaqueteAtributo("AH")]
        public Task get_Servidor_Estado(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            string[] separado_servidores = paquete.Substring(2).Split('|');
            ServidorJuego servidor = cuenta.juego.servidor;
            bool primera_vez = true;

            foreach (string sv in separado_servidores)
            {
                string[] separador = sv.Split(';');

                int id = int.Parse(separador[0]);
                EstadosServidor estado = (EstadosServidor)byte.Parse(separador[1]);
                string nombre = cuenta.configuracion.get_Servidor_Nombre(id);

                if (nombre.Equals(cuenta.configuracion.servidor))
                {
                    servidor.actualizar_Datos(id, nombre, estado);
                    cuenta.logger.log_informacion("LOGIN", $"El servidor {nombre} esta {estado}");

                    if (estado != EstadosServidor.CONECTADO)
                        primera_vez = false;
                }
            }

            if (!primera_vez && servidor.estado == EstadosServidor.CONECTADO)
                await cliente.enviar_Paquete_Async("Ax");
        });

        [PaqueteAtributo("AQ")]
        public Task get_Pregunta_Secreta(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            while (cliente.cuenta.juego.servidor.estado != EstadosServidor.CONECTADO)
                await Task.Delay(500);

            await cliente.enviar_Paquete_Async("Ax", true);
        });

        [PaqueteAtributo("AxK")]
        public Task get_Lista_Servidores(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            ServidorJuego servidor = cuenta.juego.servidor;
            string[] loc5 = paquete.Substring(3).Split('|');
            int contador = 1;
            bool seleccionado = false;

            while (contador < loc5.Length && !seleccionado)
            {
                string[] _loc10_ = loc5[contador].Split(',');
                int id = int.Parse(_loc10_[0]);

                if (id == servidor.id)
                {
                    if (servidor.estado == EstadosServidor.CONECTADO)
                    {
                        seleccionado = true;
                        cuenta.juego.personaje.evento_Servidor_Seleccionado();
                    }
                    else
                        cuenta.logger.log_Error("LOGIN", "Servidor no accesible cuando este accesible se re-conectara");
                }
                contador++;
            }

            if (seleccionado)
                await cliente.enviar_Paquete_Async($"AX{servidor.id}", true);
        });

        [PaqueteAtributo("AXK")]
        public Task get_Seleccion_Servidor(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            Cuenta cuenta = cliente.cuenta;
            cuenta.tiquet_game = paquete.Substring(14);
            string ip = Hash.desencriptar_Ip(paquete.Substring(3, 8));
            int puerto = Hash.desencriptar_Puerto(paquete.Substring(11, 3).ToCharArray());
            cliente.cuenta.cambiando_Al_Servidor_Juego(ip, puerto);
        });
    }
}
