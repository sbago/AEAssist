using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.MCH
{
    public class MCHAbility_HyperCharge : IAIHandler
    {
        public int Check(SpellData lastSpell)
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
            if (SpellsDefine.Wildfire.RecentlyUsed() || Core.Me.HasAura(AurasDefine.WildfireBuff))
            {
                return 2;
            }
            
            if (MCHSpellHelper.CheckReassmableGCD(SettingMgr.GetSetting<MCHSettings>().StrongGCDCheckTime))
                return -5;
            
            if (ActionResourceManager.Machinist.Heat >= 95)
                return 10;
            
            if (SpellsDefine.BarrelStabilizer.Cooldown.TotalMilliseconds<5000)
            {
                return 1;
            }


            // 25秒是积累50点热度需要的时间
            if (SpellsDefine.Wildfire.Cooldown.TotalMilliseconds < 25000)
            {
                return -6;
            }

            return 0;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.Hypercharge, Core.Me))
            {
                AIRoot.GetBattleData<MCHBattleData>().HyperchargeGCDCount = 5;
                return SpellsDefine.Hypercharge;
            }

            return null;
        }
    }
}