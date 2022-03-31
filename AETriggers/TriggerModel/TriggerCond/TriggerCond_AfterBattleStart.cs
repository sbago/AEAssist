namespace AETriggers.TriggerModel
{
    public class TriggerCond_AfterBattleStart : ITriggerCond
    {
        public string CondName => "AfterBattleStart";
        public string Remark => "战斗开始后过了多久";
        public int Time;

        public bool Check()
        {
            if (Time < 0)
                return false;
            return true;
        }
    }
}