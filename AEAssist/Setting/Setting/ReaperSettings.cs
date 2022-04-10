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

        public int UsePotionId { get; set; }

        public bool GallowsPrefer { get; set; }

        public void Reset()
        {
            UsePotionId = 36104; // 5级刚力
            GallowsPrefer = false;
        }
    }
}