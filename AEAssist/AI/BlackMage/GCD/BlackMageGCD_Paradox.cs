using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.GCD
{
    public class BlackMageGCD_Paradox : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // todo: fire1 needs repeated check, and level is not working
            
            // if we are in fire
            // and we use paradox to refresh astral time
            // if we have less than 2400 mana, skill refresh buff, go despair
            if (BlackMageHelper.IsMaxAstralStacks(lastSpell) &&
                Core.Me.CurrentMana > 2400)
            {
                return 1;
            }

            // if we are in ice
            if (ActionResourceManager.BlackMage.UmbralStacks > 0 &&
                BlackMageHelper.LearnedParadox())
            {
                return 2;
            }



            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = BlackMageHelper.GetParadox();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}