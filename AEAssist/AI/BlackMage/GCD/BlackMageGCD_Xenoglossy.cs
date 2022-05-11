using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.GCD
{
    public class BlackMageGCD_Xenoglossy : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // if we have polyglot
            if (ActionResourceManager.BlackMage.PolyglotCount > 0)
            {
                // if we are in ice
                if (ActionResourceManager.BlackMage.UmbralStacks > 0)
                {
                    // if we enter ice with transpose
                    if (ActionResourceManager.BlackMage.UmbralStacks < 3)
                    {
                        if (!BlackMageHelper.IsParadoxReady())
                        {
                            return 2;
                        }
                    }
                    // if we enter ice with blizzard3
                    if (ActionResourceManager.BlackMage.UmbralStacks == 3)
                    {
                        return 3;
                    }   
                }
                // if we are in fire and we prevent Polyglot to waste
                if (ActionResourceManager.BlackMage.AstralStacks > 0 &&
                    !SpellsDefine.Amplifier.IsReady() &&
                    ActionResourceManager.BlackMage.PolyglotCount < 2)
                {
                    // if we have enough time for paradox
                    if (ActionResourceManager.BlackMage.PolyglotTimer.TotalMilliseconds > 5000)
                    {
                        return 1;
                    }
                }
            }
            
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = BlackMageHelper.GetXenoglossy();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}