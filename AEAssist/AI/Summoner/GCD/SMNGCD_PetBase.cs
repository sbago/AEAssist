using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_PetBase : IAIHandler
    {
        uint spell;
        static public uint GetSpell()
        {
            if (SMN_SpellHelper.CheckUseAOE())
            {
                if (ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Ifrit)
                {
                    if (SpellsDefine.RubyDisaster.IsUnlock())
                        return SpellsDefine.RubyDisaster;

                    if (SpellsDefine.RubyCatastrophe.IsUnlock())
                        return SpellsDefine.RubyCatastrophe;

                    if (SpellsDefine.RubyOutburst.IsUnlock())
                        return SpellsDefine.RubyOutburst;
                  
                }

                if (ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Garuda)
                {
                    if (SpellsDefine.EmeraldDisaster.IsUnlock())
                        return SpellsDefine.EmeraldDisaster;

                    if (SpellsDefine.EmeraldCatastrophe.IsUnlock())
                        return SpellsDefine.EmeraldCatastrophe;

                    if (SpellsDefine.EmeraldOutburst.IsUnlock())
                        return SpellsDefine.EmeraldOutburst;
                }

                if (ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Titan)
                {
                    if (SpellsDefine.TopazDisaster.IsUnlock())
                        return SpellsDefine.TopazDisaster;

                    if (SpellsDefine.TopazCatastrophe.IsUnlock())
                        return SpellsDefine.TopazCatastrophe;

                    if (SpellsDefine.TopazOutburst.IsUnlock())
                        return SpellsDefine.TopazOutburst;
                }
            }

            if (ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Ifrit)
            {
                if (SpellsDefine.RubyRite.IsUnlock())
                    return SpellsDefine.RubyRite;

                if (SpellsDefine.RubyRuinIII.IsUnlock())
                    return SpellsDefine.RubyRuinIII;

                if (SpellsDefine.RubyRuinII.IsUnlock())
                    return SpellsDefine.RubyRuinII;

                return SpellsDefine.RubyRuin;
            }

            if (ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Garuda)
            {
                if (SpellsDefine.EmeraldRite.IsUnlock())
                    return SpellsDefine.EmeraldRite;

                if (SpellsDefine.EmeraldRuinIII.IsUnlock())
                    return SpellsDefine.EmeraldRuinIII;

                if (SpellsDefine.EmeraldRuinII.IsUnlock())
                    return SpellsDefine.EmeraldRuinII;

                return SpellsDefine.EmeraldRuin;
            }

            if (ActionResourceManager.Summoner.ActivePet == ActionResourceManager.Summoner.ActivePetType.Titan)
            {
                if (SpellsDefine.TopazRite.IsUnlock())
                    return SpellsDefine.TopazRite;

                if (SpellsDefine.TopazRuinIII.IsUnlock())
                    return SpellsDefine.TopazRuinIII;

                if (SpellsDefine.TopazRuinII.IsUnlock())
                    return SpellsDefine.TopazRuinII;

                return SpellsDefine.TopazRuin;
            }

            return 0;
        }

        public int Check(SpellEntity lastSpell)
        {
            if (ActionResourceManager.Summoner.PetTimer <= 0)
                return -3;
            spell = GetSpell();
            if (!spell.IsReady())
            {
                return -1;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}