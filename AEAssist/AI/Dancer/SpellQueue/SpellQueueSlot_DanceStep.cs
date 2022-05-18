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
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            var steps = ActionResourceManager.Dancer.Steps;
            foreach (var step in steps)
            {
                var spell = DancerSpellHelper.GetDanceStep(step);
                slot.GCDEnqueue((spell.Id, SpellTargetType.Self));
            }

        }
    }
}