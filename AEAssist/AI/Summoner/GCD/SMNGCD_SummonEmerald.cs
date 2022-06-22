using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_SummmonEmerald : IAIHandler
    {
        static public uint getSummonEmerald()
        {
            if (SpellsDefine.SummonGaruda2.IsUnlock())
                return SpellsDefine.SummonGaruda2;
            if (SpellsDefine.SummonGaruda.IsUnlock())
                return SpellsDefine.SummonGaruda;
            return SpellsDefine.SummonEmerald;
        }
        public int Check(SpellEntity lastSpell)
        {

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = getSummonEmerald().GetSpellEntity();

            if (await spell.DoGCD()) return spell;

            return null;
        }
    }
}