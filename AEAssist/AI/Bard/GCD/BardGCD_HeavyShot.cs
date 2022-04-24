using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_HeavyShot : IAIHandler
    {
        public int Check(SpellEntity lastGCD)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spellData = BardSpellHelper.GetBaseGCD();
            if (await spellData.DoGCD()) return spellData;

            return null;
        }
    }
}