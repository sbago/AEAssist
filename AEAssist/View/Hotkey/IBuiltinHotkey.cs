namespace AEAssist.View.Hotkey
{
    public interface IBuiltinHotkey
    {
        void OnHotkeyDown();

        string GetDisplayString();
    }
}