using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using UserControl = System.Windows.Controls.UserControl;

namespace AEAssist.View
{
    public partial class HotkeyControl : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(HotkeyControl), new UIPropertyMetadata("Hotkey"));
        public static readonly DependencyProperty KeySettingProperty = DependencyProperty.Register("KeySetting", typeof(Keys), typeof(HotkeyControl), new PropertyMetadata(Keys.None, OnKeyChanged));
        public static readonly DependencyProperty ModKeySettingProperty = DependencyProperty.Register("ModKeySetting", typeof(ModifierKeys), typeof(HotkeyControl), new PropertyMetadata(ModifierKeys.None, OnModKeyChanged));

        private static void OnKeyChanged(DependencyObject keySetting, DependencyPropertyChangedEventArgs eventArgs)
        {

        }

        private static void OnModKeyChanged(DependencyObject keySetting, DependencyPropertyChangedEventArgs eventArgs)
        {

        }

        public HotkeyControl()
        {
            InitializeComponent();
            PreviewKeyDown += OnPreviewKeyDown;
            LostFocus += OnLostFocus;
        }

        private void OnLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            // Re - Registering Code

        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string HkText => ModKeySetting + " + " + KeySetting;

        public Keys KeySetting
        {
            get => (Keys)GetValue(KeySettingProperty);
            set => SetValue(KeySettingProperty, value);
        }

        public ModifierKeys ModKeySetting
        {
            get => (ModifierKeys)GetValue(ModKeySettingProperty);
            set => SetValue(ModKeySettingProperty, value);
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            // The text box grabs all input.
            e.Handled = true;

            // Fetch the actual shortcut key.
            var key = (e.Key == Key.System ? e.SystemKey : e.Key);

            switch (key)
            {
                case Key.Escape:
                    TxtHk.Text = "None + None";
                    ModKeySetting = ModifierKeys.None;
                    KeySetting = Keys.None;
                    return;
                case Key.LeftShift:
                case Key.RightShift:
                case Key.LeftCtrl:
                case Key.RightCtrl:
                case Key.LeftAlt:
                case Key.RightAlt:
                case Key.LWin:
                case Key.RWin:
                    return;
            }

            // Ignore modifier keys.
            
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                ModKeySetting = ModifierKeys.Control;
            }
            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0)
            {
                ModKeySetting = ModifierKeys.Shift;
            }
            if ((Keyboard.Modifiers & ModifierKeys.Alt) != 0)
            {
                ModKeySetting = ModifierKeys.Alt;
            }

            if (Keyboard.Modifiers == 0)
            {
                ModKeySetting = ModifierKeys.None;
            }
            
            var newKey = (Keys)KeyInterop.VirtualKeyFromKey(key);
            KeySetting = newKey;
            // Update the text box.
            TxtHk.Text =   $"{ModKeySetting.ToString()} + {key.ToString()}";
        }
    }
}
