using System.Threading.Tasks;
using AEAssist.Define;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_EvenMinutesBurst : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var checkOddOrEvenBattleTime = SamuraiSpellHelper.CheckOddOrEvenBattleTime();
            if (checkOddOrEvenBattleTime != 0)
            {
                return -1;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            return await SamuraiSpellHelper.EvenMinutesBurst();
        }
    }
}