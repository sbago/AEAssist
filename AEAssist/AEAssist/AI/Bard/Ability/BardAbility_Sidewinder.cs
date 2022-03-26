using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_Sidewinder : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!Spells.Sidewinder.IsReady())
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            var spellData = Spells.Sidewinder;
            if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}