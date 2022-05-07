using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Machinist.Ability
{
    public class MCHAbility_HyperCharge : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Hypercharge.IsReady())
                return -1;
            if (AIRoot.Instance.CloseBurst)
                return -2;
            if (ActionResourceManager.Machinist.Heat < 50)
                return -3;

            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return -4;

            var character = Core.Me.CurrentTarget as Character;
            if (SpellsDefine.Wildfire.RecentlyUsed() || Core.Me.HasAura(AurasDefine.WildfireBuff)) return 2;
            
            if (MCHSpellHelper.CheckReassmableGCD(2000))
                return -5;
            
            if (ActionResourceManager.Machinist.Heat >= 100)
                return 10;
            
            if (MCHSpellHelper.CheckReassmableGCD(SettingMgr.GetSetting<MCHSettings>().StrongGCDCheckTime))
                return -6;
            
            
            if (ActionResourceManager.Machinist.Heat >= 90)
                return 11;

            if (SpellsDefine.BarrelStabilizer.GetSpellEntity().Cooldown.TotalMilliseconds < 5000) return 1;


            // 25秒是积累50点热度需要的时间
            if (SpellsDefine.Wildfire.GetSpellEntity().Cooldown.TotalMilliseconds < 25000) return -6;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await SpellsDefine.Hypercharge.DoAbility()) return SpellsDefine.Hypercharge.GetSpellEntity();

            return null;
        }
    }
}