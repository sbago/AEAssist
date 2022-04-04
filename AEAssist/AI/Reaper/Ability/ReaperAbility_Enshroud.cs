using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.Ability
{
    public class ReaperAbility_Enshroud : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Enshroud.IsReady())
                return false;
            if (AIRoot.Instance.CloseBuff)
                return false;
            if (Core.Me.HasAura(AurasDefine.Enshrouded))
                return false;
            if (Core.Me.HasAura(AurasDefine.SoulReaver))
                return false;
            if (ActionResourceManager.Reaper.ShroudGauge < 50) return false;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return false;
            if (!Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget))
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.Enshroud, Core.Me))
            {
                return SpellsDefine.Enshroud;
            }

            return null;
        }
    }
}