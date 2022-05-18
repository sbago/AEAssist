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
            if (AIRoot.Instance.CloseBurst)
                return -5;
            
            if (SpellsDefine.Flourish.IsReady() &&
                !Core.Me.HasAura(AurasDefine.FlourshingFlow) &&
                !Core.Me.HasAura(AurasDefine.FlourishingSymmetry) &&
                !Core.Me.HasAura(AurasDefine.FourfoldFanDance))
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