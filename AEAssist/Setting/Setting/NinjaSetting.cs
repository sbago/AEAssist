using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class NinjaSetting : IBaseSetting
    {

        public NinjaSetting()
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