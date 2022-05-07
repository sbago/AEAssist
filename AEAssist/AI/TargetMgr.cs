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

    public class TargetStat
    {
        public LinkedList<(uint, long)> DamageLL = new LinkedList<(uint, long)>(); // 最近3秒内降低的血量
        public int DeathPrediction; // 预计多少ms后死亡
        public uint lastHp;
    }

    public class TargetMgr
    {
        private const int damageCalCount = 20;
        public static readonly TargetMgr Instance = new TargetMgr();

        private readonly HashSet<uint> DeleteSet = new HashSet<uint>();

        public Dictionary<uint, BattleCharacter> Enemys = new Dictionary<uint, BattleCharacter>();

        public Dictionary<uint, BattleCharacter> EnemysIn25 = new Dictionary<uint, BattleCharacter>();


        private readonly HashSet<uint> LastNpcIds = new HashSet<uint>();
        private readonly HashSet<uint> CastingSpell = new HashSet<uint>();

        //  public List<BattleCharacter> EnemysIn12 = new List<BattleCharacter>();

        public Dictionary<uint, TargetStat> TargetStats = new Dictionary<uint, TargetStat>();

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
                
                if (!unit.CanAttackUnit())
                    continue;
                
                if (SettingMgr.GetSetting<GeneralSettings>().ShowGameLog)
                {
                    if (LastNpcIds.Add(unit.NpcId)) LogHelper.Info($"Find new enemy : {unit.Name} NpcId: {unit.NpcId}");

                    if (unit.IsCasting && CastingSpell.Add(unit.CastingSpellId))
                        LogHelper.Info($"Find enemy casting spell : {unit.Name} NpcId: {unit.NpcId} " +
                                       $"CastingSpell [{unit.SpellCastInfo.Name}] [{unit.SpellCastInfo.SpellData.LocalizedName}] SpellId : {unit.SpellCastInfo.SpellData.Id} ");
                }
                Enemys.Add(unit.ObjectId, unit);
                if (!unit.ValidAttackUnit())
                    continue;
                if (!unit.NotInvulnerable())
                    continue;

                var combatReach = Core.Me.CombatReach + unit.CombatReach;

                if (Core.Me.Distance(unit) < 25 - 1 + combatReach) 
                    EnemysIn25.Add(unit.ObjectId, unit);

                // if (Core.Me.Distance(unit) < 12 - 1 + combatReach)
                // {
                //     EnemysIn12.Add(unit);
                // }
                
            }


            TTK_CalDeathPre();
        }

        private void TTK_CalDeathPre()
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().OpenTTK)
                return;
            DeleteSet.Clear();
            foreach (var v in TargetStats)
                if (!Enemys.ContainsKey(v.Key))
                    DeleteSet.Add(v.Key);

            foreach (var v in DeleteSet) TargetStats.Remove(v);

            var now = TimeHelper.Now();
            foreach (var v in Enemys)
            {
                if (!TargetStats.TryGetValue(v.Key, out var stat))
                {
                    stat = new TargetStat();
                    TargetStats[v.Key] = stat;
                }

                if (stat.lastHp == 0 || v.Value.CurrentHealth >= stat.lastHp)
                {
                    stat.lastHp = v.Value.CurrentHealth;
                    CalDeathPre(stat, v.Value);
                    continue;
                }

                var d = stat.lastHp - v.Value.CurrentHealth;
                stat.lastHp = v.Value.CurrentHealth;
                if (d >= SettingMgr.GetSetting<GeneralSettings>().TTK_IgnoreDamage)
                {
                    CalDeathPre(stat, v.Value);
                    continue;
                }

                stat.DamageLL.AddLast((d, now));
                if (stat.DamageLL.Count > damageCalCount) stat.DamageLL.RemoveFirst();


                //LogHelper.Info($"TTK {v.Value.ObjectId} Now {now} Delta {now - stat.DamageLL.First.Value.Item2}");

                CalDeathPre(stat, v.Value);
            }
        }

        private void CalDeathPre(TargetStat stat, BattleCharacter character)
        {
            uint total = 0;
            foreach (var damage in stat.DamageLL) total += damage.Item1;

            if (total == 0)
                return;

            var duration = stat.DamageLL.Last.Value.Item2 - stat.DamageLL.First.Value.Item2;
            var avgDamagePerMs = total / (float) duration;
            stat.DeathPrediction = (int) (character.CurrentHealth / avgDamagePerMs);
        }
    }
}