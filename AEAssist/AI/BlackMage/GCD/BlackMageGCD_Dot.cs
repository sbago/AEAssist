using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.BlackMage.GCD
{
    public class BlackMageGCD_Dot: IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return BlackMageHelper.ThunderCheck();
        }

        public async Task<SpellEntity> Run()
        {
            var spell = BlackMageHelper.GetThunder();
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