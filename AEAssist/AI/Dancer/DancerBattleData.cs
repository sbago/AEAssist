namespace AEAssist.AI.Dancer
{
    public enum DancerComboStages
    {
        Cascade,
        Fountain,
        Windmill,
        Bladeshower,
    }

    public class DancerBattleData : IBattleData
    {
        public DancerComboStages CurrCombo = DancerComboStages.Cascade;
    }
}