using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Buddy.Overlay;
using Buddy.Overlay.Controls;
using ff14bot;
using ff14bot.Enums;

namespace AEAssist.View
{
    public class OverlayManager
    {
        public static OverlayManager Instance = new OverlayManager();

        private Dictionary<ClassJobType, OverlayUIComponent> AllOverlays = new Dictionary<ClassJobType, OverlayUIComponent>();

        private ClassJobType _classJobType;

        private OverlayUIComponent lastOverlay;
        
        public void Init()
        {
            AllOverlays[ClassJobType.Bard] = new OverlayUIComponent_BardOverlay(true);
            AllOverlays[ClassJobType.Reaper] = new OverlayUIComponent_ReaperOverlay(true);
        }

        public void SwitchJob()
        {
            if (!Core.OverlayManager.IsActive)
                return;
            var currJob = Core.Me.CurrentJob;
            if (currJob == _classJobType)
                return;

            if (lastOverlay != null)
            {
                Core.OverlayManager.RemoveUIComponent(lastOverlay);
                // v.Value.Dispatcher.Invoke(v.Value.Hide);
                lastOverlay = null;
            }


            _classJobType = currJob;
            if (AllOverlays.TryGetValue(currJob, out var window))
            {
                LogHelper.Info($"OpenOverlay {window.GetType().Name}");
                Core.OverlayManager.AddUIComponent(window);
                lastOverlay = window;
                //window.Dispatcher.Invoke(window.Show);
            }
        }

        public void SwitchOverlay()
        {
            if (!Core.OverlayManager.IsActive)
                return;
            if (lastOverlay != null)
            {
               Close();
            }
            else
            {
                var currJob = Core.Me.CurrentJob;
                _classJobType = currJob;
                if (AllOverlays.TryGetValue(currJob, out var window))
                {
                    Core.OverlayManager.AddUIComponent(window);
                    lastOverlay = window;
                }   
            }
        }

        public void Close()
        {
            if (lastOverlay != null)
                Core.OverlayManager.RemoveUIComponent(lastOverlay);
            lastOverlay = null;
        }
    }
}