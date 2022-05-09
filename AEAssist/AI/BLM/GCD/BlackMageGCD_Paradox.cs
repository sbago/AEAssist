using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.AI.BLM.GCD
{
    public class BlackMageGCD_Paradox : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // if we can not cast paradox, pass
            if (!BlackMageHelper.IsParadoxReady())
            {
                return -1;
            }
            
            // if we are in fire, and we can't cast fire4
            if (ActionResourceManager.BlackMage.AstralStacks == 3 &&
                BlackMageHelper.IsParadoxReady())
            {
                return 1;
            }

            // if we are in ice
            if (ActionResourceManager.BlackMage.UmbralStacks > 0)
            {
                return 2;
            }



            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Paradox.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}