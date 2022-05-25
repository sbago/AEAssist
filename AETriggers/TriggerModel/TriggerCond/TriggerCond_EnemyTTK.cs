using AEAssist.View;
using PropertyChanged;

namespace AEAssist.TriggerCond
{
    [Trigger("EnemyTimeToKill 敌人几秒内死亡",Tooltip = "The specify enemy is time to kill.\n指定敌人即将几秒内死亡",
        ParamTooltip = "[enemy name(contains) or NpcId],[Time in sec]\n" +
                       "[敌人的名字(包含),或者NpcId],[几秒内死亡]")
    ]
    [AddINotifyPropertyChangedInterface]
    public class TriggerCond_EnemyTTK : ITriggerCond
    {
        [GUILabel("Name/Id")]
        public string Name { get; set; }
        [GUIToolTip("Time in sec")]
        [GUIIntRange(3,30)]
        public int TimeToKill { get; set; }
        public void WriteFromJson(string[] values)
        {
            
        }

        public string[] Pack2Json()
        {
            return null;
        }

        public void Check()
        {
            
        }
    }
}