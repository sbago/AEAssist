using System.Threading.Tasks;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Dancer.Ability
{
    public class DancerAbility_FanDance3 : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.FanDance3.IsUnlock())
            {
                return -10;
            }

            if (SpellsDefine.Flourish.RecentlyUsed() && !SpellsDefine.FanDance3.RecentlyUsed())
            {
                return 1;
            }
            if (!Core.Me.HasAura(AurasDefine.ThreeFoldFanDance))
            {
                return -1;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.FanDance3.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}