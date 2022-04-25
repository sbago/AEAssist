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
        public int Check(SpellEntity lastSpell)
        {
            if (AIRoot.Instance.CloseBurst)
                return -1;
            if (!DataBinding.Instance.UseBattery)
                return -2;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return -10;
            if (ActionResourceManager.Machinist.Battery < 50)
                return -3;
            if (ActionResourceManager.Machinist.OverheatRemaining > TimeSpan.Zero)
                return -4;
            if (SpellsDefine.Hypercharge.RecentlyUsed())
                return -5;
            if (ActionResourceManager.Machinist.SummonRemaining > TimeSpan.Zero)
                return -6;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = MCHSpellHelper.GetAutomatonQueen();
            if (await spell.DoAbility())
            {
                return spell;
            }

            return null;
        }
    }
}