using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SpellQueueSlot : Entity
    {
        // spellId == 0, mean wait {AnimationLockMs}
        public Queue<(uint spellId, SpellTargetType SpellTargetType)> Abilitys =
            new Queue<(uint spellId, SpellTargetType SpellTargetType)>();

        public int AnimationLockMs = 0;
        private uint GCDSpellId;

        public SpellTargetType SpellTargetType;
        public BattleCharacter BattleCharacter;

        public bool UsePotion;

        public int Index;

        public void SetGCD(uint spellId, SpellTargetType targetType)
        {
            this.GCDSpellId = spellId;
            this.SpellTargetType = targetType;
        }
        public void SetGCD(uint spellId, BattleCharacter target)
        {
            this.GCDSpellId = spellId;
            this.SpellTargetType = SpellTargetType.SpecifyTarget;
            this.BattleCharacter = target;
        }

        public void ClearGCD()
        {
            this.GCDSpellId = 0;
        }

        public void EnqueueAbility(uint spellId, SpellTargetType spellTargetType)
        {
            this.Abilitys.Enqueue((spellId, spellTargetType));
        }

        public uint GetGCDSpell()
        {
            return this.GCDSpellId;
        }

        protected override void OnDestroy()
        {
            Abilitys.Clear();
            GCDSpellId = 0;
            UsePotion = false;
            Index = 0;
            AnimationLockMs = 0;
            SpellTargetType = SpellTargetType.CurrTarget;
            BattleCharacter = null;
        }
    }

    public class SpellQueueData : IBattleData
    {
        private bool isLock;
        public Queue<SpellQueueSlot> Queue = new Queue<SpellQueueSlot>();

        public void Add(SpellQueueSlot slot)
        {
            Queue.Enqueue(slot);
        }

        public void Clear()
        {
            while (Queue.Count > 0)
            {
                var val = Queue.Dequeue();
                ObjectPool.Instance.Return(val);
            }
        }
        
        public async Task<bool> ApplySlot()
        {
            if (Queue.Count == 0)
                return false;
            if (isLock)
            {
                var slot = Queue.Peek();


                if (slot.Abilitys.Count == 0)
                {
                    if (slot.UsePotion)
                    {
                        await AIMgrs.Instance.UsePotion(Core.Me.CurrentJob);
                        isLock = false;
                        ObjectPool.Instance.Return(Queue.Dequeue());
                        return await ApplySlot();
                    }
                    isLock = false;
                    ObjectPool.Instance.Return(Queue.Dequeue());
                    return await ApplySlot();
                }

                var abilityId = slot.Abilitys.Peek();
                var spellData = SpellEntity.Create(abilityId.spellId);
                if (abilityId.spellId == 0 || spellData.SpellData == null || !spellData.IsReady())
                {
                    await Coroutine.Sleep(slot.AnimationLockMs);
                    slot.Abilitys.Dequeue();
                }
                else
                {
                    var spellEntity = new SpellEntity(spellData.Id, slot.SpellTargetType);

                    if (await spellEntity.DoAbility())
                    {
                        slot.Abilitys.Dequeue();
                        AIRoot.Instance.RecordAbility(spellData);
                    }
                }

                return true;
            }
            else
            {
                var slot = Queue.Peek();
                var spellData = DataManager.GetSpellData(slot.GetGCDSpell());
                if (slot.GetGCDSpell() == 0 || spellData == null)
                {
                    ObjectPool.Instance.Return(Queue.Dequeue());
                    return await ApplySlot();
                }
                LogHelper.Debug($"Slot GCD: {spellData.LocalizedName} Ready: {spellData.IsReady()} {AIRoot.Instance.CanUseGCD()}");
                if (spellData.IsReady() && AIRoot.Instance.CanUseGCD())
                {
                    SpellEntity spellEntity = null;
                    if (slot.SpellTargetType == SpellTargetType.SpecifyTarget)
                    {
                        spellEntity = new SpellEntity(spellData.Id, slot.BattleCharacter);
                    }
                    else
                    {
                        spellEntity = new SpellEntity(spellData.Id, slot.SpellTargetType);
                    }
                    if (await spellEntity.DoGCD())
                    {
                        AIRoot.Instance.RecordGCD(spellEntity);
                        isLock = true;
                    }
                }

                return true;
            }
        }
    }
}