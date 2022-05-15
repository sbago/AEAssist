using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueueSlot_Xenoglossy : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.SetGCD(0, SpellTargetType.CurrTarget);

            if (ActionResourceManager.BlackMage.PolyglotCount > 0 &&
                SpellsDefine.ManaFont.IsReady())
            {
                if (BlackMageHelper.ThunderCheck() < 0)
                {
                    slot.SetGCD(BlackMageHelper.GetXenoglossy().Id, SpellTargetType.CurrTarget);
                }
                else if (!Core.Me.HasAura(AurasDefine.ThunderCloud))
                {
                    slot.SetGCD(BlackMageHelper.GetXenoglossy().Id, SpellTargetType.CurrTarget);

                }
            }

            if (slot.GetGCDSpell() != 0 &&
                SpellsDefine.ManaFont.IsReady())
            {
                slot.Abilitys.Enqueue((SpellsDefine.ManaFont,  SpellTargetType.Self));
            }
        }
    }
}