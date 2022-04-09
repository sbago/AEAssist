using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.GCD
{
    public class ReaperGCD_ShadowOfDeath : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.ShadowOfDeath.IsUnlock())
                return -1;

            var target = Core.Me.CurrentTarget as Character;

            // 妖异
            if (Core.Me.HasAura(AurasDefine.SoulReaver))
                return -2;
            
            if (!target.ContainMyAura(AurasDefine.DeathsDesign, 10000)
                && (ActionResourceManager.Reaper.SoulGauge > 50
                    || ActionResourceManager.Reaper.ShroudGauge > 50 || SpellsDefine.PlentifulHarvest.RecentlyUsed()))
            {
                return 1;
            }

            if (target.ContainMyAura(AurasDefine.DeathsDesign, 3000))
                return -3;

            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.ShadowOfDeath;
            if (TargetHelper.CheckNeedUseAOE(5, 5))
            {
                spell = SpellsDefine.WhorlOfDeath;
            }
            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
                return spell;
            return null;
        }
    }
}