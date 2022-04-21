using AEAssist.AI;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerCond
{
    public class TriggerCondHandler_EnemyCastSpellByName : ATriggerCondHandler<TriggerCond_EnemyCastSpellByName>
    {
        protected override bool Check(TriggerCond_EnemyCastSpellByName cond)
        {
            var enemys = TargetMgr.Instance.Enemys;
            foreach (var v in enemys.Values)
            {
                if (v.SpellCastInfo == null || !v.IsCasting)
                    continue;
                //LogHelper.Info($"Character {v.Name} Casting===>{v.SpellCastInfo.SpellData.LocalizedName}");
                if (v.SpellCastInfo.SpellData.LocalizedName.Contains(cond.spellName)) return true;

                if (v.SpellCastInfo.SpellData.Id.ToString() == cond.spellName) return true;
            }

            return false;
        }
    }
}