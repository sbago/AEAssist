
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Opener;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.AI.Machinist
{
    [Opener(ClassJobType.Machinist, 80)]
    public class Opener_MCH_80 : IOpener
    {
        public int Check()
        {
            if (!Core.Me.CurrentTarget.IsBoss() && PartyManager.NumMembers<=4)
                return -5;
            if (ActionResourceManager.Machinist.Heat >= 50)
                return -1;
            if (ActionResourceManager.Machinist.Battery >= 50)
                return -2;
            if (ActionResourceManager.Machinist.OverheatRemaining.TotalMilliseconds > 0)
                return -3;
            if (!SpellsDefine.BarrelStabilizer.IsReady())
                return -4;
            if (!SpellsDefine.AutomationQueen.IsReady())
                return -6;
            if (!SpellsDefine.Hypercharge.CoolDownInGCDs(4))
                return -7;
            if (!SpellsDefine.Wildfire.CoolDownInGCDs(3))
                return -8;
            return 0;
        }

        public int StepCount => 5;

        [OpenerStep(0)]
        private SpellQueueSlot Step0()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.AirAnchor,SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.GaussRound, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.Ricochet, SpellTargetType.CurrTarget));
            return slot;
        }

        [OpenerStep(1)]
        private SpellQueueSlot Step1()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.Drill,SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.BarrelStabilizer, SpellTargetType.CurrTarget));
            return slot;
        }

        [OpenerStep(2)]
        private SpellQueueSlot Step2()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();
            slot.SetGCD(SpellsDefine.SplitShot,SpellTargetType.CurrTarget);
            return slot;
        }

        [OpenerStep(3)]
        private SpellQueueSlot Step3()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.SlugShot,SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.GaussRound, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.Ricochet, SpellTargetType.CurrTarget));

            return slot;
        }

        [OpenerStep(4)]
        private SpellQueueSlot Step4()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.HeatedCleanShot,SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.Hypercharge, SpellTargetType.CurrTarget));
            slot.Abilitys.Enqueue((SpellsDefine.Wildfire, SpellTargetType.CurrTarget));

            return slot;
        }
    }
}