using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_Fillers : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            const int minimumGcdOneMin = 26;
            var baseGcdTime = RotationManager.Instance.GetBaseGCDSpell().AdjustedCooldown.TotalMilliseconds;
            var battleTime = AIRoot.GetBattleData<BattleData>().CurrBattleTimeInMs;
            var totalGcdTimeMs = baseGcdTime * minimumGcdOneMin;

            if (battleTime % totalGcdTimeMs == 0)
            {
                return 0;
            }

            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            return await SamuraiSpellHelper.FillerRotations();
        }
    }
}