using System;

namespace AEAssist.TriggerSystem
{
    public interface ITriggerActionHandler
    {
        Type GetActionType();
        void Run(ITriggerAction TriggerAction);
    }

    public abstract class ATriggerActionHandler<T> : ITriggerActionHandler where T : class, ITriggerAction
    {
        public Type GetActionType()
        {
            return typeof(T);
        }

        public void Run(ITriggerAction TriggerAction)
        {
            Handle(TriggerAction as T);
        }

        protected abstract void Handle(T t);
    }
}