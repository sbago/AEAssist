using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;

namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_SummonCarbuncle : IAIHandler
    {
        uint spell = SpellsDefine.SummonCarbuncle;
        public int Check(SpellEntity lastSpell)
        {
            if (!spell.IsReady())
                return -1;

            //if (Core.Me.IsMounted || MovementManager.IsMoving || MovementManager.IsOccupied)
            //    return -3;

            if (GameObjectManager.PetObjectId != GameObjectManager.EmptyGameObject)
                return -4;

            //if (PetManager.ActivePetType != PetType.Emerald_Carbuncle)


            //GameObjectManager.PetObjectId.
            //ActionResourceManager.Summoner.AvailablePetFlags
            

            //if (Core.Me.SummonerGameObject != SmnPets.None)
            //    return false;


            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;

        }
    }
}