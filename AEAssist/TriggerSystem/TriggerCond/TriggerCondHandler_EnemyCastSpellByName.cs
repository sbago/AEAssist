using AEAssist.AI;
using AEAssist.Helper;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_EnemyCastSpellByName : ATriggerCondHandler<TriggerCond_EnemyCastSpellByName>
    {
        protected override bool Check(TriggerCond_EnemyCastSpellByName cond)
        {
            if (AIRoot.GetBattleData<BattleData>().GetCondHitTime(cond, out var time))
            {
                if (TimeHelper.Now() >= time + cond.delayTime * 1000)
                {
                    return true;
                }
            }
            else
            {
                var enemys = TargetMgr.Instance.Enemys;
                foreach (var v in enemys.Values)
                {
                    if (v.SpellCastInfo == null || !v.IsCasting)
                        continue;
                    //LogHelper.Info($"Character {v.Name} Casting===>{v.SpellCastInfo.SpellData.LocalizedName}");
                    if (v.SpellCastInfo.SpellData.LocalizedName.Contains(cond.spellName)
                        || v.SpellCastInfo.SpellData.Id.ToString() == cond.spellName)
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