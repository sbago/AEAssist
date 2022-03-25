using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_Bloodletter : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (lastSpell == Spells.Bloodletter)
                return false;
            if (Spells.Bloodletter.Charges < 1)
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            var spellData = Spells.Bloodletter;
            if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}