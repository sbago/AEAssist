using System.Threading.Tasks;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.GCD
{
    public class ReaperGCD_BaseGCDCombo : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            return true;
        }

        public async Task<SpellData> Run()
        {
            return await ReaperSpellHelper.BaseGCDCombo(Core.Me.CurrentTarget);
        }
    }
}