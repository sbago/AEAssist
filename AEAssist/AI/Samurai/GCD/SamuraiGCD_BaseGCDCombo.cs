using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_BaseGCDCombo : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            //contain base combo
            var spell = SamuraiSpellHelper.GetBaseSpell();
            if (await spell.DoGCD())
                return spell;
            return null;
        }
    }
}