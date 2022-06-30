using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_CoolDownPhase : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // var checkOddOrEvenBattleTime = SamuraiSpellHelper.CheckOddOrEvenBattleTime();
            // if (checkOddOrEvenBattleTime == 1 || checkOddOrEvenBattleTime == 0)
            // {
            //     return -1;
            // }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            // CoolDownPhase
            // return await SamuraiSpellHelper.CoolDownPhaseGCD(Core.Me.CurrentTarget);
            
            var spell = SamuraiSpellHelper.CoolDownPhaseGCD(Core.Me.CurrentTarget);
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}