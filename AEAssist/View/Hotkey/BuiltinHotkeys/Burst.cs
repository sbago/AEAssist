using AEAssist.AI;

namespace AEAssist.View.Hotkey.BuiltinHotkeys
{
    public class Burst : IBuiltinHotkey
    {
        public void OnHotkeyDown()
        {
            AIRoot.Instance.CloseBurst =
                !AIRoot.Instance.CloseBurst;
            UIHelper.RfreshCurrOverlay();
        }
    }
}