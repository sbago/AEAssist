using System.Collections.Generic;
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
            var step = ActionResourceManager.Dancer.CurrentStep;
            if (step != ActionResourceManager.Dancer.DanceStep.Finish)
            {
                var spell = DancerSpellHelper.GetDanceStep(step);
                slot.GCDEnqueue((spell.Id, SpellTargetType.Self));
            }
        }
    }
}