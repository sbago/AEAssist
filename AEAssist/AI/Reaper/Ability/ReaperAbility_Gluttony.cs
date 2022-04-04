using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.Ability
{
    public class ReaperAbility_Gluttony : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Gluttony.IsReady())
                return false;
            if (AIRoot.Instance.CloseBuff)
                return false;
            if (Core.Me.HasAura(AurasDefine.SoulReaver))
                return false;
            if (Core.Me.HasAura(AurasDefine.Enshrouded))
                return false;
            // 死亡祭祀
            if (Core.Me.HasAura(AurasDefine.BloodsownCircle))
                return false;
            // 死亡祭品
            if (Core.Me.HasAura(AurasDefine.ImmortalSacrifice))
            {
                return false;
            }
            if (ActionResourceManager.Reaper.SoulGauge < 50)
                return false;
            // 可以打附体,就不打暴食了
            if (ActionResourceManager.Reaper.ShroudGauge >= 50) return false;
            if (!Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget))
                return false;

            return true;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.Gluttony, Core.Me.CurrentTarget))
            {
                return SpellsDefine.Gluttony;
            }

            return null;
        }
    }
}