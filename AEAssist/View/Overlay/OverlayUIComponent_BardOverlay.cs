using AEAssist.DataBinding;
using Buddy.Overlay;
using Buddy.Overlay.Controls;
using ff14bot;

namespace AEAssist.View
{
    public class OverlayUIComponent_BardOverlay : OverlayUIComponent
    {
        public OverlayUIComponent_BardOverlay(bool isHitTestable) : base(isHitTestable)
        {
        }

        private OverlayControl _control;

        public override OverlayControl Control
  {
            get
            {
                if (_control != null)
                    return _control;

                var overlayUc = new BardOverlayWindow();

                _control = new OverlayControl()
                {
                    Name = "BardOverlay",
                    Content = overlayUc,
                    Width = overlayUc.DesiredSize.Width,
                    Height = overlayUc.DesiredSize.Height,
                    X = Core.OverlayManager.UnscaledOverlayWidth / 8,
                    Y = Core.OverlayManager.UnscaledOverlayHeight / 8,
                    AllowMoving = IsHitTestable,
                    AllowResizing = IsHitTestable
                };

                _control.MouseLeave += (sender, args) =>
                {

                };

                _control.MouseLeftButtonDown += (sender, args) =>
                {
                    _control.DragMove();
                };

                return _control;
            }
        }
    }
}