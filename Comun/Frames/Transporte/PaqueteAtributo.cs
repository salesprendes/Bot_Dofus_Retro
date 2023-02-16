using System;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Transporte
{
    class PaqueteAtributo : Attribute
    {
        public string paquete;

        public PaqueteAtributo(string _paquete) => paquete = _paquete;
    }
}
