using AEAssist.Define;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class SageSettings : IBaseSetting
    {
        public SageSettings()
        {
            Reset();
        }
        
        public int Dot_TimeLeft { get; set; } = ConstValue.AuraTick;
        public int TTK_EukrasianDosis { get; set; } 
        
        public bool EarlyDecisionMode { get; set; }

        public void Reset()
        {
            EarlyDecisionMode = true;
            Dot_TimeLeft = ConstValue.AuraTick;
            TTK_EukrasianDosis = 30;
        }
    }
}