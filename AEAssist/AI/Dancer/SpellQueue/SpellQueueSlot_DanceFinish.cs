using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Dancer.SpellQueue
{
    public class SpellQueueSlot_DanceFinish : IAISpellQueueSlot
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
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            try
            {
                if (Core.Me.HasAura(AurasDefine.StandardStep))
                {
                    slot.SetGCD(SpellsDefine.DoubleStandardFinish.GetSpellEntity().Id, SpellTargetType.Self);
                }
                else
                {
                    slot.SetGCD(SpellsDefine.QuadrupleTechnicalFinish.GetSpellEntity().Id, SpellTargetType.Self);
                    if (SpellsDefine.Devilment.IsReady())
                    {
                        slot.EnqueueAbility((SpellsDefine.Devilment.GetSpellEntity().Id, SpellTargetType.Self));
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}