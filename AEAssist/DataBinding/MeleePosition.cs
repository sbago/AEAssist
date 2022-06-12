using AEAssist.View;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class MeleePosition
    {
        public static MeleePosition Instance = new MeleePosition();

        public enum Position
        {
            back,
            side,
            none
        }
        public int SideTimer { get; set; } = 0;
        public int BackTimer { get; set; } = 0;
        public Position CurrentPosition { get; set; } = Position.none;

        public void SetBackTimer(int totalMilliseconds)
        {
            
        }

        public void ShowMsg(string msg, bool check)
        {
            if (!check)
                UIHelper.RfreshCurrOverlay();
        }
    }
}