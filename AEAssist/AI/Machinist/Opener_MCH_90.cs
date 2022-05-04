using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Opener;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.AI.Machinist
{
    [Opener(ClassJobType.Machinist, 90)]
    public class Opener_MCH_90 : IOpener
    {
        public int Check()
        {
            if (ActionResourceManager.Machinist.Heat >= 50)
                return -1;
            if (ActionResourceManager.Machinist.Battery >= 50)
                return -2;
            if (ActionResourceManager.Machinist.OverheatRemaining.TotalMilliseconds > 0)
                return -3;
            if (!SpellsDefine.BarrelStabilizer.IsReady())
                return -4;
            if (!SpellsDefine.ChainSaw.CoolDownInGCDs(4))
                return -5;
            if (!SpellsDefine.AutomationQueen.IsReady())
                return -6;
            if (!SpellsDefine.Hypercharge.CoolDownInGCDs(4))
                return -7;
            if (!SpellsDefine.Wildfire.CoolDownInGCDs(3))
                return -8;
            return 0;
        }

        public int StepCount => 6;

        [OpenerStep(0)]
        private SpellQueueSlot Step0()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.AirAnchor;
            slot.Abilitys.Enqueue((SpellsDefine.GaussRound, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.Ricochet, SpellTargetType.CurrTarget));
            return slot;
        }

        [OpenerStep(1)]
        private SpellQueueSlot Step1()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = MCHSpellHelper.GetDrillIfWithAOE();
            slot.Abilitys.Enqueue((SpellsDefine.BarrelStabilizer, SpellTargetType.CurrTarget));
            return slot;
        }

        [OpenerStep(2)]
        private SpellQueueSlot Step2()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();
            slot.GCDSpellId = SpellsDefine.HeatedSplitShot;
            return slot;
        }

        [OpenerStep(3)]
        private SpellQueueSlot Step3()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.HeatedSlugShot;
            slot.Abilitys.Enqueue((SpellsDefine.GaussRound, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.Ricochet, SpellTargetType.CurrTarget));

            return slot;
        }

        [OpenerStep(4)]
        private SpellQueueSlot Step4()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.HeatedCleanShot;
            slot.Abilitys.Enqueue((SpellsDefine.Reassemble, SpellTargetType.Self));
            slot.Abilitys.Enqueue((SpellsDefine.Wildfire, SpellTargetType.CurrTarget));

            return slot;
        }

        [OpenerStep(5)]
        private SpellQueueSlot Step5()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.ChainSaw;
            slot.Abilitys.Enqueue((SpellsDefine.AutomationQueen, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.Hypercharge, SpellTargetType.CurrTarget));

            return slot;
        }
    }
}