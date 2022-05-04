using System.Threading.Tasks;
using AEAssist.Define;

namespace AEAssist.AI.Bard.GCD
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