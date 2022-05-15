using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Opener;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.AI.Reaper
{
    [Opener(ClassJobType.Reaper, 90)]
    public class Opener_Reaper_90 : IOpener
    {
        public int Check()
        {
            if (!Core.Me.CurrentTarget.IsBoss() && PartyManager.NumMembers<=4)
                return -5;
            if (!AEAssist.DataBinding.Instance.Burst)
                return -100;
            if (!SpellsDefine.ArcaneCircle.IsReady())
                return -1;
            if (!SpellsDefine.SoulSlice.IsMaxChargeReady(0.1f))
                return -2;
            if (!SpellsDefine.Gluttony.CoolDownInGCDs(7))
                return -3;
            if (!SpellsDefine.Enshroud.IsReady())
                return -4;
            return 0;
        }

        public int StepCount => 4;

        [OpenerStep(0)]
        private SpellQueueSlot Step0()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();
            
            slot.SetGCD(ReaperSpellHelper.GetShadowOfDeath().Id,SpellTargetType.CurrTarget); 
            slot.Abilitys.Enqueue((SpellsDefine.ArcaneCircle, SpellTargetType.Self));
            return slot;
        }

        [OpenerStep(1)]
        private SpellQueueSlot Step1()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            var id = ReaperSpellHelper.CanUseSoulSlice_Scythe(Core.Me.CurrentTarget).Id;
            slot.SetGCD(id,SpellTargetType.CurrTarget); 
            return slot;
        }

        [OpenerStep(2)]
        private SpellQueueSlot Step2()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();
            var id = ReaperSpellHelper.CanUseSoulSlice_Scythe(Core.Me.CurrentTarget).Id;
            slot.SetGCD(id,SpellTargetType.CurrTarget);
            slot.UsePotion = true;
            return slot;
        }

        [OpenerStep(3)]
        private SpellQueueSlot Step3()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();
            
            slot.SetGCD( SpellsDefine.PlentifulHarvest,SpellTargetType.CurrTarget);
            slot.Abilitys.Enqueue((SpellsDefine.Enshroud, SpellTargetType.Self));
            return slot;
        }
    }
}