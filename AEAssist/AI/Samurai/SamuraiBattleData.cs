namespace AEAssist.AI.Samurai
{
    public enum KaeshiSpell
    {
        MidareSetsugekka,
        OgiNamikiri,
        NoUse
    }

    public class SamuraiBattleData : IBattleData
    {
        public KaeshiSpell KaeshiSpell = KaeshiSpell.NoUse;
    }
}