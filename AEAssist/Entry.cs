//using Clio.Utilities.Collections;

using System;
using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Gamelog;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using AEAssist.View;
using AEAssist.View.OverlayManager;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Managers;
using TreeSharp;

namespace AEAssist
{
    public class Entry
    {
        private static MainWindow _form;

        private static MainWindow Form
        {
            get
            {
                if (_form != null) return _form;
                _form = new MainWindow();
                _form.Closed += (sender, args) => { _form = null; };
                return _form;
            }
        }

        private ClassJobType CurrentJob { get; set; }
        private ushort CurrentZone { get; set; }

        public void Initialize()
        {
            LogHelper.Info("Init....Version " + ConstValue.ProjectVersion);
            try
            {
                SettingMgr.Instance.InitSetting();
                LanguageHelper.Init();
                DataHelper.Init();
                RotationManager.Instance.Init();
                HookBehaviors();
                SettingMgr.GetSetting<HotkeySetting>().RegisHotkey();
                SettingMgr.GetSetting<HotkeySetting>().ResetHotkeyName();
                AEGamelogManager.Instance.Init();
                OverlayManager.Instance.Init();
                PotionHelper.Init();
                // PotionHelper.DebugAllItems();
                AIRoot.Instance.Init();
                AIMgrs.Instance.Init();


                GUIHelper.ShowInfo("Initialized");
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
            }

            LogHelper.Info("Initialized!");
        }

        public void Pulse()
        {
            RotationManager.Instance.CheckChangeJob();
            OverlayManager.Instance.SwitchJob();
            WorldHelper.CheckZone();
            GamelogManager.Pulse();
        }

        public void Shutdown()
        {
            LogHelper.Info("...ShutDown");
            AEGamelogManager.Instance.Close();
            OverlayManager.Instance.Close();
            SettingMgr.GetSetting<HotkeySetting>().UnRegisterKey();
        }

        public void OnButtonPress()
        {
            Form.Show();
        }


        #region Behavior Composites

        public void HookBehaviors()
        {
            // 重新hook去掉Loader的反射调用用来提高性能
            TreeHooks.Instance.ReplaceHook("Rest", RestBehavior);
            TreeHooks.Instance.ReplaceHook("PreCombatBuff", PreCombatBuffBehavior);
            TreeHooks.Instance.ReplaceHook("Pull", PullBehavior);
            TreeHooks.Instance.ReplaceHook("Heal", HealBehavior);
            TreeHooks.Instance.ReplaceHook("CombatBuff", CombatBuffBehavior);
            TreeHooks.Instance.ReplaceHook("Combat", CombatBehavior);
            TreeHooks.Instance.ReplaceHook("PullBuff", PullBuffBehavior);
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

        public Composite PullBuffBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.PullBuff()); }
        }

        #endregion Behavior Composites
    }
}