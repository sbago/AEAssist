using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AETriggers.TriggerModel;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.Ability
{
    public class ReaperAbility_Gluttony : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Gluttony.IsReady())
                return -1;
            if (AIRoot.Instance.CloseBuff)
                return -2;
            if (Core.Me.HasAura(AurasDefine.SoulReaver))
                return -3;
            if (SpellsDefine.Enshroud.RecentlyUsed() ||Core.Me.HasAura(AurasDefine.Enshrouded))
                return -4;
            if(TimeHelper.Now() - SpellHistoryHelper.GetLastSpellTime(SpellsDefine.Enshroud.Id) < 3000)
                return -5;
            // 死亡祭祀
            if (Core.Me.HasAura(AurasDefine.BloodsownCircle))
                return -6;
            // 死亡祭品
            if (Core.Me.HasAura(AurasDefine.ImmortalSacrifice))
            {
                return -7;
            }
            if (ActionResourceManager.Reaper.SoulGauge < 50)
                return -8;
            // 可以打附体,就不打暴食了
            var ret = ReaperSpellHelper.ReadyToEnshroud();
            if (ret >= 0)
                return -9;
            if (!Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget))
                return -10;

            return 0;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.Gluttony, Core.Me.CurrentTarget))
            {
                // if (AIRoot.Instance.BattleData.maxAbilityTimes>0 && await ReaperSpellHelper.UseTruthNorth() != null)
                // {
                //     if (AIRoot.Instance.BattleData.maxAbilityTimes > 1)
                //         AIRoot.Instance.MuteAbilityTime();
                // }

                return SpellsDefine.Gluttony;
            }

            return null;
        }
    }
}