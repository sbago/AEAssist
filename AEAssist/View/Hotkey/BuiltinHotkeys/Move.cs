using AEAssist.AI;

namespace AEAssist.View.Hotkey.BuiltinHotkeys
{
    public class Move : IBuiltinHotkey
    {
        public void OnHotkeyDown()
        {
            AIRoot.Instance.Move =
                !AIRoot.Instance.Move;
            UIHelper.RfreshCurrOverlay();
        }

        public string GetDisplayString()
        {
            return "Move";
        }
    }
}