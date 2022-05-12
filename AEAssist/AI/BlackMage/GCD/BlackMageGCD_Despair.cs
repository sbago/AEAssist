using System;
using System.Threading.Tasks;
using AEAssist.AI.BlackMage.SpellQueue;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.GCD
{
    public class BlackMageGCD_Despair : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            // prevent redundant casting
            var BattleData = AIRoot.GetBattleData<BattleData>();
            if (BattleData.lastGCDSpell == SpellsDefine.Fire.GetSpellEntity() ||
                BattleData.lastGCDSpell == SpellsDefine.Paradox.GetSpellEntity() ||
                BattleData.lastGCDSpell == SpellsDefine.Despair.GetSpellEntity()
                )
            {
                return -1;
            }
            
            
            // if we are in fire 
            if (ActionResourceManager.BlackMage.AstralStacks > 0)
            {
                // and we have enough time to cast
                
                // Flare timing
                if (DataBinding.Instance.UseAOE)
                {
                    var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                    if (aoeCount >= ConstValue.BlackMageAOECount)
                    {
                        if (ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 4000)
                        {
                            return 0;
                        }


                    }
                }

                if (ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 2500)
                {
                    return 1;
                }
                
                if (BlackMageHelper.InstantCasting())
                {
                    return 0;
                }
            }

            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            // go combo 
            if (SpellsDefine.ManaFont.IsUnlock() &&
                SpellsDefine.ManaFont.IsReady())
            {
                if (SpellsDefine.Triplecast.IsReady())
                    AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.Triplecast.GetSpellEntity();
                AISpellQueueMgr.Instance.Apply<SpellQueue_DespairManafont>();
                await Task.CompletedTask;
                return null;
            }
            // normal
            var spell = BlackMageHelper.GetDespair();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}