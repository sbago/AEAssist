using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Opener;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai
{
    [Opener(ClassJobType.Samurai,90)]
    public class Opener_Samurai_90 : IOpener
    {
        public int StepCount { get; } = 14;
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

            if (!Core.Me.CurrentTarget.IsBoss() && PartyManager.NumMembers<=4)
                return -5;
            
            return 0;
        }
        
        [OpenerStep(0)]
        private SpellQueueSlot Step0()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.Kasha;
            slot.UsePotion = true;
            return slot;
        }
        
        [OpenerStep(1)]
        private SpellQueueSlot Step1()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.Gekko;
            slot.Abilitys.Enqueue((SpellsDefine.Ikishoten, SpellTargetType.Self));
            return slot;
        }
        
        [OpenerStep(2)]
        private SpellQueueSlot Step2()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.Yukikaze;
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuKaiten,SpellTargetType.Self));
            return slot;
        }
        [OpenerStep(3)]
        private SpellQueueSlot Step3()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.MidareSetsugekka;
            slot.Abilitys.Enqueue((SpellsDefine.MeikyoShisui,SpellTargetType.Self));
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuSenei,SpellTargetType.CurrTarget));
            return slot;
        }
        [OpenerStep(4)]
        private SpellQueueSlot Step4()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.Gekko;
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuKaiten,SpellTargetType.Self));
            return slot;
        }
        [OpenerStep(5)]
        private SpellQueueSlot Step5()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.Higanbana;
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuKaiten,SpellTargetType.Self));
            return slot;
        }
        [OpenerStep(6)]
        private SpellQueueSlot Step6()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.OgiNamikiri;
            slot.Abilitys.Enqueue((SpellsDefine.Shoha,SpellTargetType.CurrTarget));
            return slot;
        }
        [OpenerStep(7)]
        private SpellQueueSlot Step7()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.KaeshiNamikiri;
            return slot;
        }
        
        [OpenerStep(8)]
        private SpellQueueSlot Step8()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.Gekko;
            return slot;
        }
        
        [OpenerStep(9)]
        private SpellQueueSlot Step9()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.Kasha;
            return slot;
        }
        
        [OpenerStep(10)]
        private SpellQueueSlot Step10()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.Hakaze;
            return slot;
        }
        
        [OpenerStep(11)]
        private SpellQueueSlot Step11()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.Yukikaze;
            slot.Abilitys.Enqueue((SpellsDefine.HissatsuKaiten,SpellTargetType.Self));
            return slot;
        }
        [OpenerStep(12)]
        private SpellQueueSlot Step12()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.MidareSetsugekka;
            return slot;
        }
        [OpenerStep(13)]
        private SpellQueueSlot Step13()
        {
            var slot = ObjectPool.Instance.Fetch<SpellQueueSlot>();

            slot.GCDSpellId = SpellsDefine.KaeshiSetsugekka;
            return slot;
        }
    }
}