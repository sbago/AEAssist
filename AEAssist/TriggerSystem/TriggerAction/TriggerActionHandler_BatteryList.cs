using AEAssist.AI;
using AEAssist.AI.Machinist;
using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_BatteryList : ATriggerActionHandler<TriggerAction_BatteryList>
    {
        protected override void Handle(TriggerAction_BatteryList t)
        {
            AIRoot.GetBattleData<MCHBattleData>().NextBatteryQueue.Clear();
            foreach (var v in t.BatteryList) AIRoot.GetBattleData<MCHBattleData>().NextBatteryQueue.Enqueue(v);

            AIRoot.GetBattleData<MCHBattleData>().ApplyNextBatteryQueue();
        }
    }
}