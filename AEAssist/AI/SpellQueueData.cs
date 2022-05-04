using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI
{
    public class SpellQueueSlot : Entity
    {
        // spellId == 0, mean wait {AnimationLockMs}
        public Queue<(uint spellId, SpellTargetType SpellTargetType)> Abilitys =
            new Queue<(uint spellId, SpellTargetType SpellTargetType)>();

        public int AnimationLockMs = 500;
        public uint GCDSpellId;

        public SpellTargetType SpellTargetType;

        public bool UsePotion;

        protected override void OnDestroy()
        {
            Abilitys.Clear();
            GCDSpellId = 0;
            UsePotion = false;
            AnimationLockMs = 500;
            SpellTargetType = SpellTargetType.CurrTarget;
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

        // 返回true说明逻辑被ApplySlot接管,返回false说明需要走AI优先级队列那一套
        public async Task<bool> ApplySlot()
        {
            if (Queue.Count == 0)
                return false;
            // islock = true说明当前需要使用这个slot的各种能力技了
            if (isLock)
            {
                var slot = Queue.Peek();
                if (slot.UsePotion)
                {
                    await AIMgrs.Instance.UsePotion(Core.Me.CurrentJob);
                    isLock = false;
                    ObjectPool.Instance.Return(Queue.Dequeue());
                    return await ApplySlot();
                }

                if (slot.Abilitys.Count == 0)
                {
                    isLock = false;
                    ObjectPool.Instance.Return(Queue.Dequeue());
                    return await ApplySlot();
                }

                var abilityId = slot.Abilitys.Peek();
                var spellData = SpellEntity.Create(abilityId.spellId);
                if (abilityId.spellId == 0 || spellData.SpellData == null || !spellData.IsReady())
                {
                    // 配置的技能不能使用,就等个技能动画时间
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
                var spellData = DataManager.GetSpellData(slot.GCDSpellId);
                if (slot.GCDSpellId == 0 || spellData == null)
                {
                    LogHelper.Error("SlotGCDSpell Error!: " + slot.GCDSpellId);
                    ObjectPool.Instance.Return(Queue.Dequeue());
                    return await ApplySlot();
                }

                if (spellData.IsReady())
                {
                    var spellEntity = new SpellEntity(spellData.Id, slot.SpellTargetType);
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