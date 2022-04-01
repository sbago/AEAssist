using System;
using System.Threading.Tasks;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem
{
    public interface ITriggerCondHandler
    {
        Type GetCondType();
        Task Add(ITriggerCond o,ITriggerAction TriggerAction);
    }

    public abstract class ATriggerCondHandler<T> : ITriggerCondHandler where T: class,ITriggerCond
    {
        public Type GetCondType()
        {
            return typeof(T);
        }

        public async Task Add(ITriggerCond o,ITriggerAction TriggerAction)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Handle(o as T,tcs);
            var ret = await tcs.Task;
            if (ret)
                TriggerSystemMgr.Instance.HandleAction(TriggerAction);
        }

        protected abstract void Handle(T cond,TaskCompletionSource<bool> tcs);
    }
}