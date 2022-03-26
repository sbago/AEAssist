using System.Collections.Generic;
using System.Linq;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public enum PositionalState
    {
        None,
        Front, // 前
        Flank, // 侧
        Behind, // 背
        NotAvailable // 打不到
    }
    public class TargetMgr
    {
        public static readonly TargetMgr Instance = new TargetMgr();

        public List<BattleCharacter> Enemys = new List<BattleCharacter>();

        public List<BattleCharacter> EnemysIn25 = new List<BattleCharacter>();
        
      //  public List<BattleCharacter> EnemysIn12 = new List<BattleCharacter>();

        public void Update()
        {
            var tars = GameObjectManager.GetObjectsOfType<BattleCharacter>().Where(r => (r.TaggerType > 0
                    || r.HasTarget
                    || r.IsBoss())
                && Core.Me.Distance(r) < 50);
            
            Enemys.Clear();
         //   EnemysIn12.Clear();
            EnemysIn25.Clear();

            foreach (var unit in tars)
            {
                if (!unit.ValidAttackUnit())
                    continue;

                if (!unit.NotInvulnerable())
                    continue;

                var combatReach = Core.Me.CombatReach + unit.CombatReach;

                if (Core.Me.Distance(unit) < 25 - 1 + combatReach) // -1是为了防止网络延迟导致服务器验证距离不对
                {
                    EnemysIn25.Add(unit);
                }

                // if (Core.Me.Distance(unit) < 12 - 1 + combatReach)
                // {
                //     EnemysIn12.Add(unit);
                // }


                Enemys.Add(unit);
            }
            
        }
    }
}