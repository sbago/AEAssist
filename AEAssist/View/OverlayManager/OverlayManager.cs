using System;
using System.Collections.Generic;
using Buddy.Overlay;
using ff14bot;
using ff14bot.Enums;
using QuickGraph.Algorithms.ConnectedComponents;

namespace AEAssist.View
{
    public class OverlayManager
    {
        public static OverlayManager Instance = new OverlayManager();

        private ClassJobType _classJobType;

        private readonly Dictionary<ClassJobType, OverlayUIComponent> AllOverlays =
            new Dictionary<ClassJobType, OverlayUIComponent>();

        public OverlayUIComponent lastOverlay;

        public void Init()
        {
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;
                var attrs = type.GetCustomAttributes(typeof(OverlayAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                var attr = attrs[0] as OverlayAttribute;
                AllOverlays[attr.ClassJobType] = Activator.CreateInstance(type) as OverlayUIComponent;
                LogHelper.Info("Load Overlay: " + attr.ClassJobType);
            }
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