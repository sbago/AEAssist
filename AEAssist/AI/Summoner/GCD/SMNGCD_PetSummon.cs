using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_PetSummon : IAIHandler
    {
        uint spell;
        static uint GetIfrit()
        {
            if (SpellsDefine.SummonIfrit2.IsUnlock())
                return SpellsDefine.SummonIfrit2;
            if (SpellsDefine.SummonIfrit.IsUnlock())
                return SpellsDefine.SummonIfrit;
            return SpellsDefine.SummonRuby;
        }

        static uint GetTitan()
        {
            if (SpellsDefine.SummonTitan2.IsUnlock())
                return SpellsDefine.SummonTitan2;
            if (SpellsDefine.SummonTitan.IsUnlock())
                return SpellsDefine.SummonTitan;
            return SpellsDefine.SummonTopaz;
        }

        static uint GetGaruda()
        {
            if (SpellsDefine.SummonGaruda2.IsUnlock())
                return SpellsDefine.SummonGaruda2;
            if (SpellsDefine.SummonGaruda.IsUnlock())
                return SpellsDefine.SummonGaruda;
            return SpellsDefine.SummonEmerald;
        }

        static bool SwiftcastingSlipStream()
        {
            if (!SpellsDefine.Slipstream.IsUnlock())
                return false;
            if (!ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Garuda))
                return false;

            if (!SpellsDefine.Swiftcast.CoolDownInGCDs(3))
                return false;

            if (SettingMgr.GetSetting<SMNSettings>().SwiftcastOption == 0)
                return false;

            return true;
        }

     

        static uint GetSpell() 
        {
            

            if (DataBinding.Instance.SaveInstantSpells)
            {
                if(ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Ifrit))
                    return GetIfrit();
                if (AIRoot.Instance.CloseBurst || !SMNGCD_Aethercharge.GetSpell().CoolDownInGCDs(8))
                    return 0;
            }

            if (SwiftcastingSlipStream())
                return GetGaruda();

            if (ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Titan))
                return GetTitan();
            if (ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Garuda))
                return GetGaruda();
            if (ActionResourceManager.Summoner.AvailablePets.HasFlag(ActionResourceManager.Summoner.AvailablePetFlags.Ifrit))
                return GetIfrit();
            return 0;
        }

        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();
            if (spell == 0)
                return -1;
            if (!spell.IsReady())
                return -1;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}