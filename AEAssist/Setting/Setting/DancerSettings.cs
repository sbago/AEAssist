using AEAssist.AI.Dancer;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class DancerSettings : IBaseSetting
    {
        public DancerSettings()
        {
            Reset();
        }
        
        public bool EarlyDecisionMode { get; set; }

        public bool UseDanceOnlyInRange { get; set; } = false;
        public void Reset()
        {
            EarlyDecisionMode = true;
            UseDanceOnlyInRange = false;

        }

        public void OnLoad()
        {
            
        }
    }
}