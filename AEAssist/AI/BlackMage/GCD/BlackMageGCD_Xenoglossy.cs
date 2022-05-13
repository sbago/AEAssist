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
                // if we are in fire
                if (ActionResourceManager.BlackMage.AstralStacks > 0)
                {
                    if (SpellsDefine.Amplifier.IsUnlock())
                    {
                        // if we have more than 1 polyglot
                        // if we have less than 10 seconds to obtain another
                        // if we have Amplifier unlock, and it's gonna be ready in 10 seconds
                        if (ActionResourceManager.BlackMage.PolyglotCount > 1 &&
                            ActionResourceManager.BlackMage.PolyglotTimer < TimeSpan.FromMilliseconds(100000) &&
                            SpellsDefine.Amplifier.GetSpellEntity().SpellData.Cooldown <
                            TimeSpan.FromMilliseconds(100000))
                        {
                            // if we have enough time for paradox
                            var baseGCDTime = SpellsDefine.Scathe.GetSpellEntity().SpellData.AdjustedCooldown.Add(TimeSpan.FromMilliseconds(ConstValue.BlackMageLatencyCompensation));
                            if (ActionResourceManager.BlackMage.StackTimer > baseGCDTime + BlackMageHelper.GetSpellCastTimeSpan(SpellsDefine.Despair.GetSpellEntity()))
                            {
                                return 1;
                            }
                        }
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
            if (MovementManager.IsMoving && spell.SpellData.AdjustedCastTime > TimeSpan.Zero)
            {
                return null;
            }
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}