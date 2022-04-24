using PropertyChanged;

namespace AEAssist
{
    // 所有字段,属性的type最好都是string
    [AddINotifyPropertyChangedInterface]
    public class Language
    {
        public static Language Instance = new Language();

        public string LanType = "zh-CN";
        public string LanVersion = "2";

        public string Toggle_Stop { get; set; } = "停手";
        public string Toggle_BurstOff { get; set; } = "爆发";
        public string Toggle_AOE { get; set; } = "AOE";
        public string Toggle_ShowGameLog { get; set; } = "显示GameLog(编辑时间轴必备)";
        public string Toggle_ShowDebugLog { get; set; } = "显示优先级判定Log(调试用)";
        public string Toggle_ShowBattleTime { get; set; } = "Overlay显示战斗时间";

        public string Toggle_EarlyDecisionMode { get; set; } = "提前决策模式";
        public string Toggle_StrongGCDCheckTime { get; set; } = "高威力GCD检测时间";
        public string Toggle_DoubleShroundPrefer { get; set; } = "默认双附体";

        public string Toggle_UseHotkey { get; set; } = "使用快捷键";
        public string Toggle_UseTTK { get; set; } = "使用TTK(目标濒死机制)";

        public string Toggle_Potion { get; set; } = "爆发药";
        public string Toggle_Battery { get; set; } = "电能";
        public string Toggle_Apex { get; set; } = "绝峰箭";
        public string Toggle_ActiveAttack { get; set; } = "主动攻击目标";
        public string Toggle_PreferDoubleEnshroud { get; set; } = "优先双附体";
        public string Toggle_UseHarpe { get; set; } = "勾刃";
        public string Toggle_UseTrueNorthWhenMissActionDir { get; set; } = "错位真北";
        public string Toggle_UsePoleton { get; set; } = "使用速行";
        public string Toggle_Bard_Delay1GCDToUseBuffs { get; set; } = "团辅推后1个GCD";
        public string Toggle_WildfireNoDelay { get; set; } = "野火优先";

        public string TabItem_General { get; set; } = "通用";
        public string TabItem_Hotkey { get; set; } = "快捷键";
        public string TabItem_BaseSetting { get; set; } = "基本设置";
        public string TabItem_TTKSetting { get; set; } = "TTK设置";

        public string TabItem_PotionSetting { get; set; } = "爆发药设置";

        public string TabItem_DotBlacklist { get; set; } = "Dot黑名单";

        public string TabItem_SongSetting { get; set; } = "歌曲设置";
        public string SongSettingToolTips { get; set; } = "开爆发状态下,歌曲剩多久(毫秒)后切换";
        public string SongSetting_WM { get; set; } = "旅神";
        public string SongSetting_MB { get; set; } = "贤者";
        public string SongSetting_AP { get; set; } = "军神";

        public string Btn_SwitchOverlay { get; set; } = "显示/隐藏Overlay";
        public string Btn_Reset { get; set; } = "重置";
        public string Btn_Close { get; set; } = "隐藏";

        public string Btn_CheckPotionNum { get; set; } = "检查爆发药数量";

        public string SetTriggerLine { get; set; } = "设置时间轴";

        public string ClearTriggerLine { get; set; } = "清理";
        
        public string Combox_Hotkey_Stop { get; set; } = "停手";
        public string Combox_Hotkey_BurstOff { get; set; } = "关闭爆发";

        public string Textbox_AnimationLockMs { get; set; } = "能力技动画时间";
        public string Textbox_GCDQueueMs { get; set; } = "GCD队列时间";
        public string Textbox_AbilityTimesInGCD { get; set; } = "GCD插入能力技次数";
        public string Textbox_TTK_TimeInSec { get; set; } = "X秒内死亡";
        public string Textbox_TTK_IgnoreDamage { get; set; } = "伤害阈值";

        public string Textbox_Bard_ApexArrow_SoulVoiceGauge { get; set; } = "绝峰箭能量要求";
        public string Textbox_Bard_TTK2BuffEnhancedIronJaw { get; set; } = "X秒内死亡不刷强化伶牙";
        public string Textbox_Bard_DotTimeLeft { get; set; } = "Dot剩余时间";
        public string Textbox_Bard_EmpyrealArrow { get; set; } = "提前计算九天";
        public string Label_CurrTriggerLine { get; set; } = "当前加载时间轴:";
        public string Label_DexChoosePotion { get; set; } = "敏捷爆发药";
        public string Label_StrChoosePotion { get; set; } = "力量爆发药";

        public string Label_PotionNum { get; set; } = "数量:";

        public string Label_DotblackList { get; set; } = "输入目标名字(包含)或者id:";

        public string Toggle_PreferGallow { get; set; } = "优先打缢杀";

        public string Btn_LoadTriggerLine { get; set; } = "加载文件";
        public string Btn_ClearTriggerLine { get; set; } = "清理";

        public string QQGroup { get; set; } = "Q群:    814352226";
        public string SaveSetting { get; set; } = "保存设置";

        public string Content_CoolDown { get; set; } = "倒计时";
        public string Content_CoolDown_1500 { get; set; } = "尝试特殊行为1500";
        public string Content_CoolDownFinish { get; set; } = "倒计时结束,开始战斗!";
        public string Content_Bard_PreCombat1 { get; set; } = "非战斗状态,速行未开启";
        public string Content_Bard_PreCombat2 { get; set; } = "非战斗状态,速行逻辑判断中";
        public string Content_Bard_PreCombat3 { get; set; } = "使用速行!";
        
        public string Content_Reaper_PreCombat1 { get; set; } = "非战斗状态";
        public string Content_Reaper_PreCombat2 { get; set; } = "使用收获月!";

        public string Content_AIRoot_Stoping { get; set; } = "停手中";
        public string Content_AIRoot_NoTarget { get; set; } = "未选择目标/目标不可被攻击";
        public string Content_AIRoot_CanAttack { get; set; } = "目标可被攻击,准备战斗";

        public string Content_LocalTime { get; set; } = "本地时间";
        public string Content_BattleTime { get; set; } = "战斗时间";

        public string Title_LoadTriggerLine { get; set; } = "加载时间轴";

        public string MessageLog_CountDown_BattleStart { get; set; } = "战斗开始";
        public string MessageLog_CountDown_BattleStartInTime { get; set; } = "[0-9]+";
        public string MessageLog_CountDown_CancelBattleStart { get; set; } = "取消了战斗开始";

        public string Bard_SwitchSong { get; set; } = "使用歌曲";

        public string Btn_ApplyHotkey { get; set; } = "应用快捷键";

        public string Toggle_FinalBurst { get; set; } = "资源倾泻";
    }
}