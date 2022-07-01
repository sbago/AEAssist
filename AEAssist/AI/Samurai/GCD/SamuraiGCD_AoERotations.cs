using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_AoERotations : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var needUseAoe = TargetHelper.CheckNeedUseAOE(2, 5);
            if (!needUseAoe)
            {
                return -1;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            // AoERotations
            return await SamuraiSpellHelper.AoEGCD();
        }
    }
}