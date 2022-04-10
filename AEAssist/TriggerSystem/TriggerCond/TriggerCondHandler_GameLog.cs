using AEAssist.Gamelog;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_GameLog : ATriggerCondHandler<TriggerCond_GameLog>
    {
        protected override bool Check(TriggerCond_GameLog cond)
        {
            foreach (var v in AEGamelogManager.Instance.GameLogBuffers)
            {
                if (v.MsgType != cond.MsgType)
                    continue;
                if (v.Content.Contains(cond.ContainValue))
                    return true;
            }

            return false;
        }
    }
}