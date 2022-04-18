using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class SamuraiSettings : IBaseSetting
    {
        public SamuraiSettings()
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