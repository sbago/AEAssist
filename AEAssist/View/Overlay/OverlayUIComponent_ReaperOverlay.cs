using AEAssist;
using AEAssist.View.Overlay;
using Buddy.Overlay;
using Buddy.Overlay.Controls;
using ff14bot;

namespace AEAssist.View
{
    public class OverlayUIComponent_ReaperOverlay : OverlayUIComponent
    {
        public OverlayUIComponent_ReaperOverlay(bool isHitTestable) : base(isHitTestable)
        {
        }

        private OverlayControl _control;

        public override OverlayControl Control
        {
            get
            {
                if (_control != null)
                    return _control;

                var overlayUc = new ReaperOverlay();

                _control = new OverlayControl()
                {
                    Name = "ReaperOverlay",
                    Content = overlayUc,
                    Width = overlayUc.Width + 5,
                    Height = overlayUc.Height,
                    X = 60,
                    Y = 60,
                    AllowMoving = true,
                    AllowResizing = false,
                };
                LogHelper.Info("CreateOverlay " + _control.Width + "  " + _control.Height);

                _control.MouseLeave += (sender, args) => { };

                _control.MouseLeftButtonDown += (sender, args) => { _control.DragMove(); };

                return _control;
            }
        }
    }
}