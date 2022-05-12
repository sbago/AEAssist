using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.BlackMage.GCD
{
    public class BlackMageGCD_Fire3 : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            //prevent reduent spell
            if (lastSpell == SpellsDefine.Fire3.GetSpellEntity() ||
                lastSpell == SpellsDefine.Blizzard3.GetSpellEntity() ||
                lastSpell == SpellsDefine.HighBlizzardII.GetSpellEntity()
                )
            {
                return -1;
            }
            
            
            // if we are in fire 
            if (ActionResourceManager.BlackMage.AstralStacks > 0)
            {
                // if we need to use fire 3 to achieve max stack of fire
                if (ActionResourceManager.BlackMage.AstralStacks < 3)
                {
                    return 1;
                }
                // if paradox unused, prevent wasting firestarter which can be triggered by paradox
                if (BlackMageHelper.IsMaxAstralStacks(lastSpell) &&
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
                if (BlackMageHelper.IsUmbralFinished())
                {
                    return 2;
                }
            }
            
            // if we are in nothing, we go to fire
            if (ActionResourceManager.BlackMage.UmbralStacks == 0 &&
                ActionResourceManager.BlackMage.AstralStacks == 0)
            {
                // if we are at the beginning of fight 
                if (Core.Me.CurrentMana == 10000)
                {
                    return 4;
                }
            }

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