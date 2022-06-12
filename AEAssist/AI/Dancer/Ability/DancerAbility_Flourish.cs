using System.Threading.Tasks;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Dancer.Ability
{
    public class DancerAbility_Flourish : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Flourish.IsUnlock())
            {
                return -10;
            }
            
            if (!SpellsDefine.Flourish.IsReady())
            {
                return -1;
            }

            if (!AEAssist.DataBinding.Instance.UseFlourish)
            {
                return -3;
            }
            
            var bdls = AIRoot.GetBattleData<BattleData>().lastGCDSpell;
            if (!Core.Me.HasAura(AurasDefine.ThreeFoldFanDance))
            {
                return 0;
            }
            else
            {
                if (SpellsDefine.FanDance3.RecentlyUsed())
                {
                    return 5;
                }
            }
            
            // if we have no proc buff
            if (!Core.Me.HasAura(AurasDefine.FlourshingFlow) && !Core.Me.HasAura(AurasDefine.FlourishingSymmetry))
            {
                // and last spell will not proc
                if (bdls != SpellsDefine.Cascade.GetSpellEntity() && bdls != SpellsDefine.Fountain.GetSpellEntity() &&
                    bdls != SpellsDefine.Windmill.GetSpellEntity() && bdls != SpellsDefine.Bladeshower.GetSpellEntity())
                {
                    return 1;
                }
                // if last spell can proc
                else
                {
                    if (!AIRoot.Instance.Is2ndAbilityTime())
                        return -11;
                    return 2;
                }
            }
            // if we have proc buff
            if ((bdls == SpellsDefine.RisingWindmill.GetSpellEntity() || bdls == SpellsDefine.ReverseCascade.GetSpellEntity()) && !Core.Me.HasAura(AurasDefine.FlourshingFlow))
            {
                // we are good to go
                return 3;
            }
            if ((bdls == SpellsDefine.Bloodshower.GetSpellEntity() || bdls == SpellsDefine.Fountainfall.GetSpellEntity()) && !Core.Me.HasAura(AurasDefine.FlourishingSymmetry))
            {
                // we are good to go
                return 3;
            }

            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Flourish.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}