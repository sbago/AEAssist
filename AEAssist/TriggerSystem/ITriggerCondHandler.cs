using System;
using System.Threading.Tasks;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem
{
    public interface ITriggerCondHandler
    {
        Type GetCondType();
        bool Handle(ITriggerCond o);
    }

    public abstract class ATriggerCondHandler<T> : ITriggerCondHandler where T: class,ITriggerCond
    {
        public Type GetCondType()
        {
            return typeof(T);
        }

        public bool Handle(ITriggerCond o)
        {
            return Check(o as T);
        }

        protected abstract bool Check(T cond);
    }
}