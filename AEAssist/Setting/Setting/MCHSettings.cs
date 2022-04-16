using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class MCHSettings : IBaseSetting
    {
        public MCHSettings()
        {
            Reset();
        }

        public void Reset()
        {
            EarlyDecisionMode = true;
        }
        
        public bool EarlyDecisionMode { get; set; }
    }
}