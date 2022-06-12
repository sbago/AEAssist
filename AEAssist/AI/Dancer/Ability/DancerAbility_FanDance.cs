using System;
using System.Threading.Tasks;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Dancer.Ability
{
    public class DancerAbility_FanDance : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.FanDance.IsUnlock())
            {
                return -10;
            }

            if (ActionResourceManager.Dancer.FourFoldFeathers < 1)
            {
                return -1;
            }

            if (SpellsDefine.FanDance.RecentlyUsed())
            {
                return -2;
            }

            if (Core.Me.HasAura(AurasDefine.ThreeFoldFanDance) && !SpellsDefine.FanDance3.RecentlyUsed())
            {
                return -3;
            }

            if (SpellsDefine.Flourish.RecentlyUsed())
            {
                return -2;
            }

            if (SpellsDefine.FanDance3.RecentlyUsed() && !SpellsDefine.Flourish.RecentlyUsed())
            {
                return 1;
            }

            if (AEAssist.DataBinding.Instance.FinalBurst) return 2;

            if (Core.Me.HasAura(AurasDefine.Devilment))
            {
                return 1;
            }

            if (ActionResourceManager.Dancer.FourFoldFeathers == 4)
            {
                if (Core.Me.HasAura(AurasDefine.FlourishingSymmetry) || Core.Me.HasAura(AurasDefine.FlourshingFlow))
                {
                    return 0;
                }
            }

            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.FanDance.GetSpellEntity();
            if (SpellsDefine.FanDance2.IsUnlock())
            {
                if (TargetHelper.CheckNeedUseAOE(Core.Me.CurrentTarget, 5, 5, 2))
                {
                    spell = SpellsDefine.FanDance2.GetSpellEntity();
                }
            }

            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}