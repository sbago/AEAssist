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

        private Dictionary<Type, ITriggerActionHandler> AllActionHandlers =
            new Dictionary<Type, ITriggerActionHandler>();

        public bool AllowTriggers { get; set; } = true;

        public TriggerSystemMgr()
        {
            var baseType = typeof(ITriggerCondHandler);
            foreach (var type in this.GetType().Assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;
                if (!baseType.IsAssignableFrom(type))
                    continue;

                var handler = Activator.CreateInstance(type) as ITriggerCondHandler;
                this.AllCondHandlers.Add(handler.GetCondType(), Activator.CreateInstance(type) as ITriggerCondHandler);
            }

            baseType = typeof(ITriggerActionHandler);
            foreach (var type in this.GetType().Assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;
                if (!baseType.IsAssignableFrom(type))
                    continue;

                var handler = Activator.CreateInstance(type) as ITriggerActionHandler;
                this.AllActionHandlers.Add(handler.GetActionType(),
                    Activator.CreateInstance(type) as ITriggerActionHandler);
            }
        }

        public bool HandleTriggers(Trigger trigger)
        {
            foreach (var v in trigger.TriggerConds)
            {
                if (!this.HandleCond(v))
                    return false;
            }

            foreach (var v in trigger.TriggerActions)
            {
                this.HandleAction(v);
            }

            return true;
        }

        public bool HandleCond(ITriggerCond cond)
        {
            if (!this.AllCondHandlers.TryGetValue(cond.GetType(), out var handler))
            {
                LogHelper.Error($"there is no cond handler for {cond.GetType().FullName}");
                return false;
            }

            try
            {
                return handler.Handle(cond);
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
                return false;
            }
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

            try
            {
                handler.Run(action);
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
            }
        }
    }
}