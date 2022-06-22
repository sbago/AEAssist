using System.Windows.Forms;

namespace AEAssist.AI.Monk
{
    
    public enum MonkNadiCombo
    {
        Lunar,
        Solar,
        None
    }
    
    public class MonkBattleData : IBattleData
    {
        public MonkNadiCombo CurrentMonkNadiCombo = MonkNadiCombo.None;
        public bool RoFBH2 = false;

    }
}