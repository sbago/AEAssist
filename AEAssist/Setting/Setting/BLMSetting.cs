using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class BLMSetting : IBaseSetting
    {
        public BLMSetting()
        {
            Reset();
        }
        
        public bool EarlyDecisionMode { get; set; }

        public void Reset()
        {
            EarlyDecisionMode = true;
        }
    }
}