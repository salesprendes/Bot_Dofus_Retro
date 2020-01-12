using Bot_Dofus_Retro.DarkUI.Config;
using System.Drawing;
using System.Windows.Forms;

namespace Bot_Dofus_Retro.DarkUI.Controls
{
    public class DarkRichTextBox : RichTextBox
    {
        public DarkRichTextBox()
        {
            BackColor = Colors.LightBackground;
            ForeColor = Colors.LightText;
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.None;
        }
    }
}
