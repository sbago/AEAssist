using System.Threading.Tasks;
using AEAssist;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.Ability
{
    public class ReaperAbility_ArcaneCircle : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.ArcaneCircle.IsReady())
                return -1;
            if (AIRoot.Instance.CloseBuff)
                return -2;
            if (!Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget))
                return -3;
            if (AEAssist.DataBinding.Instance.DoubleEnshroudPrefer)
            {
                if (ActionResourceManager.Reaper.ShroudGauge >= 50 && !Core.Me.HasAura(AurasDefine.Enshrouded))
                    return -4;
                if (Core.Me.HasAura(AurasDefine.Enshrouded))
                {
                    var delta = TimeHelper.Now() - SpellHistoryHelper.GetLastSpellTime(SpellsDefine.Enshroud.Id);
                    LogHelper.Debug($"{nameof(ReaperAbility_ArcaneCircle)}: {delta}");
                    if (delta < 2000)
                        return -5;
                }
            }

            return 0;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.ArcaneCircle, Core.Me))
            {
                return SpellsDefine.ArcaneCircle;
            }

            return null;
        }
    }
}