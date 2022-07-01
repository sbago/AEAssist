﻿using System;
using System.Collections.Generic;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Opener;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai
{
    [Opener(ClassJobType.Samurai, 90)]
    public class Opener_Samurai_90 : IOpener
    {
        public int Check()
        {
            if (!Core.Me.HasMyAuraWithTimeleft(AurasDefine.MeikyoShisui))
            {
                return -1;
            }

            if (!SpellsDefine.MeikyoShisui.IsReady())
                return -2;
            if (!SpellsDefine.Ikishoten.IsReady())
                return -3;
            if (!SpellsDefine.HissatsuSenei.IsReady())
                return -4;

            if (!Core.Me.CurrentTarget.IsBoss() && PartyManager.NumMembers <= 4)
                return -5;

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
            Step11,
            Step12,
            Step13,
            Step14
        };


        private static void Step0(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Gekko, SpellTargetType.CurrTarget);
            slot.UsePotion = true;
        }


        private static void Step1(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Kasha, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.Ikishoten, SpellTargetType.CurrTarget));
        }

        private static void Step2(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Yukikaze, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuShinten, SpellTargetType.CurrTarget));
        }

        private static void Step3(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.MidareSetsugekka, SpellTargetType.CurrTarget);
        }

        private static void Step4(SpellQueueSlot slot)
        {
            slot.Abilitys.Enqueue((SpellsDefine.KaeshiSetsugekka, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuSenei, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.MeikyoShisui, SpellTargetType.Self));
        }

        private static void Step5(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Gekko, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuShinten, SpellTargetType.CurrTarget));
        }
        
        private static void Step6(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Higanbana, SpellTargetType.CurrTarget);
        }
        
        private static void Step7(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Kasha, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuShinten, SpellTargetType.CurrTarget));
        }
        
        private static void Step8(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.OgiNamikiri, SpellTargetType.CurrTarget);
        }
        
        private static void Step9(SpellQueueSlot slot)
        {
            slot.Abilitys.Enqueue((SpellsDefine.KaeshiNamikiri, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.Shoha, SpellTargetType.CurrTarget));
        }
        
        private static void Step10(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Gekko, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuShinten, SpellTargetType.CurrTarget));
        }
        
        private static void Step11(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Hakaze, SpellTargetType.CurrTarget);
        }
        
        private static void Step12(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Yukikaze, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuShinten, SpellTargetType.CurrTarget));
        }
        
        private static void Step13(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.MidareSetsugekka, SpellTargetType.CurrTarget);
        }
        
        private static void Step14(SpellQueueSlot slot)
        {
            slot.Abilitys.Enqueue((SpellsDefine.KaeshiSetsugekka, SpellTargetType.CurrTarget));
        }
    }
}