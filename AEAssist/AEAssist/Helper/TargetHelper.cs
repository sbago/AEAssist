using AEAssist.AI;
using AEAssist.Define;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.Helper
{
    public static class TargetHelper
    {
        public static bool ValidAttackUnit(this GameObject unit)
        {
            return unit != null && unit.IsValid && unit.IsTargetable && unit.CanAttack && unit.CurrentHealth > 0;
        }
        
        public static bool NotInvulnerable(this GameObject unit)
        {
            return unit != null && !unit.HasAnyAura(AurasDefine.Invincibility);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetRange"> 目标和自己的距离</param>
        /// <param name="damageRange"> 目标和他周围单位的距离</param>
        /// <returns></returns>
        public static bool CheckNeedUseAOE(int targetRange,int damageRange,int needCount = 3)
        {
            if (Core.Me.CurrentTarget.Distance(Core.Me) >= targetRange)
                return false;
            var list = TargetMgr.Instance.EnemysIn25;
            int count = 0;
            foreach (var v in list)
            {
                if (v.Distance(Core.Me.CurrentTarget) <= damageRange)
                    count++;
            }

            if (count >= needCount)
                return true;
            return false;
        }
    }
}