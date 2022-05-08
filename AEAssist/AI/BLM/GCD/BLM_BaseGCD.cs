using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.BLM.GCD
{
    public class BLM_BaseGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Fire.GetSpellEntity();
            if (await spell.DoGCD())
                return spell;
            return null;
        }
    }
}