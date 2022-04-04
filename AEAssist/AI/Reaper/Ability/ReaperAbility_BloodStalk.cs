using System.Threading.Tasks;
using AEAssist.DataBinding;
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
            if (!BaseSettings.Instance.UseSoulGauge)
                return false;
            if (ActionResourceManager.Reaper.SoulGauge < 50)
                return false;

            if (SpellsDefine.Enshroud.Cooldown.TotalMilliseconds > 0
                && SpellsDefine.Enshroud.Cooldown.TotalMilliseconds < 5000
                && ReaperSpellHelper.ReadyToEnshroud())
            {
                return false;
            }

            if(TimeHelper.Now() - AIRoot.Instance.ReaperBattleData.EnshroundTime < 3000)
                return false;
            if (Core.Me.HasAura(AurasDefine.SoulReaver))
                return false;
            if (Core.Me.HasAura(AurasDefine.Enshrouded))
                return false;
            if (!AIRoot.Instance.CloseBuff && SpellsDefine.Gluttony.Cooldown.TotalMilliseconds < 10000)
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
                // if (AIRoot.Instance.BattleData.maxAbilityTimes>1 && await ReaperSpellHelper.UseTruthNorth() != null)
                // {
                //     if (AIRoot.Instance.BattleData.maxAbilityTimes > 1)
                //         AIRoot.Instance.MuteAbilityTime();
                // }

                return spell;
            }

            return null;
        }
    }
}