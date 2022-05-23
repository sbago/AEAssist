using AEAssist.View;
using PropertyChanged;

namespace AEAssist.TriggerAction
{
    [Trigger("ReplayOpener",Tooltip = "Replay the opener",NeedParams = false)]
    [AddINotifyPropertyChangedInterface]
    [GUIDefault]
    public class TriggerAction_ReplayOpener : ITriggerAction
    {
        public void WriteFromJson(string[] values)
        {
           
        }

        public string[] Pack2Json()
        {
            return null;
        }
    }
}