﻿using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class Language
    {
        public static Language Instance = new Language();


        public string LanType = "default";
        public string LanVersion = "0";

        public Language()
        {
            var type = typeof(Language);
            var propertys = type.GetProperties();
            foreach (var v in propertys)
            {
                if (v.PropertyType != typeof(string))
                    continue;
                if (v.Name.Contains("_"))
                    v.SetValue(this, v.Name.Split('_')[1]);
                else
                    v.SetValue(this, v.Name);
            }
        }

        public string Toggle_Stop { get; set; }
        public string Toggle_Move { get; set; }
        public string Toggle_BurstOff { get; set; }
        public string Toggle_AOE { get; set; }
        public string Toggle_ShowGameLog { get; set; }
        public string Toggle_ShowDebugLog { get; set; }
        public string Toggle_ShowBattleTime { get; set; }
        
        public string Toggle_CombatMessageOverlay { get; set; }

        public string Toggle_NextAbilityFirst { get; set; }
        public string Toggle_AutoInterrupt { get; set; }
        public string Toggle_AutoFinalBurst { get; set; }
        public string Toggle_AutoSwitchTriggerLine { get; set; }
        public string Toggle_KnockAgainstFirst { get; set; }

        public string Toggle_UseMeikyoShisui { get; set; }

        public string Button_ReloadTriggerLine { get; set; }

        public string Toggle_EarlyDecisionMode { get; set; }
        public string Toggle_StrongGCDCheckTime { get; set; }
        public string Toggle_DoubleShroundPrefer { get; set; }

        public string Toggle_UseHotkey { get; set; }
        public string Toggle_UseTTK { get; set; }

        public string Toggle_Potion { get; set; }
        public string Toggle_Battery { get; set; }
        
        public string Toggle_Heat { get; set; }
        
        public string Toggle_Apex { get; set; }
        public string Toggle_ActiveAttack { get; set; }
        public string Toggle_PreferDoubleEnshroud { get; set; }

        #region Casters
        
        // Casters Roles Defaults
        public string Toggle_LucidDreaming { get; set; }
        public string Toggle_SwiftRes { get; set; }
        public string Toggle_Esuna { get; set; }
        public string Toggle_SureCast { get; set; }
        public string Toggle_SwiftCast { get; set; }
        public string Heal { get; set; }
        public string UseCDPull { get; set; }

        #endregion


        public string Toggle_UseEnshroud { get; set; }
        public string Toggle_UseHarpe { get; set; }
        public string Toggle_UseTrueNorthWhenMissActionDir { get; set; }
        public string Toggle_UsePoleton { get; set; }
        public string Toggle_Bard_Delay1GCDToUseBuffs { get; set; }
        public string Toggle_WildfireNoDelay { get; set; }
        public string Toggle_Wildfire { get; set; }

        public string TabItem_General { get; set; }
        public string TabItem_Hotkey { get; set; }
        public string TabItem_BaseSetting { get; set; }
        public string TabItem_TTKSetting { get; set; }

        public string TabItem_PotionSetting { get; set; }

        public string TabItem_DotBlacklist { get; set; }

        public string TabItem_TriggerLine { get; set; }

        public string TabItem_SongSetting { get; set; }
        public string SongSettingToolTips { get; set; }
        public string SongSetting_WM { get; set; }
        public string SongSetting_MB { get; set; }
        public string SongSetting_AP { get; set; }

        public string Btn_SwitchOverlay { get; set; }
        public string Btn_Reset { get; set; }
        public string Btn_Close { get; set; }

        public string Btn_CheckPotionNum { get; set; }

        public string SetTriggerLine { get; set; }

        public string ClearTriggerLine { get; set; }

        public string Combox_Hotkey_Stop { get; set; }
        public string Combox_Hotkey_Move { get; set; }
        public string Combox_Hotkey_BurstOff { get; set; }

        public string Combox_Hotkey_EnAvant { get; set; }

        public string Combox_Hotkey_ArmLength { get; set; }
        public string Combox_Hotkey_Surecast { get; set; }

        public string Textbox_AnimationLockMs { get; set; }
        public string Textbox_GCDQueueMs { get; set; }
        public string Textbox_AbilityTimesInGCD { get; set; }
        public string Textbox_TTK_TimeInSec { get; set; }
        public string Textbox_TTK_IgnoreDamage { get; set; }

        public string Textbox_Bard_ApexArrow_SoulVoiceGauge { get; set; }
        public string Textbox_Bard_TTK2BuffEnhancedIronJaw { get; set; }
        public string Textbox_Bard_DotTimeLeft { get; set; }
        public string Textbox_Bard_EmpyrealArrow { get; set; }
        public string Textbox_BardApexWaitBuffs { get; set; }
        public string Label_CurrTriggerLine { get; set; }
        public string Label_DexChoosePotion { get; set; }
        public string Label_StrChoosePotion { get; set; }
        
        public string Label_MindChoosePotion { get; set; }
        public string Label_ChooseOpener { get; set; }
        
        public string Label_ChooseResPriority { get; set; }

        public string Label_PotionNum { get; set; }

        public string Label_DotblackList { get; set; }

        public string Toggle_PreferGallow { get; set; }

        public string Btn_LoadTriggerLine { get; set; }
        public string Btn_ClearTriggerLine { get; set; }

        public string QQGroup { get; set; }
        public string SaveSetting { get; set; }

        public string Content_ResetSetting { get; set; }
        public string Content_CoolDown { get; set; }
        public string Content_CoolDown_1500 { get; set; }
        public string Content_CoolDownFinish { get; set; }
        public string Content_Bard_PreCombat1 { get; set; }
        public string Content_Bard_PreCombat2 { get; set; }
        public string Content_Bard_PreCombat3 { get; set; }

        public string Content_Reaper_PreCombat1 { get; set; }
        public string Content_Reaper_PreCombat2 { get; set; }

        public string Content_AIRoot_Stoping { get; set; }
        public string Content_AIRoot_NoTarget { get; set; }
        public string Content_AIRoot_CanAttack { get; set; }

        public string Content_LocalTime { get; set; }
        public string Content_BattleTime { get; set; }

        public string Title_LoadTriggerLine { get; set; }

        public string MessageLog_CountDown_BattleStart { get; set; }
        public string MessageLog_CountDown_BattleStartInTime { get; set; }
        public string MessageLog_CountDown_CancelBattleStart { get; set; }

        public string Bard_SwitchSong { get; set; }

        public string Btn_ApplyHotkey { get; set; }

        public string Toggle_FinalBurst { get; set; }
        public string Toggle_Bloodletter { get; set; }

        public string Label_OverlayScale { get; set; }
        
        public string Label_CombatMessageFontSize { get; set; }
        
        public string Textbox_Sage_DotTimeLeft { get; set; }

        public string Textbox_WhiteMage_DotTimeLeft { get; set; }

        public string TextBox_Lucid_Dreaming { get; set; }
        public string TextBox_Tetragrammaton { get; set; }
        public string TextBox_DivineBenison { get; set; }
        public string TextBox_Regen { get; set; }
        public string TextBox_AfflatusSolace { get; set; }
        
        public string ToolTip_Bard_FinalBurst { get; set; }
        public string ToolTip_Bard_Bloodletter { get; set; }
        public string ToolTip_Bard_Burst { get; set; }
        
        public string ToolTip_MCH_FinalBurst { get; set; }
        public string ToolTip_MCH_WildFireFirst { get; set; }
        public string ToolTip_MCH_Burst { get; set; }
        
        public string ToolTip_RPR_Burst { get; set; }
        public string ToolTip_RPR_DoubleEnshroundPrefer{ get; set; }

        public string ToolTip_SMN_Burst { get; set; }

        public string ToolTip_SMN_FinalBurst { get; set; }

        public string Toggle_SMN_SaveInstantSpells { get; set; }
        public string ToolTip_SMN_SaveInstantSpells { get; set;}
        public string Textbox_SMN_SwiftcastOption { get; set; }
        public string Toggle_SMN_Crimson { get; set; }
        #region GNB
        public string Toggle_GNB_Open { get; set; }
        public string Toggle_GNB_RoughDivide { get; set; }
        #endregion

    }
}