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
            slot.SetGCD(BlackMageHelper.GetDespair().Id,SpellTargetType.CurrTarget);
            if (SpellsDefine.ManaFont.IsReady())
            {
                slot.Abilitys.Enqueue((SpellsDefine.ManaFont,  SpellTargetType.Self));
            }
        }
    }
}