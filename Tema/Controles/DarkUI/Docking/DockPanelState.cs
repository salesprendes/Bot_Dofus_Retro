using System.Collections.Generic;

namespace Bot_Dofus_Retro.DarkUI.Docking
{
    public class DockPanelState
    {
        #region Property Region

        public List<DockRegionState> Regions { get; set; }

        #endregion

        #region Constructor Region

        public DockPanelState()
        {
            Regions = new List<DockRegionState>();
        }

        #endregion
    }
}
