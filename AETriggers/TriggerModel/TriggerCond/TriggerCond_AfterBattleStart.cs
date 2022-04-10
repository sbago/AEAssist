using System;

namespace AETriggers.TriggerModel
{
    [Trigger(name:"AfterBattleStart",remark:"战斗开始后过了多久")]
    public class TriggerCond_AfterBattleStart : ITriggerCond
    {
        public int Time;
        
        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var time))
            {
                throw new Exception($"{values[0]}格式错误!\n");
            }
            this.Time = time;
            if (Time < 0)
            {
                throw new Exception("参数配置了小于0的值");
            }
        }
    }
}