using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper
{
    public class ReaperGCD_PlentifulHarvest : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return ReaperSpellHelper.CheckCanUsePlentifulHarvest();
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.PlentifulHarvest.GetSpellEntity();
            if (await spell.DoGCD()) return spell;

            return null;
        }
    }
}