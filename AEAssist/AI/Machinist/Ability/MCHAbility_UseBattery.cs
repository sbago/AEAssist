using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHAbility_UseBattery : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (AIRoot.Instance.CloseBurst)
                return -1;
            if (!DataBinding.Instance.UseBattery)
                return -2;
            if (ActionResourceManager.Machinist.Battery < 50)
                return -3;
            if (ActionResourceManager.Machinist.OverheatRemaining > TimeSpan.Zero)
                return -4;
            if (SpellsDefine.Hypercharge.RecentlyUsed())
                return -5;
            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = MCHSpellHelper.GetAutomatonQueen();
            if (await SpellHelper.CastAbility(spell, Core.Me))
            {
                return spell;
            }

            return null;
        }
    }
}