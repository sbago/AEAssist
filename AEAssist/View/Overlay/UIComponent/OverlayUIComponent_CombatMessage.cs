using Buddy.Overlay;
using Buddy.Overlay.Controls;
using ff14bot;
using ff14bot.Enums;

namespace AEAssist.View.Overlay.UIComponent
{
    public class OverlayUIComponent_CombatMessage : OverlayUIComponent
    {
        public OverlayUIComponent_CombatMessage() : base(true)
        {
        }

        private OverlayControl _control;

        public override OverlayControl Control
        {
            get
            {
                if (_control != null)
                    return _control;

                var overlayUc = new CombatMessageOverlay();

                // double width = BaseSettings.Instance.CombatMessageOverlayWidth;
                // double height = BaseSettings.Instance.CombatMessageOverlayHeight;
                // double posX = BaseSettings.Instance.CombatMessageOverlayPosX;
                // double posY = BaseSettings.Instance.CombatMessageOverlayPosY;
                // if (width < 0 || height < 0 || posX < 0 || posY < 0)
                // {
                //     /* Default (or invalid) values - take a reasonable guess where it should go */
                //     width = Core.OverlayManager.UnscaledOverlayWidth / 2;
                //     height = Core.OverlayManager.UnscaledOverlayHeight / 20;
                //     posX = Core.OverlayManager.UnscaledOverlayWidth / 8;
                //     posY = Core.OverlayManager.UnscaledOverlayHeight / 8;
                // }

                _control = new OverlayControl()
                {
                    Name = "AEAssistCombatTextOverlay",
                    Content = overlayUc,
                    Width = overlayUc.Width + 5,
                    Height = overlayUc.Height,
                    X = SettingMgr.GetSetting<GeneralSettings>().OverlayPos_X,
                    Y =  SettingMgr.GetSetting<GeneralSettings>().OverlayPos_Y,
                    AllowMoving = IsHitTestable,
                    AllowResizing = IsHitTestable
                };

                _control.MouseLeave += (sender, args) =>
                {
                    if (IsHitTestable)
                    {
                        SettingMgr.GetSetting<GeneralSettings>().OverlayPos_X = _control.X;
                        SettingMgr.GetSetting<GeneralSettings>().OverlayPos_Y = _control.Y;
                    }
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