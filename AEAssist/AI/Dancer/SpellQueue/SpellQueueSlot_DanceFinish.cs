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
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}