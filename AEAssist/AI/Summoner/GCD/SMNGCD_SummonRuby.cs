using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_SummmonRuby : IAIHandler
    {
        static public uint getSummonRuby()
        {
            if (SpellsDefine.SummonIfrit2.IsUnlock())
                return SpellsDefine.SummonIfrit2;
            if (SpellsDefine.SummonIfrit.IsUnlock())
                return SpellsDefine.SummonIfrit;
            return SpellsDefine.SummonRuby;
        }
        public int Check(SpellEntity lastSpell)
        {

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = getSummonRuby().GetSpellEntity();

            if (await spell.DoGCD()) return spell;

            return null;
        }
    }
}