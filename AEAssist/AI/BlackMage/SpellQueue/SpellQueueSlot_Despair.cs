using System;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueueSlot_Despair : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 1;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.GCDSpellId = BlackMageHelper.GetDespair().Id;
            if (BlackMageHelper.GetSpellCastTimeSpan(BlackMageHelper.GetDespair()) == TimeSpan.Zero)
            {
                slot.Abilitys.Enqueue((SpellsDefine.ManaFont,  SpellTargetType.Self));
            }
        }
    }
}