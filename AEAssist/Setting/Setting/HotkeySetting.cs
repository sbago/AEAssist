using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using AEAssist.AI;
using ff14bot.Managers;
using Newtonsoft.Json;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class HotkeySetting : IBaseSetting
    {
        private bool _UseHotkey = true;

        [JsonIgnore] private List<Hotkey> Hotkeys;

        public HotkeySetting()
        {
            Reset();
        }

        public string StopBtnName { get; set; }
        public string CloseBuffBtnName { get; set; }

        public string StopKey { get; set; }
        public string CloseBuffKey { get; set; }

        public bool UseHotkey
        {
            get => _UseHotkey;
            set
            {
                _UseHotkey = value;
                RegisHotkey();
                ResetHotkeyName();
            }
        }

        public void Reset()
        {
            StopKey = Key.F8.ToString();
            CloseBuffKey = Key.F9.ToString();
            UseHotkey = true;
            ResetHotkeyName();
        }

        public void ResetHotkeyName()
        {
            if (UseHotkey)
            {
                StopBtnName = $"停手 {StopKey}";
                CloseBuffBtnName = $"关闭爆发 {CloseBuffKey}";
            }
            else
            {
                StopBtnName = "停手";
                CloseBuffBtnName = "关闭爆发";
            }
        }

        public void RegisHotkey()
        {
            try
            {
                if (Hotkeys == null)
                    Hotkeys = new List<Hotkey>();
                UnRegisterKey();
                Hotkeys.Clear();
                // Hotkeys.Add(HotkeyManager.Register("StartCoundDown5s", Keys.F8, ModifierKeys.None,
                //     v => { CountDownHandler.Instance.StartCountDown(); }));

                // Hotkeys.Add(HotkeyManager.Register("BattleStartNow", Keys.F9, ModifierKeys.None,
                //     v => { CountDownHandler.Instance.StartNow(); }));
                if (StopKey == null || CloseBuffKey == null)
                    Reset();
                //  LogHelper.Info("Hotkey_Stop: " + this.StopKey);
                //  LogHelper.Info("Hotkey_CloseBuff: " + this.CloseBuffKey);

                if (!UseHotkey)
                    return;

                var stopKey = (Keys) Enum.Parse(typeof(Keys), StopKey);
                var closeBuffKey = (Keys) Enum.Parse(typeof(Keys), CloseBuffKey);

                Hotkeys.Add(HotkeyManager.Register("BattleStop", stopKey, ModifierKeys.None, v =>
                {
                    AIRoot.Instance.Stop =
                        !AIRoot.Instance.Stop;
                }));

                Hotkeys.Add(HotkeyManager.Register("ControlBuff", closeBuffKey, ModifierKeys.None, v =>
                {
                    AIRoot.Instance.CloseBuff =
                        !AIRoot.Instance.CloseBuff;
                }));
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
            }
        }

        public void UnRegisterKey()
        {
            if (Hotkeys == null)
                return;
            foreach (var v in Hotkeys) HotkeyManager.Unregister(v);
        }
    }
}