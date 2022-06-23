using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_PetIfritSummon : IAIHandler
    {
        uint spell;
        static uint GetSpell()
        {
            if (SpellsDefine.SummonIfrit2.IsUnlock())
                return SpellsDefine.SummonIfrit2;
            if (SpellsDefine.SummonIfrit.IsUnlock())
                return SpellsDefine.SummonIfrit;
            return SpellsDefine.SummonRuby;
        }
        public int Check(SpellEntity lastSpell)
        {
            if (!ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Ifrit))
                return -3;
            spell = GetSpell();
            //if (spell.IsReady())
            //    return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}