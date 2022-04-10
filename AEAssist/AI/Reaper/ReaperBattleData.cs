namespace AEAssist.AI.Reaper
{
    public enum ReaperComboStages
    {
        Slice,
        WaxingSlice,
        InfernalSlice,
        SpinningScythe,
        NightmareScythe
    }

    public class ReaperBattleData
    {
        public ReaperComboStages CurrCombo = ReaperComboStages.Slice;
    }
}