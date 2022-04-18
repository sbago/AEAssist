namespace AEAssist.AI
{
    public enum KaeshiSpell
    {
        MidareSetsugekka,
        OgiNamikiri,
        NoUse,
    };

    public class SamuraiBattleData : IBattleData
    {
        public KaeshiSpell KaeshiSpell = KaeshiSpell.NoUse;
    }
}
