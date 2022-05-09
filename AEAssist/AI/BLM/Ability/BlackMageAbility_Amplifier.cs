using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Bard.Ability
{
    public class BlackMageAblity_Amplifier : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Amplifier.IsReady())
            {
                return -1;
            }

            if (ActionResourceManager.BlackMage.PolyglotCount == 0)
            {
                return 1;
            }
            
            return -2;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Amplifier.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}