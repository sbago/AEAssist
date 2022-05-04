using AEAssist.AI;
using AEAssist.Helper;
using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_LockSpell : ATriggerActionHandler<TriggerAction_LockSpell>
    {
        protected override void Handle(TriggerAction_LockSpell t)
        {
            if (t.Lock)
            {
                LogHelper.Debug("LockSpell : " + t.SpellId);
                AIRoot.GetBattleData<BattleData>().LockSpellId.Add(t.SpellId);
            }
            else
            {
                LogHelper.Debug("UnLockSpell : " + t.SpellId);
                AIRoot.GetBattleData<BattleData>().LockSpellId.Remove(t.SpellId);
            }
        }
    }
}