using System.Threading.Tasks;
using AEAssist.AI.BLM;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.BLM.Ability
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
            if (ActionResourceManager.BlackMage.UmbralHearts == 3 &&
                lastSpell == SpellsDefine.Fire3.GetSpellEntity())
            {
                return 1;
            }

            if (ActionResourceManager.BlackMage.AstralStacks == 3 &&
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