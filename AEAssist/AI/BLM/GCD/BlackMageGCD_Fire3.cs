using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.BLM.GCD
{
    public class BlackMageGCD_Fire3 : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // if we are in fire 
            if (ActionResourceManager.BlackMage.AstralStacks > 0)
            {
                // if we need to use fire 3 to achieve max stack of fire
                if (ActionResourceManager.BlackMage.AstralStacks < 3)
                {
                    return 1;
                }
                // if paradox unused, prevent wasting firestarter which can be triggered by paradox
                if (ActionResourceManager.BlackMage.AstralStacks == 3 &&
                    BlackMageHelper.IsParadoxReady() &&
                    Core.Me.HasAura(AurasDefine.FireStarter))
                {
                    return 3;
                }
                
            }
            
            // if we are in ice
            if (ActionResourceManager.BlackMage.UmbralStacks > 0)
            {
                // if we used blizzard4, paradox, and max mana
                if (ActionResourceManager.BlackMage.UmbralHearts == 3 &&
                    !BlackMageHelper.IsParadoxReady() &&
                    Core.Me.CurrentMana == 10000)
                {
                    return 2;
                }
            }
            
            // if we are in nothing 
            if (ActionResourceManager.BlackMage.UmbralStacks == 0 &&
                ActionResourceManager.BlackMage.AstralStacks == 0)
            {
                // if we are at the beginning of fight 
                if (Core.Me.CurrentMana == 10000)
                {
                    return 4;
                }
            }
            
            // from ice to fire
            if (ActionResourceManager.BlackMage.UmbralStacks == 3 &&
                Core.Me.CurrentMana == 10000 &&
                !BlackMageHelper.IsParadoxReady())
            {
                return 1;
            }
            // start fire if we are in neither fire or nice, and full mana 
            if (ActionResourceManager.BlackMage.UmbralStacks == 0 &&
                ActionResourceManager.BlackMage.AstralStacks == 0 &&
                Core.Me.CurrentMana == 10000)
            {
                return 1;
            }
            // if we have firestarter buff, and still paradox unused
            if (ActionResourceManager.BlackMage.AstralStacks > 0 &&
                Core.Me.HasAura(AurasDefine.FireStarter) &&
                BlackMageHelper.IsParadoxReady())
            {
                return 1;
            }

            if (ActionResourceManager.BlackMage.AstralStacks > 0 &&
                ActionResourceManager.BlackMage.AstralStacks < 3
               )
            {
                return 2;}

            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Fire3.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}