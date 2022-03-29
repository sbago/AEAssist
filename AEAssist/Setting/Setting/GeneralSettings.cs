using AEAssist.Annotations;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class GeneralSettings : IBaseSetting
    {
        public int UserLatencyOffset{ get; set; } = 50; // 玩家预计延迟
        [ValueRange(300,500)]
        public int ActionQueueMs{ get; set; } = 400; // 提前多久开始准备释放技能
        [ValueRange(1,2)]
        public int MaxAbilityTimsInGCD { get; set; }= 2; // 一个GCD内最多插几个能力技

        public bool OpenTTK { get; set; } = true; // 启动TTK
        [ValueRange(1,30)]
        public int TimeToKill_TimeInSec{ get; set; } = 15; //ttk 预计多少秒死亡
        [ValueRange(200000,1000000)]
        public int TTK_IgnoreDamage{ get; set; } = 300000; // 大于30W的伤害不计算为最近的平均伤害.
        
        public bool UsePotion { get; set; }
        [ValueRange(1000,5000)]
        public long UsePotionCountDown{ get; set; } = 1500; // 倒计时多少ms的时候使用爆发药
    }
}