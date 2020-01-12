using Bot_Dofus_Retro.DarkUI.Renderers;
using System.Windows.Forms;

namespace Bot_Dofus_Retro.DarkUI.Controls
{
    public class DarkContextMenu : ContextMenuStrip
    {
        #region Constructor Region

        public DarkContextMenu()
        {
            Renderer = new DarkMenuRenderer();
        }

        #endregion
    }
}
