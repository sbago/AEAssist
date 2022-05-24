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

            var bdls = AIRoot.GetBattleData<BattleData>().lastGCDSpell;
            var bdla = AIRoot.GetBattleData<BattleData>().lastAbilitySpell;
            if (
                (!Core.Me.HasAura(AurasDefine.FlourshingFlow) || (Core.Me.HasAura(AurasDefine.FlourshingFlow) &&
                                                                  (bdls == SpellsDefine.Bloodshower.GetSpellEntity() ||
                                                                   bdls == SpellsDefine.Fountainfall
                                                                       .GetSpellEntity()))) &&
                (!Core.Me.HasAura(AurasDefine.FlourishingSymmetry) ||
                 (Core.Me.HasAura(AurasDefine.FlourishingSymmetry) &&
                  (bdls == SpellsDefine.RisingWindmill.GetSpellEntity() ||
                   bdls == SpellsDefine.ReverseCascade.GetSpellEntity()))) &&
                (!Core.Me.HasAura(AurasDefine.ThreeFoldFanDance) || (Core.Me.HasAura(AurasDefine.ThreeFoldFanDance) &&
                                                                     bdla == SpellsDefine.FanDance3.GetSpellEntity()))
            )
            {
                return 1;
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