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
    public class BlackMageGCD_Thunder: IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // prevent casting same spell
            if (lastSpell == SpellsDefine.Thunder3.GetSpellEntity())
            {
                return -1;
            }

            // if we need to dot
            if (BlackMageHelper.IsTargetNeedThunder(Core.Me.CurrentTarget as Character, 5000))
            {
                // if we are in fire
                if (ActionResourceManager.BlackMage.AstralStacks > 0)
                {
                    // if we have more than 10 seconds left in fire
                    if (ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 100000)
                    {
                        return 1;
                    }
                }
                // if we are in ice, cast straight away
                if (ActionResourceManager.BlackMage.UmbralStacks > 0)
                {
                    return 2;
                }
            }
            
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Thunder3.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}