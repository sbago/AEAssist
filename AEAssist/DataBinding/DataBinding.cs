﻿using System;
using System.Windows;
using System.Windows.Media;
using AEAssist.AI;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using PropertyChanged;
using QuickGraph;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class DataBinding
    {
        private static DataBinding _instance;

        public TriggerLine CurrTriggerLine;


        public static DataBinding Instance => _instance ?? (_instance = new DataBinding());

        public bool Burst
        {
            get;
            set;
            // var msg = !_closeBuff ? "Burst On" : "Burst Off";
            // GUIHelper.ShowToast(msg,2000);
        } = true;

        public bool FinalBurst { get; set; }

        public bool Stop { get; set; }

        public bool Move { get; set; }

        public bool Pull { get; set; }

        public bool UseTrueNorth { get; set; }

        public bool UseAOE { get; set; } = true;

        public bool UseBattery { get; set; } = true;

        public bool UseHeat { get; set; } = true;

        public string TimeStr { get; set; }

        public bool EarlyDecisionMode { get; set; }


        public GeneralSettings GeneralSettings { get; } = SettingMgr.GetSetting<GeneralSettings>();
        public BardSettings BardSettings => SettingMgr.GetSetting<BardSettings>();
        public ReaperSettings ReaperSettings => SettingMgr.GetSetting<ReaperSettings>();

        public MCHSettings MCHSettings => SettingMgr.GetSetting<MCHSettings>();

        public SamuraiSettings SamuraiSettings => SettingMgr.GetSetting<SamuraiSettings>();

        public SageSettings SageSettings => SettingMgr.GetSetting<SageSettings>();
        public WhiteMageSettings WhiteMageSettings => SettingMgr.GetSetting<WhiteMageSettings>();
        public DancerSettings DancerSettings => SettingMgr.GetSetting<DancerSettings>();
        public MonkSettings MonkSettings => SettingMgr.GetSetting<MonkSettings>();
        public SMNSettings SMNSettings => SettingMgr.GetSetting<SMNSettings>();
        public GunBreakerSettings GunBreakerSettings => SettingMgr.GetSetting<GunBreakerSettings>();
        public DebugCenter DebugCenter => DebugCenter.Intance;
        public MeleePosition MeleePosition => MeleePosition.Intance;

        public HotkeySetting HotkeySetting => SettingMgr.GetSetting<HotkeySetting>();
        public AEAssist.View.Hotkey.HotkeyManager HotkeyManager => AEAssist.View.Hotkey.HotkeyManager.Instance;
        public Language Language => Language.Instance;

        public string TriggerLineName { get; set; } = "NULL";

        #region MCH

        public bool Wildfire { get; set; }

        #endregion



        public bool OverlayVisibility { get; set; } = true;
        public void ChangeTriggerLine(TriggerLine line)
        {
            if (line != null && !TriggerLineSwitchHelper.CheckTriggerLine(line, out var str))
            {
                MessageBox.Show(str);
                return;
            }

            var oldName = TriggerLineName;
            CurrTriggerLine = line;
            TriggerLineName = "NULL";
            if (CurrTriggerLine != null)
                TriggerLineName = line.Name;

            var notice = $"Change TriggerLine: {oldName}==>{TriggerLineName}";
            LogHelper.Info(notice);
            MessageBox.Show(notice);
        }

        public void Reset()
        {
            Burst = true;
            Stop = false;
            Move = false;
            UseApex = true;
            UseDot = true;
            UseSoulGauge = true;
            UseAOE = true;
            UseFlourish = true;
            LazyOn = false;
            TimeStr = "";
            UseBattery = true;
            UseHeat = true;
            UseSong = true;
            UseEnshroud = true;
            FinalBurst = false;
            UseMeikyoShisui = true;
            SageSettings.LucidDreamingToggle = true;
            Wildfire = true;
            SMNReset();
        }


        public void Update()
        {
            if (GeneralSettings.ShowBattleTime)
                TimeStr =
                    $"{Language.Instance.Content_BattleTime}:  {AIRoot.GetBattleData<BattleData>().CurrBattleTimeInMs / 1000}";
            else
                TimeStr = $"{Language.Instance.Content_LocalTime}:  {DateTime.Now:hh:mm:ss}";
        }

        public void ApplyScale()
        {
            // ScaleTransform.ScaleX = SettingMgr.GetSetting<GeneralSettings>().OverlayScale_X;
            // ScaleTransform.ScaleY = SettingMgr.GetSetting<GeneralSettings>().OverlayScale_Y;
        }


        #region Bard

        public bool UseDot { get; set; } = true;

        public bool UseApex { get; set; } = true;
        public bool Bloodletter { get; set; } = true;
        public bool UseSong { get; set; } = true;

        #endregion

        #region Reaper

        public bool UseSoulGauge { get; set; } = true;
        public bool UseEnshroud { get; set; } = true;

        #endregion

        #region Samurai

        public bool UseMeikyoShisui { get; set; } = true;

        #endregion

        #region Dancer

        public bool UseFlourish { get; set; } = true;

        #endregion

        #region Monk

        public bool LazyOn { get; set; } = false;


        #endregion

        #region SMN

        public bool Crimson { get; set; } = true;

        public bool SaveInstantSpells { get; set; } = false;
        #endregion
        public void SMNReset()
        {
            Crimson = true;
            SaveInstantSpells = false;
        }
        #region GNB
        public bool GNBOpen { get; set; }=true;
        public bool GNBRoughDivide { get; set; } = true;
        #endregion
    }
}