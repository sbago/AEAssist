using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class NinjaSettings : IBaseSetting
    {

        public NinjaSettings()
        {
            Reset();
        }

        public void Reset()
        {
            EarlyDecisionMode = true;
        }

        public void OnLoad()
        {
            
        }

        public bool EarlyDecisionMode { get; set; }
    }
}