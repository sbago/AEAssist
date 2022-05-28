using AEAssist.AI;
using AEAssist.Helper;
using AEAssist.TriggerCond;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_EnemyCastSpell : ATriggerCondHandler<TriggerCond_EnemyCastSpell>
    {
        protected override bool Check(TriggerCond_EnemyCastSpell cond)
        {
            if (AIRoot.GetBattleData<BattleData>().GetCondHitTime(cond, out var time))
            {
                if (TimeHelper.Now() >= time + cond.delayTime * 1000) return true;
            }
            else
            {
                var enemys = TargetMgr.Instance.Enemys;
                if (cond.strs == null)
                {
                    if (cond.spellName.Contains("|"))
                        cond.strs = new string[] { cond.spellName };
                    else
                    {
                        cond.strs = cond.spellName.Split('|');
                    }
                }
                
                foreach (var v in enemys.Values)
                {
                    if (v.SpellCastInfo == null || !v.IsCasting)
                        continue;
                    //LogHelper.Info($"Character {v.Name} Casting===>{v.SpellCastInfo.SpellData.LocalizedName}");

                    foreach (var str in cond.strs)
                    {
                        if (v.SpellCastInfo.SpellData.LocalizedName.Contains(str)
                            || v.SpellCastInfo.SpellData.Id.ToString() == str
                            || v.SpellCastInfo.Name.Contains(str))
                        {
                            AIRoot.GetBattleData<BattleData>().RecordCondHitTime(cond);
                            return false;
                        }   
                    }
                }
            }

            return false;
        }
    }
}