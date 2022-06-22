using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;

namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_SummonCarbuncle : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.SummonCarbuncle.IsReady())
                return -1;

            if (!SpellsDefine.SummonCarbuncle.IsUnlock())
                return -2;

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
            var spell = SpellsDefine.SummonCarbuncle.GetSpellEntity();
            spell.SpellTargetType = SpellTargetType.Self;
            var ret = await spell.DoGCD();
            return ret ? spell : null;

        }
    }
}