using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.BLM.Ability
{
    public class BlackMageAblity_Manafont : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.ManaFont.IsReady())
            {
                return -1;
            }
            if (ActionResourceManager.BlackMage.AstralStacks == 3 &&
                Core.Me.MaxMana < 800)
            {
                return 1;
            }

            return -2;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.ManaFont.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}