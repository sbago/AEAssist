using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.AI.BLM.GCD
{
    public class BlackMageGCD_Despair : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // prevent redundant casting
            if (lastSpell == SpellsDefine.Despair.GetSpellEntity())
            {
                return -1;
            }
            
            
            // if we are in fire 
            if (ActionResourceManager.BlackMage.AstralStacks > 0)
            {
                // and we have enough time to cast
                if (ActionResourceManager.BlackMage.PolyglotTimer.TotalMilliseconds > 3000)
                {
                    return 1;
                }
            }

            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Despair.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}