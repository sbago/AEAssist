using System;
using System.Collections.Generic;

namespace AETriggers.TriggerModel
{
    public class TriggerMgr
    {
        public static TriggerMgr Instance = new TriggerMgr();

        public HashSet<Type> AllCondType = new HashSet<Type>();

        public HashSet<Type> AllActionType = new HashSet<Type>();

        public TriggerMgr()
        {
            var baseType = typeof(ITriggerBase);
            var condType = typeof(ITriggerCond);
            var actionType = typeof(ITriggerAction);
            foreach (var type in this.GetType().Assembly.GetTypes())
            {
                if(type.IsAbstract || type.IsInterface)
                    continue;
                if(!baseType.IsAssignableFrom(type))
                    continue;

                if (condType.IsAssignableFrom(type))
                {
                    this.AllCondType.Add(type);
                }
                else
                {
                    this.AllActionType.Add(type);
                }
            }
        }
    }
}