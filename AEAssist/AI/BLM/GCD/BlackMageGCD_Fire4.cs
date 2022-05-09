using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.AI.BLM.GCD
{
    public class BlackMageGCD_Fire4 : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (BlackMageHelper.CanCastFire4())
            {
                return 1;
            }

            return -2;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Fire4.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}