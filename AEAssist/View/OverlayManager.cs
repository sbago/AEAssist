using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Buddy.Overlay;
using ff14bot;
using ff14bot.Enums;

namespace AEAssist.View
{
    public class OverlayManager
    {
        public static OverlayManager Instance = new OverlayManager();

        private Dictionary<ClassJobType, Window> AllOverlays = new Dictionary<ClassJobType, Window>();

        private ClassJobType _classJobType;
        
        public void Init()
        {
            AllOverlays[ClassJobType.Bard] = new BardOverlayWindow();
            SwitchJob();
        }

        public void SwitchJob()
        {
            var currJob = Core.Me.CurrentJob;
            if (currJob == _classJobType)
                return;
            _classJobType = currJob;
            foreach (var v in AllOverlays)
            {
                v.Value.Dispatcher.Invoke(v.Value.Hide);
            }
            

            if (AllOverlays.TryGetValue(currJob, out var window))
            {
                window.Dispatcher.Invoke(window.Show);
            }
        }

        public void ShowOverlay()
        {
            var currJob = Core.Me.CurrentJob;
            _classJobType = currJob;
            foreach (var v in AllOverlays)
            {
                v.Value.Dispatcher.Invoke(v.Value.Hide);
            }
            

            if (AllOverlays.TryGetValue(currJob, out var window))
            {
                window.Dispatcher.Invoke(window.Show);
            }
        }

        public void Close()
        {
            foreach (var v in AllOverlays)
            {
                v.Value.Dispatcher.Invoke(v.Value.Hide);
            }

        }
    }
}