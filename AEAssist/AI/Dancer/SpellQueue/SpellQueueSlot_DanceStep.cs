using System.Collections.Generic;
using System.Windows.Forms;
using AEAssist.AI.Sage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Dancer.SpellQueue
{
    public class SpellQueueSlot_DanceStep : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            var bdls = AIRoot.GetBattleData<BattleData>().lastGCDSpell;
            if (bdls == SpellsDefine.DoubleStandardFinish.GetSpellEntity() ||
                bdls == SpellsDefine.QuadrupleTechnicalFinish.GetSpellEntity() ||
                (!Core.Me.HasAura(AurasDefine.StandardStep) && !Core.Me.HasAura(AurasDefine.TechnicalStep))
               )
            {
                return -10;
            }


            if (bdls == SpellsDefine.StandardStep.GetSpellEntity() ||
                bdls == SpellsDefine.TechnicalStep.GetSpellEntity() ||
                Core.Me.HasAura(AurasDefine.StandardStep) ||
                Core.Me.HasAura(AurasDefine.TechnicalStep))
            {
                return 0;
            }

            return -4;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.SetBreakCondition(()=>this.Check(0));
            foreach (var v in ActionResourceManager.Dancer.Steps)
            {
                if(v == ActionResourceManager.Dancer.DanceStep.Finish)
                    continue;
                var spell = DancerSpellHelper.GetDanceStep(v);
                LogHelper.Info($"Queue Step: {v} {spell.SpellData.LocalizedName}");
                slot.EnqueueGCD((spell.Id, SpellTargetType.Self));
            }
        }
    }
}