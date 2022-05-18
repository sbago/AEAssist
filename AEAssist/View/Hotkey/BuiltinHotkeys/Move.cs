using AEAssist.AI;

namespace AEAssist.View.Hotkey.BuiltinHotkeys
{
    public class Move : IBuiltinHotkey
    {
        public void Run()
        {
            AIRoot.Instance.Move =
                !AIRoot.Instance.Move;
            UIHelper.RfreshCurrOverlay();
        }
    }
}