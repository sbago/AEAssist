using System;
using PropertyChanged;

namespace AEAssist.TriggerCond
{
    [Trigger("EnemyIsTargetable",
        Tooltip = "Specify enemy is targetable\n某个敌人可选中",
        ParamTooltip = "[enemy name(contains) or NpcId],[Time in sec]",
        Example = "10720,3")]
    [AddINotifyPropertyChangedInterface]
    public class TriggerCond_EnemyInLOS : ITriggerCond
    {
        public int delayTime { get; set; }
        public string name { get; set; }

        public void WriteFromJson(string[] values)
        {
            name = values[0];
            if (string.IsNullOrEmpty(name)) throw new Exception("is null!");

            if (!int.TryParse(values[1], out var delay)) throw new Exception($"{values[1]}Error!\n");
            if (delay < 0) throw new Exception("Must >=0 : " + delay);
            delayTime = delay;
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                name,
                delayTime.ToString()
            };
        }
    }
}