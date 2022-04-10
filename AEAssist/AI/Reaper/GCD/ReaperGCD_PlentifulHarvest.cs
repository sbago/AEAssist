using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.GCD
{
    public class ReaperGCD_PlentifulHarvest : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            return ReaperSpellHelper.CheckCanUsePlentifulHarvest();
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.PlentifulHarvest;
            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget)) return spell;

            return null;
        }
    }
}