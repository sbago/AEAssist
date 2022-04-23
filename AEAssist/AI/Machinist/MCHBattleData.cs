namespace AEAssist.AI
{
    public enum MCHComboStages
    {
        SplitShot,
        SlugShot,
        CleanShot,
        SpreadShot
    }
    
    public class MCHBattleData : IBattleData
    {
        public MCHComboStages ComboStages;
        public int HyperchargeGCDCount = 0;
    }
}