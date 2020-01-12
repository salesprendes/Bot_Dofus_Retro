using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Game;
using Bot_Dofus_Retro.Otros.Grupos;
using Bot_Dofus_Retro.Otros.Peleas;
using Bot_Dofus_Retro.Otros.Scripts;
using Bot_Dofus_Retro.Utilidades.Configuracion;
using Bot_Dofus_Retro.Utilidades.Logs;
using System;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
	Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros
{
    public class Cuenta : IDisposable
    {
        public string apodo { get; set; } = string.Empty;
        public string key_bienvenida { get; set; } = string.Empty;
        public string tiquet_game { get; set; } = string.Empty;
        public Logger logger { get; private set; }
        public ClienteTcp conexion { get; set; }
        public Juego juego { get; private set; }
        public ManejadorScript script { get; set; }
        public PeleaExtensiones pelea_extension { get; set; }
        public CuentaConf configuracion { get; private set; }
        private EstadoCuenta estado = EstadoCuenta.DESCONECTADO;
        public bool puede_utilizar_dragopavo = false;

        public bool esta_ocupado => Estado_Cuenta != EstadoCuenta.CONECTADO_INACTIVO && Estado_Cuenta != EstadoCuenta.REGENERANDO;
        public Grupo grupo { get; set; }
        public bool tiene_grupo => grupo != null;
        public bool es_lider_grupo => !tiene_grupo || grupo.lider == this;

        private bool disposed;
        public event Action estado_cuenta;
        public event Action cuenta_conectada;
        public event Action cuenta_desconectada;

        public Cuenta(CuentaConf _configuracion)
        {
            configuracion = _configuracion;
            logger = new Logger();
            juego = new Juego(this);
            pelea_extension = new PeleaExtensiones(this);
            script = new ManejadorScript(this);
            conexion = new ClienteTcp(this);
        }

        public async Task conectar()
        {
            await conexion.conexion_Servidor(GlobalConf.ip_conexion, GlobalConf.puerto_conexion);
            Estado_Cuenta = EstadoCuenta.CONECTANDO;
            cuenta_conectada?.Invoke();
        }

        public async void cambiando_Al_Servidor_Juego(string ip, int puerto)
        {
            Estado_Cuenta = EstadoCuenta.CAMBIANDO_A_JUEGO;
            conexion.get_Desconectar_Socket();
            await conexion.conexion_Servidor(ip, puerto);
            Estado_Cuenta = EstadoCuenta.CONECTANDO;
        }

        public void desconectar()
        {
            conexion.get_Desconectar_Socket();
            script.detener_Script();
            juego.limpiar();
            Estado_Cuenta = EstadoCuenta.DESCONECTADO;
            cuenta_desconectada?.Invoke();
        }

        public EstadoCuenta Estado_Cuenta
        {
            get => estado;
            set
            {
                estado = value;
                estado_cuenta?.Invoke();
            }
        }

        public bool esta_Desconectado() => Estado_Cuenta == EstadoCuenta.DESCONECTADO;
        public bool esta_Cambiando_A_Juego() => Estado_Cuenta == EstadoCuenta.CAMBIANDO_A_JUEGO;
        public bool esta_Dialogando() => Estado_Cuenta == EstadoCuenta.ALMACENAMIENTO || Estado_Cuenta == EstadoCuenta.DIALOGANDO || Estado_Cuenta == EstadoCuenta.INTERCAMBIO || Estado_Cuenta == EstadoCuenta.COMPRANDO || Estado_Cuenta == EstadoCuenta.VENDIENDO;
        public bool esta_Luchando() => Estado_Cuenta == EstadoCuenta.LUCHANDO;
        public bool esta_Recolectando() => Estado_Cuenta == EstadoCuenta.RECOLECTANDO;
        public bool esta_Desplazando() => Estado_Cuenta == EstadoCuenta.MOVIMIENTO;

        #region Zona Dispose
        public void Dispose() => Dispose(true);
        ~Cuenta() => Dispose(false);

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    script.Dispose();
                    conexion?.Dispose();
                    juego.Dispose();
                }

                script = null;
                key_bienvenida = null;
                conexion = null;
                logger = null;
                juego = null;
                apodo = null;
                configuracion = null;
                disposed = true;
            }
        }
        #endregion
    }
}
