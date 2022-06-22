using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_SummmonTopaz : IAIHandler
    {
        static public uint getSummonTopaz()
        {
            if (SpellsDefine.SummonTitan2.IsUnlock())
                return SpellsDefine.SummonTitan2;
            if (SpellsDefine.SummonTitan.IsUnlock())
                return SpellsDefine.SummonTitan;
            return SpellsDefine.SummonTopaz;
        }
        public int Check(SpellEntity lastSpell)
        {

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = getSummonTopaz().GetSpellEntity();

            if (await spell.DoGCD()) return spell;

            return null;
        }
    }
}