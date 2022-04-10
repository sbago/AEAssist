using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_HeavyShot : IAIHandler
    {
        public int Check(SpellData lastGCD)
        {
            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spellData = BardSpellHelper.GetHeavyShot();
            if (await SpellHelper.CastGCD(spellData, Core.Me.CurrentTarget)) return spellData;

            return null;
        }
    }
}