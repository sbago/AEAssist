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
using AEAssist.Gamelog;
using AEAssist.Helper;
using AEAssist.View;
using AEAssist.View.Overlay;
using TreeSharp;

namespace AEAssist
{
    public class Entry
    {
        public void Initialize()
        {
            LogHelper.Debug("Init....Version " + ConstValue.ProjectVersion);
            try
            {
                SettingMgr.Instance.InitSetting();
                DataHelper.Init();
                RotationManager.Instance.Init();
                HookBehaviors();
                SettingMgr.GetSetting<HotkeySetting>().RegisHotkey();
                AEGamelogManager.Instance.Init();
                OverlayManager.Instance.Init();
                PotionHelper.Init();
                // PotionHelper.DebugAllItems();
                GUIHelper.ShowInfo("插件初始化完成, 请检查ATB是否开启!");
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
                GUIHelper.ShowInfo("插件初始化失败, 请联系作者!");
            }
            LogHelper.Info("Initialized!");
        }


        private static MainWindow _form;
        private static MainWindow Form
        {
            get
            {
                if (_form != null) return _form;
                _form = new MainWindow();
                _form.Closed += (sender, args) =>
                {
                    _form = null;
                };
                return _form;
            }
        }
        
        private static TriggerLineWindow _triggerLineWindow;
        public static TriggerLineWindow TriggerLineWindow
        {
            get
            {
                if (_triggerLineWindow != null) return _triggerLineWindow;
                _triggerLineWindow = new TriggerLineWindow();
                _triggerLineWindow.Closed += (sender, args) =>
                {
                    _triggerLineWindow = null;
                };
                return _triggerLineWindow;
            }
        }
        

        private ClassJobType CurrentJob { get; set; }
        private ushort CurrentZone { get; set; }

        public void Pulse()
        {
            OverlayManager.Instance.SwitchJob();
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
