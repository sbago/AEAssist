// -----------------------------------
// 
// 模块说明：OpenerMgr.cs
// 
// 创建人员：AE
// 创建日期：2022-04-14
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.Opener
{
    public class OpenerMgr
    {
        public static OpenerMgr Instance = new OpenerMgr();

        public Dictionary<(ClassJobType,int), IOpener> AllOpeners = new Dictionary<(ClassJobType,int), IOpener>();

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
                AllOpeners[(attr.ClassJobType,attr.Level)] = Activator.CreateInstance(type) as IOpener;
                LogHelper.Info($"Load Opener: {attr.ClassJobType} Level: {attr.Level}");
            }
        }
        //todo: 由AIRoot那边引用. 返回值true说明处于opner控制,spellData为空说明这时候没有行动.

        public bool UseOpenerGCD(ClassJobType classJobType,out SpellData spellData)
        {
            spellData = null;
            if (!AllOpeners.TryGetValue((classJobType,Core.Me.ClassLevel), out var opener))
                return false;
            var currGCDIndex = AIRoot.GetBattleData<BattleData>().lastGCDIndex;
            return opener.NextGCD(currGCDIndex,out spellData);
        }

        public bool UseOpenerAbility(ClassJobType classJobType,out SpellData spellData)
        {
            spellData = null;
            if (!AllOpeners.TryGetValue((classJobType,Core.Me.ClassLevel), out var opener))
                return false;
            var currGCDIndex = AIRoot.GetBattleData<BattleData>().lastGCDIndex;
            var abilityTimes = 2 - AIRoot.GetBattleData<BattleData>().maxAbilityTimes;
            if (abilityTimes < 0)
                abilityTimes = 0;
            if (abilityTimes > 1)
                abilityTimes = 1;
            return opener.NextAbility(currGCDIndex,abilityTimes,out spellData);
        }

    }
}