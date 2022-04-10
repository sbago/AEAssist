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
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.BloodStalk.IsUnlock())
                return -1;
            if (!DataBinding.Instance.UseSoulGauge)
                return -2;
            if (ActionResourceManager.Reaper.SoulGauge < 50)
                return -3;
            if (Core.Me.HasAura(AurasDefine.SoulReaver))
                return -4;
            if (SpellsDefine.Enshroud.Cooldown.TotalMilliseconds > 0
                && SpellsDefine.Enshroud.Cooldown.TotalMilliseconds < 5000
                && ReaperSpellHelper.ReadyToEnshroud() >= 0)
                return -5;

            if (TimeHelper.Now() - SpellHistoryHelper.GetLastSpellTime(SpellsDefine.Enshroud.Id) < 3000)
                return -6;
            if (SpellsDefine.Enshroud.RecentlyUsed() || Core.Me.HasAura(AurasDefine.Enshrouded))
                return -7;
            if (!AIRoot.Instance.CloseBuff && SpellsDefine.Gluttony.Cooldown.TotalMilliseconds < 10000) return -8;

            if (!Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget))
                return -9;
            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = SpellsDefine.BloodStalk;
            if (SpellsDefine.GrimSwathe.IsUnlock() && TargetHelper.CheckNeedUseAOE(8, 8))
                spell = SpellsDefine.GrimSwathe;

            if (await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget))
                // if (AIRoot.Instance.BattleData.maxAbilityTimes>1 && await ReaperSpellHelper.UseTruthNorth() != null)
                // {
                //     if (AIRoot.Instance.BattleData.maxAbilityTimes > 1)
                //         AIRoot.Instance.MuteAbilityTime();
                // }

                return spell;

            return null;
        }
    }
}