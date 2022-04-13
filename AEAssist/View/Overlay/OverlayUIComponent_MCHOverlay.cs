using Buddy.Overlay;
using Buddy.Overlay.Controls;

namespace AEAssist.View
{
    public class OverlayUIComponent_MCHOverlay : OverlayUIComponent
    {
        private OverlayControl _control;

        public OverlayUIComponent_MCHOverlay(bool isHitTestable) : base(isHitTestable)
        {
        }

        public override OverlayControl Control
        {
            get
            {
                if (_control != null)
                    return _control;

                var overlayUc = new MCHOverlayWindow();

                _control = new OverlayControl
                {
                    Name = "MCHOverlay",
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