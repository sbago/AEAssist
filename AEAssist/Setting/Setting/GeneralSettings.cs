using System.Collections.Generic;
using AEAssist.Annotations;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class GeneralSettings : IBaseSetting
    {
        public GeneralSettings()
        {
            Reset();
        }

        public int UserLatencyOffset { get; set; } // 玩家预计延迟
        [ValueRange(300, 700)] public int ActionQueueMs { get; set; } // 提前多久开始准备释放技能
        [ValueRange(1, 2)] public int MaxAbilityTimsInGCD { get; set; } // 一个GCD内最多插几个能力技
        public int AnimationLockMs { get; set; }

        public bool EarlyDecisionMode { get; set; } // 提前决策模式,镰刀不推荐,对起手有影响

        public bool OpenTTK { get; set; } // 启动TTK
        [ValueRange(1, 30)] public int TimeToKill_TimeInSec { get; set; } //ttk 预计多少秒死亡
        [ValueRange(200000, 1000000)] public int TTK_IgnoreDamage { get; set; } // 大于30W的伤害不计算为最近的平均伤害.

        public bool UsePotion { get; set; }
        [ValueRange(1000, 5000)] public long UsePotionCountDown { get; set; } // 倒计时多少ms的时候使用爆发药

        public bool ShowGameLog { get; set; }
        public bool ShowDebugLog { get; set; }

        public bool ShowToast { get; set; }

        public bool ShowBattleTime { get; set; }

        public int DexPotionId { get; set; }
        
        public int StrPotionId { get; set; }

        public HashSet<string> DotBlacklist { get; set; } = new HashSet<string>();

        public bool AutoFinalBurst = true;
        public int AutoFinalBurstCheckTime { get; set; } = 6000;

        public bool AbilityFirst { get; set; } = false;

        public void Reset()
        {
            UserLatencyOffset = 50;
            ActionQueueMs = 500;
            MaxAbilityTimsInGCD = 2;
            OpenTTK = true;
            TimeToKill_TimeInSec = 15;
            TTK_IgnoreDamage = 300000;
            UsePotion = false;
            UsePotionCountDown = 1500;
            AnimationLockMs = 500;
            ShowGameLog = true;
            ShowDebugLog = false;
            ShowToast = false;
            EarlyDecisionMode = true;
            AutoFinalBurst = true;
            AutoFinalBurstCheckTime = 6000;

            DexPotionId = 36105; // 5级巧力
            StrPotionId = 36104; // 5级刚力
            AbilityFirst = false;
        }
        
    }
}