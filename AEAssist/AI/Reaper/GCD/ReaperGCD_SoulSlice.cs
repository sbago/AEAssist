using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.GCD
{
    public class ReaperGCD_SoulSlice : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.SoulSlice.IsChargeReady())
                return -1;

            if (ActionResourceManager.Reaper.SoulGauge > 50)
                return -2;
            return 0;
        }

        public async Task<SpellData> Run()
        {
            if(SpellsDefine.SoulSlice.Charges<SpellsDefine.SoulSlice.MaxCharges
            && ReaperSpellHelper.ReadyToEnshroud()>=0)
            {
                if (TargetHelper.CheckNeedUseAOE(Core.Me.CurrentTarget, 5, 5))
                {
                    if (AIRoot.Instance.ReaperBattleData.CurrCombo == ReaperComboStages.NightmareScythe)
                    {
                        if (await SpellHelper.CastGCD(SpellsDefine.NightmareScythe, Core.Me.CurrentTarget))
                        {
                            AIRoot.Instance.ReaperBattleData.CurrCombo = ReaperComboStages.SpinningScythe;
                            return SpellsDefine.NightmareScythe;
                        }
                    }
                }
                else
                {
                    if (AIRoot.Instance.ReaperBattleData.CurrCombo == ReaperComboStages.InfernalSlice)
                    {
                        if (await SpellHelper.CastGCD(SpellsDefine.InfernalSlice, Core.Me.CurrentTarget))
                        {
                            AIRoot.Instance.ReaperBattleData.CurrCombo = ReaperComboStages.Slice;
                            return SpellsDefine.InfernalSlice;
                        }
                    }
                    else if (AIRoot.Instance.ReaperBattleData.CurrCombo == ReaperComboStages.WaxingSlice)
                    {
                        if (await SpellHelper.CastGCD(SpellsDefine.WaxingSlice, Core.Me.CurrentTarget))
                        {
                            AIRoot.Instance.ReaperBattleData.CurrCombo = ReaperComboStages.InfernalSlice;
                            return SpellsDefine.WaxingSlice;
                        }
                    }
                }

            }
            
            SpellData spell = ReaperSpellHelper.CanUseSoulSlice_Scythe(Core.Me.CurrentTarget);
            if (spell == null)
                return null;
            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
            {
                return spell;
            }

            return null;
        }
    }
}