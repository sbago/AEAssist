using AEAssist.AI;
using AEAssist.Gamelog;
using AEAssist.Helper;
using AEAssist.TriggerCond;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_GameLog : ATriggerCondHandler<TriggerCond_GameLog>
    {
        protected override bool Check(TriggerCond_GameLog cond)
        {
            if (AIRoot.GetBattleData<BattleData>().GetCondHitTime(cond, out var time))
            {
                if (TimeHelper.Now() >= time + cond.delayTime * 1000) return true;
            }
            else
            {
                foreach (var v in AEGamelogManager.Instance.GameLogBuffers)
                {
                    if (cond.MsgType != 0 && v.MsgType != cond.MsgType)
                        continue;
                    if (v.Content.Contains(cond.ContainValue))
                    {
                        AIRoot.GetBattleData<BattleData>().RecordCondHitTime(cond);
                        return false;
                    }
                }
            }


            return false;
        }
    }
}