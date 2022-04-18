using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SamuraiAbility_Ikishoten : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (SpellsDefine.Ikishoten.Cooldown.TotalSeconds == 0 &&
                ActionResourceManager.Samurai.Kenki < 50)
                return 1;
            return -1;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.Ikishoten;
            if (await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget))
                return spell;
            return null;
        }
    }
}

