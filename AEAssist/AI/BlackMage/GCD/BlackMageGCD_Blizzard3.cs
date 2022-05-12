using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.GCD
{
    public class BlackMageGCD_Blizzard3 : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // todo: how to make blizzard2 casting itself?
            // prevent redundant casting
            if (lastSpell == SpellsDefine.Blizzard3.GetSpellEntity() ||
                lastSpell == SpellsDefine.HighBlizzardII.GetSpellEntity() ||
                lastSpell == SpellsDefine.Paradox.GetSpellEntity() ||
                lastSpell == SpellsDefine.Fire.GetSpellEntity() 
               )
            {
                return -1;
            }
            // prevent to waste mana font
            if (lastSpell == SpellsDefine.ManaFont.GetSpellEntity())
            {
                return -1;
            }
            // fire to ice
            if (BlackMageHelper.IsMaxAstralStacks(lastSpell))
            {
                return 1;
            }
            // if we are in nothing, starting to fight without full mana
            if (ActionResourceManager.BlackMage.AstralStacks == 0 &&
                ActionResourceManager.BlackMage.UmbralStacks == 0 &&
                Core.Me.CurrentMana < 10000)
            {
                return 2;
            }
            // this shouldn't run, but put here just in case I fucked up '
            if (ActionResourceManager.BlackMage.UmbralStacks > 0 &&
                ActionResourceManager.BlackMage.UmbralStacks < 3)
            {
                return 69;
            }
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = BlackMageHelper.GetBlizzard3();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}