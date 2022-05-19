using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_HissatsuKaiten : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.HissatsuKaiten;
            if (await spell.DoAbility())
                return spell.GetSpellEntity();
            return null;
        }
    }
}