using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Define;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class AIMgrs
    {
        public static readonly AIMgrs Instance = new AIMgrs();
        
        public async Task<SpellData> HandleGCD(ClassJobType classJobType,SpellData lastGCD)
        {
            try
            {
                switch (classJobType)
                {
                    case ClassJobType.Bard:
                        return await BardAIHandlers.HandleGCD(lastGCD);
                    case ClassJobType.Reaper:
                        return await ReaperAIHandlers.HandleGCD(lastGCD);
                }
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
            }

            return null;
        }
        
        public async Task<SpellData> HandleAbility(ClassJobType classJobType,SpellData lastAbility)
        {
            try
            {
                switch (classJobType)
                {
                    case ClassJobType.Bard:
                        return await BardAIHandlers.HandleAbility(lastAbility);
                    case ClassJobType.Reaper:
                        return await ReaperAIHandlers.HandleAbility(lastAbility);
                }
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
            }

            return null;
        }
    }
}