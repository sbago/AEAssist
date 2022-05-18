using AEAssist.AI;

namespace AEAssist.View.Hotkey.BuiltinHotkeys
{
    public class Stop : IBuiltinHotkey
    {
        public void Run()
        {
            AIRoot.Instance.Stop =
                !AIRoot.Instance.Stop;
            UIHelper.RfreshCurrOverlay();
        }
    }
}