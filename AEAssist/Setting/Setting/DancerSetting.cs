using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class DancerSetting : IBaseSetting
    {
        public DancerSetting()
        {
            Reset();
        }
        
        public bool EarlyDecisionMode { get; set; }

        public void Reset()
        {
            EarlyDecisionMode = true;
        }

        public void OnLoad()
        {
            
        }
    }
}