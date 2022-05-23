using System;
using PropertyChanged;

namespace AEAssist.TriggerCond
{
    [Trigger("EnemyHPPct",Tooltip = "the specify value that specify enemy'hp less than\n指定敌人的血量低于多少时",
        ParamTooltip = "[enemy name(contains) or NpcId],[Percentage of hp, retain three decimal places (51.123 = 51.123%)],[Time in sec]\n" +
                       "[敌人的名字(包含),或者NpcId],[血量百分比,保留3位小数(51.123 = 51.123%)],[过了多少秒]",
        Example = "10720,50.5,20\n\thydaelyn,50.12,3\n\t海德林,40,0")
    ]
    [AddINotifyPropertyChangedInterface]
    public class TriggerCond_EnemyHPPct : ITriggerCond
    {
        public int delayTime { get; set; }
        public float HpPct { get; set; } // xx.xxx
        public string Name { get; set; }

        public void WriteFromJson(string[] values)
        {
            Name = values[0];
            if (string.IsNullOrEmpty(Name)) throw new Exception($"{values[0]} is null!");

            if (!float.TryParse(values[1], out var va)) throw new Exception($"{values[1]} Error!");

            HpPct = va;

            if (!int.TryParse(values[2], out var delay)) throw new Exception($"{values[2]}Error!\n");

            if (delay < 0) throw new Exception("Must >=0 : " + delay);
            delayTime = delay;
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                Name,
                HpPct.ToString(),
                delayTime.ToString()
            };
        }
    }
}