namespace AEAssist.AI.Ninja
{
    public enum NinjaComboStages
    {
        SpinningEdge, //双刃旋
        GustSlash, //绝风
        AeolianEdge, //旋风刃
        // ArmorCrush, //强甲破点突
        DeathBlossom, // 血雨飞花
        HakkeMujinsatsu, //八卦无刃杀
    }

    public class NinjaBattleData : IBattleData
    {
        public NinjaComboStages CurrCombo = NinjaComboStages.SpinningEdge;
    }
}