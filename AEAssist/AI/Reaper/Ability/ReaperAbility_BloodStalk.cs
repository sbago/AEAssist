using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.Ability
{
    public class ReaperAbility_BloodStalk : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!SpellsDefine.BloodStalk.IsUnlock())
                return false;
            if (ActionResourceManager.Reaper.SoulGauge < 50)
                return false;
            if (Core.Me.HasAura(AurasDefine.SoulReaver))
                return false;
            if (Core.Me.HasAura(AurasDefine.Enshrouded))
                return false;
            if (!AIRoot.Instance.CloseBuff && SpellsDefine.Gluttony.Cooldown.TotalMilliseconds < 6000)
            {
                return false;
            }
            if (!Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget))
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.BloodStalk;
            if (SpellsDefine.GrimSwathe.IsUnlock() && TargetHelper.CheckNeedUseAOE(8, 8))
            {
                spell = SpellsDefine.GrimSwathe;
            }

            if (await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget))
            {
                return spell;
            }

            return null;
        }
    }
}