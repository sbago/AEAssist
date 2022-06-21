using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class SMNSettings : IBaseSetting
    {
        public SMNSettings()
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