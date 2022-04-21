

using System;
using System.Windows.Forms;
using System.Windows.Input;
using PropertyChanged;

namespace AEAssist.View
{
    [AddINotifyPropertyChangedInterface]
    public class HotkeyData
    {
        public Keys Key { get; set; }
        public ModifierKeys ModifierKey { get; set; }

        public string GetDisplayString()
        {
            var b = $"{Key.ToString()}";
            switch (ModifierKey)
            {
                case ModifierKeys.None:
                    return b;
                case ModifierKeys.Alt:
                    return $"A+{b}";
                case ModifierKeys.Control:
                    return $"C+{b}";
                case ModifierKeys.Shift:
                    return $"S+{b}";
                case ModifierKeys.Windows:
                    return $"Win+{b}";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Reset()
        {
            Key = Keys.None;
            ModifierKey = ModifierKeys.None;
        }
    }
}