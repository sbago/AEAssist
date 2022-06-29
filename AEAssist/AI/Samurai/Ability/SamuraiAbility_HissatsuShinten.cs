using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_HissatsuShinten : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (ActionResourceManager.Samurai.Kenki >= 80)
                return 2;
            if (SpellsDefine.KaeshiSetsugekka.GetSpellEntity().Cooldown.TotalMilliseconds < 65000 &&
                ActionResourceManager.Samurai.Kenki < 50)
                return -2;
            if (SpellsDefine.Ikishoten.GetSpellEntity().Cooldown.TotalSeconds < 3 &&
                ActionResourceManager.Samurai.Kenki > 50)
                return 3;
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.HissatsuShinten.GetSpellEntity();
            if (spell == null) return null;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}