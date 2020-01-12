using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bot_Dofus_Retro.DarkUI.Docking
{
    [ToolboxItem(false)]
    public class DarkDockContent : UserControl
    {
        public event Action<DarkDockContent> AparienciaCambiada;
        private string _dockText;
        private Bitmap _icon;

        #region Property Region

        [Category("Appearance")]
        [Description("Determines the text that will appear in the content tabs and headers.")]
        public string DockText
        {
            get { return _dockText; }
            set
            {
                _dockText = value;
                AparienciaCambiada?.Invoke(this);
            }
        }

        [Category("Appearance")]
        [Description("Determines the icon that will appear in the content tabs and headers.")]
        public Bitmap Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                AparienciaCambiada?.Invoke(this);
                Invalidate();
            }
        }

        [Category("Layout")]
        [Description("Determines the default area of the dock panel this content will be added to.")]
        [DefaultValue(DarkDockArea.Document)]
        public DarkDockArea DefaultDockArea { get; set; }

        [Category("Behavior")]
        [Description("Determines the key used by this content in the dock serialization.")]
        public string SerializationKey { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DarkDockPanel DockPanel { get; internal set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DarkDockRegion DockRegion { get; internal set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DarkDockGroup DockGroup { get; internal set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DarkDockArea DockArea { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Order { get; set; }

        #endregion

        #region Constructor Region

        public DarkDockContent()
        { }

        #endregion

        #region Method Region

        public virtual void Close()
        {
            if (DockPanel != null)
                DockPanel.RemoveContent(this);
        }

        #endregion

        #region Event Handler Region

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (DockPanel == null)
                return;

            DockPanel.ActiveContent = this;
        }

        #endregion
    }
}
