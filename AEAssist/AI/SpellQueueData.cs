using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI
{
    // 以一个GCD技能为起点
    public class SpellQueueSlot : IDisposable
    {
        public uint GCDSpellId;

        public bool GCDTargetIsSelf; // 目标是否是自己
        // 有0就说明对应的能力技槽位是空的
        public Queue<(uint spellId, bool targetIsSelf)> Abilitys = new Queue<(uint spellId, bool targetIsSelf)>();
        
        public int AnimationLockMs = 500;

        public void Dispose()
        {
            this.Abilitys.Clear();
            GCDSpellId = 0;
            AnimationLockMs = 500;
            GCDTargetIsSelf = false;
        }
    }

    public class SpellQueueData : IBattleData
    {
        public Queue<SpellQueueSlot> Queue = new Queue<SpellQueueSlot>();

        private bool isLock;
        
        public void Add(SpellQueueSlot slot)
        {
            this.Queue.Enqueue(slot);
        }

        public void Clear()
        {
            while (this.Queue.Count>0)
            {
                var val = Queue.Dequeue();
                ObjectPool.Instance.Return(val);
            }
        }

        // 返回true说明逻辑被ApplySlot接管,返回false说明需要走AI优先级队列那一套
        public async Task<bool> ApplySlot()
        {
            if (this.Queue.Count == 0)
                return false;
            // islock = true说明当前需要使用这个slot的各种能力技了
            if (isLock)
            {
                var slot = this.Queue.Peek();
                if (slot.Abilitys.Count == 0)
                {
                    isLock = false;
                    ObjectPool.Instance.Return(this.Queue.Dequeue());
                    return await ApplySlot();
                }

                var abilityId = slot.Abilitys.Peek();
                var spellData = DataManager.GetSpellData(abilityId.spellId);
                if (abilityId.spellId == 0 || spellData == null || !spellData.IsReady())
                {
                    // 配置的技能不能使用,就等个技能动画时间
                    await Coroutine.Sleep(slot.AnimationLockMs);
                    slot.Abilitys.Dequeue();
                }
                else
                {
                    var target = abilityId.targetIsSelf ? Core.Me : Core.Me.CurrentTarget;
                    if (await SpellHelper.CastAbility(spellData, target))
                    {
                        slot.Abilitys.Dequeue();
                        AIRoot.Instance.RecordAbility(spellData);
                    }
                }
                return true;
            }
            else
            {
                var slot = this.Queue.Peek();
                var spellData = DataManager.GetSpellData(slot.GCDSpellId);
                if (slot.GCDSpellId == 0 || spellData == null)
                {
                    LogHelper.Error("SlotGCDSpell Error!: "+slot.GCDSpellId);
                    ObjectPool.Instance.Return(this.Queue.Dequeue());
                    return await ApplySlot();
                }

                if (spellData.IsReady())
                {
                    var target = slot.GCDTargetIsSelf ? Core.Me : Core.Me.CurrentTarget;
                    if (await SpellHelper.CastGCD(spellData, target))
                    {
                        AIRoot.Instance.RecordGCD(spellData);
                        isLock = true;
                    }
                }
                
                return true;

            }
        }
    }
}