using System.Windows.Forms;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Tema.Controles.LayoutPanel
{
    class FlowLayoutPanelBuffered : FlowLayoutPanel
    {
        public FlowLayoutPanelBuffered()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
