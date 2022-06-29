using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_Ikishoten : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (SpellsDefine.Ikishoten.GetSpellEntity().Cooldown.TotalSeconds == 0 &&
                ActionResourceManager.Samurai.Kenki < 50)
                return 1;
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Ikishoten.GetSpellEntity();
            if (spell == null) return null;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}