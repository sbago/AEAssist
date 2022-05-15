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
        public int StepCount { get; } = 12;
        public int Check()
        {
            /*if (!Core.Me.CurrentTarget.IsBoss() && PartyManager.NumMembers<=4)
                return -5;*/

            return 0;
        }
        
        [OpenerStep(0)]
        private SpellQueueSlot Step0()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.Eukrasia,SpellTargetType.Self); 
            return slot;
        }
        
        [OpenerStep(1)]
        private SpellQueueSlot Step1()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.EukrasianDosisIII,SpellTargetType.CurrTarget); 
            return slot;
        }
        
        [OpenerStep(2)]
        private SpellQueueSlot Step2()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.DosisIII,SpellTargetType.CurrTarget); 
            return slot;
        }
        
        [OpenerStep(3)]
        private SpellQueueSlot Step3()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.DosisIII,SpellTargetType.CurrTarget); 
            return slot;
        }

        [OpenerStep(4)]
        private SpellQueueSlot Step4()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            if (Core.Me.Distance(Core.Me.CurrentTarget) < 6)
                slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
            else
                slot.SetGCD(SpellsDefine.PhlegmaIII, SpellTargetType.CurrTarget);
            return slot;
        }

        [OpenerStep(5)]
        private SpellQueueSlot Step5()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.DosisIII,SpellTargetType.CurrTarget); 
            return slot;
        }
        
        [OpenerStep(6)]
        private SpellQueueSlot Step6()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();
            if (Core.Me.Distance(Core.Me.CurrentTarget) < 6)
                slot.SetGCD(SpellsDefine.DosisIII, SpellTargetType.CurrTarget);
            else
                slot.SetGCD(SpellsDefine.PhlegmaIII, SpellTargetType.CurrTarget);
            return slot;
        }
        
        [OpenerStep(7)]
        private SpellQueueSlot Step7()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.DosisIII,SpellTargetType.CurrTarget); 
            return slot;
        }
        
        [OpenerStep(8)]
        private SpellQueueSlot Step8()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.DosisIII,SpellTargetType.CurrTarget); 
            return slot;
        }
        
        [OpenerStep(9)]
        private SpellQueueSlot Step9()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.DosisIII,SpellTargetType.CurrTarget); 
            return slot;
        }
        
        [OpenerStep(10)]
        private SpellQueueSlot Step10()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.DosisIII,SpellTargetType.CurrTarget); 
            return slot;
        }
        
        [OpenerStep(11)]
        private SpellQueueSlot Step11()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.SetGCD(SpellsDefine.ToxikonII,SpellTargetType.CurrTarget); 
            return slot;
        }
    }
}