﻿using AEAssist.Helper;
using AEAssist.View.OverlayManager;
using Buddy.Overlay;
using Buddy.Overlay.Controls;
using ff14bot.Enums;

namespace AEAssist.View.Overlay.UIComponent
{
    [Job(ClassJobType.BlackMage)]
    public class OverlayUIComponent_BlackMageOverlay2 : OverlayUIComponent
    {
        private OverlayControl _control;

        public OverlayUIComponent_BlackMageOverlay2() : base(true)
        {
        }

        public override OverlayControl Control
        {
            get
            {
                if (_control != null)
                    return _control;

                var overlayUc = new BlackMage_Overlay2();

                _control = new OverlayControl
                {
                    Name = overlayUc.GetType().Name,
                    Content = overlayUc,
                    Width = overlayUc.Width + 5,
                    Height = overlayUc.Height,
                    X = 60,
                    Y = 60,
                    AllowMoving = true,
                    AllowResizing = false
                };
                LogHelper.Info("CreateOverlay " + _control.Width + "  " + _control.Height);

                _control.MouseLeave += (sender, args) => { };

                _control.MouseLeftButtonDown += (sender, args) => { _control.DragMove(); };

                return _control;
            }
        }
    }
}