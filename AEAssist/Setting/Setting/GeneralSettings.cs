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

        public void Reset()
        {
            this.UserLatencyOffset = 50;
            this.ActionQueueMs = 500;
            this.MaxAbilityTimsInGCD = 2;
            this.OpenTTK = true;
            this.TimeToKill_TimeInSec = 15;
            this.TTK_IgnoreDamage = 300000;
            this.UsePotion = false;
            this.UsePotionCountDown = 1500;
            this.AnimationLockMs = 500;
        }

        public int UserLatencyOffset{ get; set; } // 玩家预计延迟
        [ValueRange(300,500)]
        public int ActionQueueMs{ get; set; }  // 提前多久开始准备释放技能
        [ValueRange(1,2)]
        public int MaxAbilityTimsInGCD { get; set; } // 一个GCD内最多插几个能力技
        public int AnimationLockMs { get; set; }
        public bool OpenTTK { get; set; }  // 启动TTK
        [ValueRange(1,30)]
        public int TimeToKill_TimeInSec{ get; set; } //ttk 预计多少秒死亡
        [ValueRange(200000,1000000)]
        public int TTK_IgnoreDamage{ get; set; }// 大于30W的伤害不计算为最近的平均伤害.
        
        public bool UsePotion { get; set; }
        [ValueRange(1000,5000)]
        public long UsePotionCountDown{ get; set; } // 倒计时多少ms的时候使用爆发药
    }
}