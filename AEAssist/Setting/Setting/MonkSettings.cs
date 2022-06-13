using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class MonkSettings : IBaseSetting
    {

        public MonkSettings()
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
        public bool HidePositionalToastsWithTn { get; set; }
        public int TwinSnakesRefresh { get; set; }
    }
}