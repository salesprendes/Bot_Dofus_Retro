using System.Numerics;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Utilidades.Criptografia
{
    public static class Base36
    {
        private const string digitos = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static int decodificar(string valor)
        {
            int decodificado = 0;

            for (int i = 0; i < valor.Length; ++i)
                decodificado += digitos.IndexOf(valor[i]) * (int)BigInteger.Pow(digitos.Length, valor.Length - i - 1);

            return decodificado;
        }
    }
}
