using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_HeavyShot : IAIHandler
    {
        public bool Check(SpellData lastGCD)
        {
            return true;
        }

        public async Task<SpellData> Run()
        {
            var spellData = BardSpellEx.GetHeavyShot();
            if (await SpellHelper.CastGCD(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}