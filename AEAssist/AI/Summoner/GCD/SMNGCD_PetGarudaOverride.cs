using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_PetGarudaOverride : IAIHandler
    {
        uint spell;
        
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Slipstream.IsUnlock())
                return -1;
            if (!ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Garuda))
                return -4;
            if (SMN_SpellHelper.AnyPet())
                return -3;
            if (SpellsDefine.Swiftcast.CoolDownInGCDs(3))
            {
                spell = SMNGCD_PetGarudaSummon.GetSpell();
                return 1;
            }
                    
            return -1;
        }

        public async Task<SpellEntity> Run()
        {

            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}