namespace AEAssist
{
    public class GeneralSettings : IBaseSetting
    {
        public int UserLatencyOffset = 50; // 玩家预计延迟
        public int ActionQueueMs = 400; // 提前多久开始准备释放技能
        public int MaxAbilityTimsInGCD = 2; // 一个GCD内最多插几个能力技

        public bool OpenTTK = true; // 启动TTK
        public int TimeToKill_TimeInSec = 15; //ttk 预计多少秒死亡
        public int TTK_IgnoreDamage = 300000; // 大于30W的伤害不计算为最近的平均伤害.
        
        public bool UsePotion;
        public long UsePotionCountDown = 1500; // 倒计时多少ms的时候使用爆发药
    }
}