using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class Language
    {
        public static Language Instance = new Language();

        public string LanType = "zh_CN";

        public string Toggle_Stop { get; set; } = "停手";
        public string Toggle_CloseBuff { get; set; } = "关闭爆发";
        public string Toggle_AOE { get; set; } = "AOE";

        public string MessageLog_CountDown_BattleStart { get; set; } = "战斗开始";
        public string MessageLog_CountDown_BattleStartIn5sec { get; set; } = "距离战斗开始还有5秒";
        public string MessageLog_CountDown_CancelBattleStart { get; set; } = "取消了战斗开始";
    }
}