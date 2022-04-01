using System;
using System.Collections.Generic;
using System.Windows.Media.Animation;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem
{
    public class TriggerSystemMgr
    {
        public static TriggerSystemMgr Instance = new TriggerSystemMgr();

        private Dictionary<Type, ITriggerCondHandler> AllCondHandlers = new Dictionary<Type, ITriggerCondHandler>();

        private Dictionary<Type, ITriggerActionHandler> AllActionHandlers = new Dictionary<Type, ITriggerActionHandler>();

        public bool AllowTriggers { get; set; } = true;

        public TriggerSystemMgr()
        {
            var baseType = typeof(ITriggerCondHandler);
            foreach (var type in this.GetType().Assembly.GetTypes())
            {
                if(type.IsAbstract || type.IsInterface)
                    continue;
                if(!baseType.IsAssignableFrom(type))
                    continue;

                var handler = Activator.CreateInstance(type) as ITriggerCondHandler;
                this.AllCondHandlers.Add(handler.GetCondType(),Activator.CreateInstance(type) as ITriggerCondHandler);
            }
            
            baseType = typeof(ITriggerActionHandler);
            foreach (var type in this.GetType().Assembly.GetTypes())
            {
                if(type.IsAbstract || type.IsInterface)
                    continue;
                if(!baseType.IsAssignableFrom(type))
                    continue;

                var handler = Activator.CreateInstance(type) as ITriggerActionHandler;
                this.AllActionHandlers.Add(handler.GetActionType(),Activator.CreateInstance(type) as ITriggerActionHandler);
            }

        }

        public void HandleCond(ITriggerCond cond,ITriggerAction action)
        {
            if (!this.AllCondHandlers.TryGetValue(cond.GetType(), out var handler))
            {
                LogHelper.Error($"there is no cond handler for {cond.GetType().FullName}");
                return;
            }

            this.AllCondHandlers[cond.GetType()].Add(cond,action);
        }

        public void HandleAction(ITriggerAction action)
        {
            if (!AllowTriggers)
                return;
            if (!this.AllActionHandlers.TryGetValue(action.GetType(), out var handler))
            {
                LogHelper.Error($"there is no action handler for {action.GetType().FullName}");
                return;
            }

            this.AllActionHandlers[action.GetType()].Run(action);
        }

    }
}