using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AEAssist.AI;
using AEAssist;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.View;
using AEAssist.View.Hotkey;
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
        
        public string MoveBtnName { get; set; }
        
        public string CloseBuffBtnName { get; set; }

        public HotkeyData Hotkey_Stop { get; set; } = new HotkeyData();
        
        public HotkeyData Hotkey_Move { get; set; } = new HotkeyData();
        
        public HotkeyData Hotkey_Burst { get; set; } = new HotkeyData();

        public HotkeyData Hotkey_ArmLength_Surecast { get; set; } = new HotkeyData();


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
            Hotkey_Stop.Reset();
            Hotkey_Burst.Reset();
            Hotkey_ArmLength_Surecast.Reset();
            UseHotkey = true;
            ResetHotkeyName();
        }

        public void OnLoad()
        {
            
        }

        public void ResetHotkeyName()
        {
            if (UseHotkey)
            {
                StopBtnName = $"{Language.Instance.Toggle_Stop} [{Hotkey_Stop.GetDisplayString()}]";
                MoveBtnName = $"{Language.Instance.Toggle_Move} [{Hotkey_Move.GetDisplayString()}]";
                CloseBuffBtnName = $"{Language.Instance.Toggle_BurstOff} [{Hotkey_Burst.GetDisplayString()}]";
            }
            else
            {
                StopBtnName = Language.Instance.Toggle_Stop;
                MoveBtnName = Language.Instance.Toggle_Move;
                CloseBuffBtnName = Language.Instance.Toggle_BurstOff;
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
                if (Hotkey_Stop == null || Hotkey_Burst == null || Hotkey_ArmLength_Surecast == null)
                    Reset();
                //  LogHelper.Info("Hotkey_Stop: " + this.StopKey);
                //  LogHelper.Info("Hotkey_CloseBuff: " + this.CloseBuffKey);

                if (!UseHotkey)
                    return;

                if (Hotkey_Stop.Key != Keys.None)
                    Hotkeys.Add(HotkeyManager.Register("AEAssist_BattleStop", Hotkey_Stop.Key, Hotkey_Stop.ModifierKey,
                        v =>
                        {
                            AIRoot.Instance.Stop =
                                !AIRoot.Instance.Stop;
                            UIHelper.RfreshCurrOverlay();
                        }));
                if (Hotkey_Move.Key != Keys.None)
                    Hotkeys.Add(HotkeyManager.Register("AEAssist_Move", Hotkey_Move.Key, Hotkey_Move.ModifierKey,
                        v =>
                        {
                            AIRoot.Instance.Move =
                                !AIRoot.Instance.Move;
                            UIHelper.RfreshCurrOverlay();
                        }));
                if (Hotkey_Burst.Key != Keys.None)
                    Hotkeys.Add(HotkeyManager.Register("AEAssist_Burst", Hotkey_Burst.Key, Hotkey_Burst.ModifierKey,
                        v =>
                        {
                            AIRoot.Instance.CloseBurst =
                                !AIRoot.Instance.CloseBurst;
                            UIHelper.RfreshCurrOverlay();
                        }));
                if (Hotkey_ArmLength_Surecast.Key != Keys.None)
                    Hotkeys.Add(HotkeyManager.Register("AEAssist_ArmLength_Surecast", Hotkey_ArmLength_Surecast.Key,
                        Hotkey_ArmLength_Surecast.ModifierKey, v =>
                        {
                            if (ActionManager.HasSpell(SpellsDefine.ArmsLength))
                                AIRoot.GetBattleData<BattleData>().NextAbilitySpellId =
                                    SpellsDefine.ArmsLength.GetSpellEntity();
                            else
                                AIRoot.GetBattleData<BattleData>().NextAbilitySpellId =
                                    SpellsDefine.Surecast.GetSpellEntity();
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