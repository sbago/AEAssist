using System;
using System.Collections.Generic;
using AEAssist.Helper;
using Buddy.Overlay;
using ff14bot;
using ff14bot.Enums;

namespace AEAssist.View.OverlayManager
{
    public class OverlayManager
    {
        public static OverlayManager Instance = new OverlayManager();

        private readonly Dictionary<ClassJobType, List<OverlayUIComponent>> AllOverlays =
            new Dictionary<ClassJobType, List<OverlayUIComponent>>();

        private ClassJobType _classJobType;

        public List<OverlayUIComponent> lastOverlay;

        public void Init()
        {
            var baseType = typeof(OverlayUIComponent);
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;
                if (!baseType.IsAssignableFrom(type))
                    continue;
                var attrs = type.GetCustomAttributes(typeof(JobAttribute), false);
                if (attrs.Length == 0) continue;

                var attr = attrs[0] as JobAttribute;
                if(!AllOverlays.ContainsKey(attr.ClassJobType))
                    AllOverlays.Add(attr.ClassJobType, new List<OverlayUIComponent>());
                AllOverlays[attr.ClassJobType].Add(Activator.CreateInstance(type) as OverlayUIComponent);
            }
        }

        public void SwitchJob()
        {
            if (!Core.OverlayManager.IsActive)
                return;
            var currJob = Core.Me.CurrentJob;
            if (currJob == _classJobType)
                return;

            Close();
            Open();
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
                Open();
            }
        }

        void Open()
        {
            var currJob = Core.Me.CurrentJob;
            _classJobType = currJob;
            if (AllOverlays.TryGetValue(currJob, out var window))
            {
                foreach (var v in window)
                {
                    Core.OverlayManager.AddUIComponent(v);
                }
                lastOverlay = window;
            }
        }

        public void Close()
        {
            if (lastOverlay != null)
            {
                foreach (var v in lastOverlay)
                {
                    Core.OverlayManager.RemoveUIComponent(v);
                }
                // v.Value.Dispatcher.Invoke(v.Value.Hide);
                lastOverlay = null;
            }
        }
    }
}