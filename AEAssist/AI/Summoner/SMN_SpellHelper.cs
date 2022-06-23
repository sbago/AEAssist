using System;
using System.Linq;
using System.Windows.Media;
using AEAssist.Define;
using AEAssist.Define.DataStruct;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using ff14bot.RemoteWindows;
namespace AEAssist.AI.Summoner
{
    public static class SMN_SpellHelper
    {
        public static bool Debugging
        {
            get {
                return true;
            }
        }
        

        public static bool PhoenixTrance() {
            return ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Phoenix);
        }


        public static bool CheckUseAOE()
        {
            return TargetHelper.CheckNeedUseAOE(25, 5);
        }
        public static bool AnyPet()
        {
            return Titan() || Ifrit() || Garuda();
        }
        public static bool Titan()
        {
            return ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Titan;
        }

        public static bool Ifrit()
        {
            return ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Ifrit;
        }

        public static bool Garuda()
        {
            return ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Garuda;
        }
    }
}