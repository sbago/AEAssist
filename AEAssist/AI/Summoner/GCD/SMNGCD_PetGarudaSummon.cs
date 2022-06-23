using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_PetGarudaSummon : IAIHandler
    {
        uint spell;
        static public uint GetSpell()
        {
            if (SpellsDefine.SummonGaruda2.IsUnlock())
                return SpellsDefine.SummonGaruda2;
            if (SpellsDefine.SummonGaruda.IsUnlock())
                return SpellsDefine.SummonGaruda;
            return SpellsDefine.SummonEmerald;
        }
        public int Check(SpellEntity lastSpell)
        {
            if (!ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Garuda))
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