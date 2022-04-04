using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;
using ff14bot.RemoteWindows;

namespace AEAssist.AI.Reaper.GCD
{
    public class ReaperGCD_PlentifulHarvest : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            return ReaperSpellHelper.CheckCanUsePlentifulHarvest();
        }

        public async Task<SpellData> Run()
        {
            SpellData spell = SpellsDefine.PlentifulHarvest;
            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
            {
                return spell;
            }

            return null;
        }
    }
}