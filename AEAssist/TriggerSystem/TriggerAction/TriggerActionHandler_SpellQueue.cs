using AEAssist.AI;
using AEAssist.Define;
using AEAssist.TriggerAction;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_SpellQueue : ATriggerActionHandler<TriggerAction_SpellQueue>
    {
        protected override void Handle(TriggerAction_SpellQueue t)
        {
            var spellQueueSlot = ObjectPool.Instance.Fetch<SpellQueueSlot>();
            foreach (var v in t.GCDQueue)
            {
                if (v == 0)
                {
                    continue;
                }
                if (SpellsDefine.TargetIsSelfs.Contains(v))
                {
                    spellQueueSlot.EnqueueGCD((v, SpellTargetType.Self));
                }
                else
                {
                    spellQueueSlot.EnqueueGCD((v, SpellTargetType.CurrTarget));
                }
            }

            foreach (var v in t.AbilityQueue)
            {
                if (v == 0)
                {
                    continue;
                }
                if (SpellsDefine.TargetIsSelfs.Contains(v))
                {
                    spellQueueSlot.EnqueueAbility((v, SpellTargetType.Self));
                }
                else
                {
                    spellQueueSlot.EnqueueAbility((v, SpellTargetType.CurrTarget));
                }
            }

            spellQueueSlot.UsePotion = t.UsePotion;

            AIRoot.GetBattleData<BattleData>().NextSpellSlot = spellQueueSlot;
        }
    }
}