using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class ReaperSettings : IBaseSetting
    {
        public ReaperSettings()
        {
            Reset();
        }

        public bool GallowsPrefer { get; set; }

        public bool EarlyDecisionMode { get; set; }

        public bool DoubleEnshroudPrefer { get; set; }

        public void Reset()
        {
            GallowsPrefer = false;
            EarlyDecisionMode = true;
            DoubleEnshroudPrefer = false;
        }

        public void OnLoad()
        {
            
        }
    }
}