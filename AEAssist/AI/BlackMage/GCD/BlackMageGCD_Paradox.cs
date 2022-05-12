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
            // prevent redundant casting
            if (lastSpell == SpellsDefine.Paradox.GetSpellEntity() ||
                lastSpell == SpellsDefine.Fire.GetSpellEntity())
            {
                return -1;
            }
            
            // if we are in fire
            // and we use paradox to refresh astral time
            // if we have less than 2400 mana, skill refresh buff, go despair
            if (ActionResourceManager.BlackMage.AstralStacks > 0 &&
                Core.Me.CurrentMana > 2400)
            {
                return 1;
            }

            // if we are in ice
            if (ActionResourceManager.BlackMage.UmbralStacks > 0 &&
                SpellsDefine.Paradox.IsUnlock() &&
                BlackMageHelper.IsParadoxReady())
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