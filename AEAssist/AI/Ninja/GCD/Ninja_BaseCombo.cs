using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.Ninja.GCD
{
    public class Ninja_BaseCombo : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.SpinningEdge.GetSpellEntity();
            if (await spell.DoGCD())
                return spell;
            return null;
        }
    }
}