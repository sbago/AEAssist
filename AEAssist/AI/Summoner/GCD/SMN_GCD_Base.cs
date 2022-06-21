using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Summoner
{
    public class SMN_GCD_Base : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SMN_SpellHelper.GetBaseGcd();
            if (spell == null) return null;
            var ret = await spell.DoGCD();
            return ret ? spell : null;
        }
    }
}