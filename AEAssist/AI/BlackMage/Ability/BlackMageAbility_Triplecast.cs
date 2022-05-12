using System.Threading.Tasks;
using AEAssist.AI.BlackMage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.Ability
{
    public class BlackMageAblity_Triplecast : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Triplecast.IsReady())
            {
                return -1;
            }

            if (Core.Me.HasAura(AurasDefine.Triplecast))
            {
                return -3;
            }
            if (BlackMageHelper.UmbralHeatsReady() &&
                SpellsDefine.Fire3.RecentlyUsed())
            {
                return 1;
            }

            if (BlackMageHelper.IsMaxAstralStacks() &&
                BlackMageHelper.CanCastFire4() &&
                Core.Me.CurrentMana >= 8000)
            {
                return 2;
            }
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Triplecast.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}