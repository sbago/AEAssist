using System;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.SpellQueue
{
    public class SpellQueueSlot_KaeshiSetsugekka : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {   
            if (SpellsDefine.KaeshiSetsugekka.GetSpellEntity().SpellData.Charges > 0.99)
            slot.SetGCDQueue((SpellsDefine.MidareSetsugekka, SpellTargetType.CurrTarget),
                (SpellsDefine.KaeshiSetsugekka, SpellTargetType.CurrTarget));
            
        }
    }
}