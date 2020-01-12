using Bot_Dofus_Retro.DarkUI.Config;
using System.Windows.Forms;

namespace Bot_Dofus_Retro.DarkUI.Controls
{
    public class DarkTextBox : TextBox
    {
        #region Constructor Region

        public DarkTextBox()
        {
            BackColor = Colors.LightBackground;
            ForeColor = Colors.LightText;
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion
    }
}
