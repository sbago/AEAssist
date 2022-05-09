using System.Threading.Tasks;
using AEAssist.AI.BLM;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.BLM.Ability
{
    public class BlackMageAblity_Swiftcast : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Swiftcast.IsReady())
            {
                return -1;
            }
            if (ActionResourceManager.BlackMage.AstralStacks == 3 &&
                Core.Me.CurrentMana < 2400)
            {
                return 1;
            }

            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Swiftcast.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}