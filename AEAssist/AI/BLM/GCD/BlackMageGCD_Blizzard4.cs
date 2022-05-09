using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.AI.BLM.GCD
{
    public class BlackMageGCD_Blizzard4 : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // prevent redundant casting
            if (lastSpell == SpellsDefine.Blizzard4.GetSpellEntity())
            {
                return -1;
            }
            // if we are in ice, should before paradox to prevent lag, lag -> paradox can't go at the very begining
            if (ActionResourceManager.BlackMage.UmbralStacks == 3 &&
                ActionResourceManager.BlackMage.UmbralHearts != 3)
            {
                return 1;
            }
            
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Blizzard4.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}