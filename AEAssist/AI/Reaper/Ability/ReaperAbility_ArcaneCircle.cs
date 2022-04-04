using System.Threading.Tasks;
using AEAssist.DataBinding;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.Ability
{
    public class ReaperAbility_ArcaneCircle : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!SpellsDefine.ArcaneCircle.IsReady())
                return false;
            if (AIRoot.Instance.CloseBuff)
                return false;
            if (Core.Me.HasAura(AurasDefine.SoulReaver))
                return false;
            if (!Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget))
                return false;

            if (BaseSettings.Instance.DoubleEnshroudPrefer)
            {
                if (ActionResourceManager.Reaper.ShroudGauge >= 50 && !Core.Me.HasAura(AurasDefine.Enshrouded))
                    return false;
                if (Core.Me.HasAura(AurasDefine.Enshrouded))
                {
                    if (TimeHelper.Now() - AIRoot.Instance.ReaperBattleData.EnshroundTime < 2000)
                        return false;
                }
            }

            return true;
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