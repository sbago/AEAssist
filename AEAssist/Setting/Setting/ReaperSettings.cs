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

        public void Reset()
        {
            this.UsePotionId = 36104; // 5级刚力
            this.GallowsPrefer = false;
        }
        
        public int UsePotionId  {get;set;}

        public bool GallowsPrefer { get; set; }
    }
}