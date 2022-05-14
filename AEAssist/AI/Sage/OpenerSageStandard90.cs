/*using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Opener;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.AI.Sage
{
    [Opener(ClassJobType.Sage, 90)]
    public class OpenerSageStandard90 : IOpener
    {
        public int StepCount { get; } = 1;
        public int Check()
        {
            if (!Core.Me.CurrentTarget.IsBoss() && PartyManager.NumMembers<=4)
                return -5;

            return 0;
        }
        
        [OpenerStep(0)]
        private SpellQueueSlot Step0()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.DosisIII;
            return slot;
        }
    }
}*/