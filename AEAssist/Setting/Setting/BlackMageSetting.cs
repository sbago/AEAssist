using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class BlackMageSetting : IBaseSetting
    {
        public BlackMageSetting()
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