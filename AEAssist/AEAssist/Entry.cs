//using Clio.Utilities.Collections;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using AEAssist;
using AEAssist.AI;
using AEAssist.Helper;
using TreeSharp;

namespace AEAssist
{
    public class Entry
    {
        private Entry()
        {
        }

        public static Entry Instance { get; } = new Entry();

        public List<Hotkey> Hotkeys = new List<Hotkey>();

        public void Initialize()
        {
            LogHelper.Debug("Init....");
            DataHelper.Init();
            GUIHelper.OpenOverlay();
            HookBehaviors();
            RegisHotkey();
           // PotionHelper.DebugAllItems();
            LogHelper.Info("Initialized!");
        }

        private void RegisHotkey()
        {
            Hotkeys.Clear();
            Hotkeys.Add(HotkeyManager.Register("StartCoundDown5s", Keys.F8, ModifierKeys.None,
                v => { CountDownHandler.Instance.StartCountDown(); }));

            Hotkeys.Add(HotkeyManager.Register("BattleStartNow", Keys.F9, ModifierKeys.None,
                v => { CountDownHandler.Instance.StartNow(); }));

            Hotkeys.Add(HotkeyManager.Register("BattleStop", Keys.F10, ModifierKeys.None, v =>
            {
                GUIHelper.OpenOverlay();
                GUIHelper.Overlay.RefreshCheckBox1(!AIRoot.Instance.Stop);
            }));
            
            Hotkeys.Add(HotkeyManager.Register("ControlBuff", Keys.F11, ModifierKeys.None, v =>
            {
                GUIHelper.OpenOverlay();
                GUIHelper.Overlay.SwitchBuffControlState();
            }));
            
            Hotkeys.Add(HotkeyManager.Register("PotionControl", Keys.F12, ModifierKeys.None, v =>
            {
                GUIHelper.OpenOverlay();
                GUIHelper.Overlay.SiwtchPotionControl();
            }));

        }

        private ClassJobType CurrentJob { get; set; }
        private ushort CurrentZone { get; set; }

        public void Pulse()
        {
           // LogHelper.Debug("Pulse....");

        }

        public void Shutdown()
        {
            LogHelper.Debug("Shutdown....");
            GUIHelper.CloseOverlay();
            foreach (var v in Hotkeys)
            {
                HotkeyManager.Unregister(v);
            }
        }

        public void OnButtonPress()
        {
            GUIHelper.OpenGUI();
        }
        

        #region Behavior Composites

        public void HookBehaviors()
        {
            TreeHooks.Instance.ReplaceHook("Rest", RestBehavior);
            TreeHooks.Instance.ReplaceHook("PreCombatBuff", PreCombatBuffBehavior);
            TreeHooks.Instance.ReplaceHook("Pull", PullBehavior);
            TreeHooks.Instance.ReplaceHook("Heal", HealBehavior);
            TreeHooks.Instance.ReplaceHook("CombatBuff", CombatBuffBehavior);
            TreeHooks.Instance.ReplaceHook("Combat", CombatBehavior);
        }

        public Composite RestBehavior
        {
            get
            {
                return
                    new ActionRunCoroutine(ctx => RotationManager.Instance.Rest());
            }
        }

        public Composite PreCombatBuffBehavior
        {
            get
            {
                return
                    new ActionRunCoroutine(ctx => RotationManager.Instance.PreCombatBuff());
            }
        }

        public Composite PullBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.Pull()); }
        }

        public Composite HealBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.Heal()); }
        }

        public Composite CombatBuffBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.CombatBuff()); }
        }

        public Composite CombatBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.Combat()); }
        }

        #endregion Behavior Composites
    }
}
