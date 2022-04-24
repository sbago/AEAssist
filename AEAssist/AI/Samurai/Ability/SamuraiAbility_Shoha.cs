using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SamuraiAbility_Shoha : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (ActionResourceManager.Samurai.Meditation == 3)
                return 0;

            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Shoha;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}
