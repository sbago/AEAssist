using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class CombatMessageModel
    {
        private static CombatMessageModel _instance;
        public static CombatMessageModel Instance => _instance ?? (_instance = new CombatMessageModel());

        public void ClearMessage()
        {
            Message = "";
            ImageSource = "";
        }

        public string Message { get; set; } = "CombatMessage";
        public string ImageSource { get; set; } = "";
    }
}