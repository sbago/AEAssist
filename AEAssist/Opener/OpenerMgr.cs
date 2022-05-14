﻿// -----------------------------------
// 
// 模块说明：OpenerMgr.cs
// 
// 创建人员：AE
// 创建日期：2022-04-14
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Enums;

namespace AEAssist.Opener
{

    public class OpenerData
    {
        public string Name { get; set; }
    }


    public class OpenerMgr
    {
        public static OpenerMgr Instance = new OpenerMgr();

        public Dictionary<(ClassJobType, int, string), IOpener> AllOpeners = new Dictionary<(ClassJobType, int, string), IOpener>();

        public Dictionary<ClassJobType, List<OpenerData>> Name2Openers = new Dictionary<ClassJobType, List<OpenerData>>();

        public Dictionary<(Type, int), MethodInfo> AllSteps = new Dictionary<(Type, int), MethodInfo>();


        public const string DefaultName = "Default";


        public Dictionary<ClassJobType,string> SpecifyOpenerByName=  new Dictionary<ClassJobType, string>();


        public OpenerMgr()
        {
            AllOpeners.Clear();
            var baseType = typeof(IOpener);
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;
                if (!baseType.IsAssignableFrom(type))
                    continue;
                var attrs = type.GetCustomAttributes(typeof(OpenerAttribute), false);
                if (attrs.Length == 0)
                {
                    LogHelper.Error($"Opener class [{type}] need OpenerAttribute");
                    continue;
                }

                var attr = attrs[0] as OpenerAttribute;
                var opener = Activator.CreateInstance(type) as IOpener;
                var openerKey = (attr.ClassJobType, attr.Level,attr.Name);
                if (AllOpeners.ContainsKey(openerKey))
                    LogHelper.Error("Multi opener " + type.Name);
                AllOpeners[openerKey] = opener;

                var openerMethods =
                    type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                var stepsSet = new HashSet<int>();
                foreach (var method in openerMethods)
                {
                    var stepAttr = method.GetCustomAttribute<OpenerStepAttribute>();
                    if (stepAttr == null)
                        continue;
                    var key = (type, stepAttr.StepIndex);
                    if (!stepsSet.Add(stepAttr.StepIndex) || stepAttr.StepIndex < 0 ||
                        stepAttr.StepIndex >= opener.StepCount)
                    {
                        LogHelper.Error($"StepIndexError: {type.Name} Index: {stepAttr.StepIndex}");
                        continue;
                    }

                    if (method.ReturnType != typeof(SpellQueueSlot))
                        LogHelper.Error($"StepReturnTypeError: {type.Name} Method:{method.Name} ");

                    var param = method.GetParameters();

                    if (param != null && param.Length > 0)
                        LogHelper.Error($"StepMethodParamsError: {type.Name} Method:{method.Name} ");

                    AllSteps.Add(key, method);
                }

                if (stepsSet.Count != opener.StepCount)
                    LogHelper.Error($"StepCountError: {type.Name}  Cal:{stepsSet.Count} Define:{opener.StepCount} ");


                LogHelper.Info($"Load Opener: {attr.ClassJobType} Level: {attr.Level}");
            }
        }

        public async Task<bool> UseOpener(ClassJobType classJobType)
        {
            var battleData = AIRoot.GetBattleData<BattleData>();

            if (!SpecifyOpenerByName.TryGetValue(classJobType, out var name))
            {
                name = DefaultName;
            }

            if (!AllOpeners.TryGetValue((classJobType, Core.Me.ClassLevel, name), out var opener))
                return false;

            if (battleData.OpenerIndex == 0)
            {
                var ret = opener.Check();
                if (ret < 0)
                {
                    LogHelper.Debug($"Opener Check: {opener.GetType().Name} ret: {ret}");
                    return false;
                }
                LogHelper.Debug($"Use Opener: {opener.GetType().Name}");
            }


            if (opener.StepCount < battleData.OpenerIndex) return false;

            var spellQueue = AIRoot.GetBattleData<SpellQueueData>();

            if (!await spellQueue.ApplySlot())
            {
                if (opener.StepCount <= battleData.OpenerIndex)
                {
                    battleData.OpenerIndex++;
                    return false;
                }
                if (AllSteps.TryGetValue((opener.GetType(), battleData.OpenerIndex), out var method))
                {
                    var slot = (SpellQueueSlot) method.Invoke(opener, null);
                    if (slot != null)
                    {
                        LogHelper.Debug($"opener running: Index {battleData.OpenerIndex} GCDSpellId: {slot.GCDSpellId}");
                        spellQueue.Add(slot);
                    }
                    else
                        LogHelper.Error(method.Name + " Cant Get SpellQueueSlot");
                }
                
                battleData.OpenerIndex++;
            }


            return true;
        }
    }
}