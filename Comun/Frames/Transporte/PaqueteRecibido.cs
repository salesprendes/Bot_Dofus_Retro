using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/*
    Este archivo es parte del proyecto Bot Dofus Retro
    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Transporte
{
    public static class PaqueteRecibido
    {
        public static readonly List<PaqueteDatos> metodos = new List<PaqueteDatos>();

        public static void Inicializar()
        {
            Assembly asm = typeof(Frame).GetTypeInfo().Assembly;

            foreach (MethodInfo tipo in asm.GetTypes().SelectMany(x => x.GetMethods()).Where(m => m.GetCustomAttributes(typeof(PaqueteAtributo), false).Length > 0))
            {
                PaqueteAtributo atributo = tipo.GetCustomAttributes(typeof(PaqueteAtributo), true)[0] as PaqueteAtributo;
                Type tipo_string = Type.GetType(tipo.DeclaringType.FullName);

                object instancia = Activator.CreateInstance(tipo_string, null);
                metodos.Add(new PaqueteDatos(instancia, atributo.paquete, tipo));
            }
        }

        public static void Recibir(ClienteTcp cliente, string paquete)
        {
            PaqueteDatos metodo = metodos.Find(m => paquete.StartsWith(m.nombre_paquete));
            Cuenta cuenta = cliente.cuenta;

            if (metodo != null && cuenta != null)
                metodo?.informacion.Invoke(metodo.instancia, new object[2] { cliente, paquete });
        }
    }
}