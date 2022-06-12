using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Monk.GCD
{
    public class MonkGCD_PerfectBalanceGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (SpellsDefine.PerfectBalance.RecentlyUsed() || Core.Me.HasAura(AurasDefine.PerfectBalance))
            {
                if (ActionResourceManager.Monk.BlitzTimer != TimeSpan.Zero)
                {
                    return -2;
                }
                return 1;
            }

            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var target = Core.Me.CurrentTarget as Character;
            return await MonkSpellHelper.PerfectBalanceGCDCombo(target);
        }
    }
}