using System;
using System.Collections.Generic;
using AEAssist.Define;
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
        public int Check()
        {
            /*if (!Core.Me.CurrentTarget.IsBoss() && PartyManager.NumMembers<=4)
                return -5;*/

            return 0;
        }

        public List<Action<SpellQueueSlot>> Openers { get; } = new List<Action<SpellQueueSlot>>()
        {
            Step0,
            Step1,
            Step2,
            Step3,
            Step4,
            Step5,
            Step6,
            Step7,
            Step8,
            Step9,
            Step10,
            Step11
        };


        private static void Step0(SpellQueueSlot slot)
        {
            slot.SetGCDQueue((SpellsDefine.Eukrasia, SpellTargetType.Self),
                (SpellsDefine.EukrasianDosisIII, SpellTargetType.CurrTarget));
        }


        private static void Step1(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
        }


        private static void Step2(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
        }


        private static void Step3(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
        }


        private static void Step4(SpellQueueSlot slot)
        {
            if (Core.Me.Distance(Core.Me.CurrentTarget) < 6)
                slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
            else
                slot.SetGCD(SpellsDefine.PhlegmaIII, SpellTargetType.CurrTarget);
        }


        private static void Step5(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
        }


        private static void Step6(SpellQueueSlot slot)
        {
            if (Core.Me.Distance(Core.Me.CurrentTarget) < 6)
                slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
            else
                slot.SetGCD(SpellsDefine.PhlegmaIII, SpellTargetType.CurrTarget);
        }


        private static void Step7(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
        }


        private static void Step8(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
        }


        private static void Step9(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
        }


        private static void Step10(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
        }


        private static void Step11(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.ToxikonII, SpellTargetType.CurrTarget);
        }
    }
}