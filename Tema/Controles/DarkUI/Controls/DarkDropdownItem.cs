using System.Drawing;

namespace Bot_Dofus_Retro.DarkUI.Controls
{
    public class DarkDropdownItem
    {
        public string Text { get; set; }
        public Bitmap Icon { get; set; }

        public DarkDropdownItem() {}
        public DarkDropdownItem(string text) => Text = text;
        public DarkDropdownItem(string text, Bitmap icon) : this(text) => Icon = icon;

    }
}
