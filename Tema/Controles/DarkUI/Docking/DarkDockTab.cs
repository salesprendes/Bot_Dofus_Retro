using System.Drawing;

namespace Bot_Dofus_Retro.DarkUI.Docking
{
    internal class DarkDockTab
    {
        public DarkDockContent DockContent { get; set; }
        public Rectangle ClientRectangle { get; set; }
        public bool Hot { get; set; }
        public bool ShowSeparator { get; set; }

        public DarkDockTab(DarkDockContent content) => DockContent = content;

        public int CalculateWidth(Graphics g, Font font)
        {
            int width = (int)g.MeasureString(DockContent.DockText, font).Width;
            width += 10;

            return width;
        }
    }
}
