using System.Windows.Forms;

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
