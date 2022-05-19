using AEAssist.AI;

namespace AEAssist.View.Hotkey.BuiltinHotkeys
{
    public class Stop : IBuiltinHotkey
    {
        public void OnHotkeyDown()
        {
            AIRoot.Instance.Stop =
                !AIRoot.Instance.Stop;
            UIHelper.RfreshCurrOverlay();
        }

        public string GetDisplayString()
        {
            return Language.Instance.Combox_Hotkey_Stop;
        }
    }
}