using System.Threading.Tasks;
using AEAssist.Define;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_OddMinuteBurst : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var checkOddOrEvenBattleTime = SamuraiSpellHelper.CheckOddOrEvenBattleTime();
            if (checkOddOrEvenBattleTime != 1)
            {
                return -1;
            }
            
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            return await SamuraiSpellHelper.OddMinutesBurst();
        }
    }
}