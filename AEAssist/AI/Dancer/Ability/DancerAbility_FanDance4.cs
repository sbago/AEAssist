using System.Threading.Tasks;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Dancer.Ability
{
    public class DancerAbility_FanDance4 : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.FanDanceIV.IsUnlock())
            {
                return -10;
            }
            if (SpellsDefine.Flourish.RecentlyUsed())
            {
                if (Core.Me.HasAura(AurasDefine.Devilment))
                {
                    return 1;
                }
            }
            if (!Core.Me.HasAura(AurasDefine.FourfoldFanDance))
            {
                return -1;
            }
            if (AEAssist.DataBinding.Instance.FinalBurst) return 2;
            
            if (Core.Me.HasAura(AurasDefine.Devilment))
            {
                return 1;
            }

            if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.FourfoldFanDance, SpellsDefine.Devilment.GetSpellEntity().Cooldown.Milliseconds + 2500))
            {
                return -2;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.FanDanceIV.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}