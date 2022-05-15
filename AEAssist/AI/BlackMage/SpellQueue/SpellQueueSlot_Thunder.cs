using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueueSlot_Thunder : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            if (BlackMageHelper.ThunderCheck() >= 0 &&
                Core.Me.CurrentMana >=1200)
            {
                slot.GCDSpellId = BlackMageHelper.GetThunder().Id;
            }
            else
            {
                slot.GCDSpellId = 0;
            }
            if (slot.GCDSpellId != 0 &&
                SpellsDefine.ManaFont.IsReady())
            {
                slot.Abilitys.Enqueue((SpellsDefine.ManaFont,  SpellTargetType.Self));
            }
        }
    }
}