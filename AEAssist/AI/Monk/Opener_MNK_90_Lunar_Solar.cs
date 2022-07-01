﻿using System;
using System.Collections.Generic;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Opener;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.AI.Monk
{
    [Opener(ClassJobType.Monk, 90)]
    public class Opener_Monk_90 : IOpener
    {
        public int Check()
        {
            // if (PartyManager.NumMembers <= 4)
            //     return -5;
            if (!AEAssist.DataBinding.Instance.Burst)
                return -100;
            if (!SpellsDefine.RiddleofFire.IsReady())
                return -4;
            if (!SpellsDefine.Brotherhood.IsReady())
                return -4;
            if (!SpellsDefine.PerfectBalance.IsMaxChargeReady())
                return -6;
            return 0;
        }

        public List<Action<SpellQueueSlot>> Openers { get; } = new List<Action<SpellQueueSlot>>()
        {
            StepPre,
            Step0,
            Step1,
            Step2,
            Step3,
            Step4,
            // Step5,
            // Step6
        };

        private static void StepPre(SpellQueueSlot slot)
        {
            AIRoot.GetBattleData<MonkBattleData>().DoingOpener = true;
            if (!ActionManager.CanCastOrQueue(SpellsDefine.Bootshine.GetSpellEntity().SpellData, Core.Me.CurrentTarget))
            {
                slot.Abilitys.Enqueue((SpellsDefine.Thunderclap, SpellTargetType.CurrTarget));
            }
        }

        private static void Step0(SpellQueueSlot slot)
        {
            var spell = SpellsDefine.DragonKick;
            if (TargetHelper.CheckNeedUseAOEByMe(5, 5, 3))
            {
                if (SpellsDefine.ShadowOfTheDestroyer.IsUnlock())
                {
                    spell = SpellsDefine.ShadowOfTheDestroyer;
                }
            }
            slot.SetGCD(spell, SpellTargetType.CurrTarget);
            slot.UsePotion = true;
            MeleePosition.Intance.SetPositionToBack(MeleePosition.Priority.High);
            MeleePosition.Intance.ShowMsg();
        }


        private static void Step1(SpellQueueSlot slot)
        {
            var spell = SpellsDefine.TwinSnakes;
            if (TargetHelper.CheckNeedUseAOEByMe(5, 5, 3))
            {
                spell = SpellsDefine.FourPointFury;
            }
            slot.SetGCD(spell, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.LegSweep, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.RiddleofFire, SpellTargetType.Self));
        }


        private static void Step2(SpellQueueSlot slot)
        {
            slot.SetGCD(SpellsDefine.Demolish, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.TheForbiddenChakra, SpellTargetType.CurrTarget));
        }


        private static void Step3(SpellQueueSlot slot)
        {
            var spell = SpellsDefine.Bootshine;
            if (TargetHelper.CheckNeedUseAOEByMe(5, 5, 3))
            {
                if (SpellsDefine.ShadowOfTheDestroyer.IsUnlock())
                {
                    spell = SpellsDefine.ShadowOfTheDestroyer;
                }
            }
            slot.SetGCD(spell, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.Brotherhood, SpellTargetType.Self));
            slot.Abilitys.Enqueue((SpellsDefine.PerfectBalance, SpellTargetType.Self));
        }


        private static void Step4(SpellQueueSlot slot)
        {
            AIRoot.GetBattleData<MonkBattleData>().DoingOpener = false;
            var spell = SpellsDefine.DragonKick;
            if (TargetHelper.CheckNeedUseAOEByMe(5, 5, 3))
            {
                if (SpellsDefine.ShadowOfTheDestroyer.IsUnlock())
                {
                    spell = SpellsDefine.ShadowOfTheDestroyer;
                }
            }
            slot.SetGCD(spell, SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.RiddleofWind, SpellTargetType.Self));
            AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
        }


        // private static void Step5(SpellQueueSlot slot)
        // {
        //     slot.SetGCD(SpellsDefine.Bootshine, SpellTargetType.CurrTarget);
        // }
        //
        // private static void Step6(SpellQueueSlot slot)
        // {
        //     slot.SetGCD(SpellsDefine.DragonKick, SpellTargetType.CurrTarget);
        // }
    }
}