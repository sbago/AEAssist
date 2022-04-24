using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SamuraiAbility_HissatsuShinten : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (ActionResourceManager.Samurai.Kenki >= 80)
                return 2;
            if (SpellsDefine.KaeshiSetsugekka.Cooldown.TotalMilliseconds < 65000 && ActionResourceManager.Samurai.Kenki < 50)
                return -2;
            if (SpellsDefine.Ikishoten.Cooldown.TotalSeconds < 3 && ActionResourceManager.Samurai.Kenki >50)
                return 2;
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.HissatsuShinten;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}
