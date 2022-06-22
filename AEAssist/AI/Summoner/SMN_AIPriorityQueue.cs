using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.Helper;
using ff14bot.Enums;
using AEAssist.AI.Summoner.GCD;
using AEAssist.AI.Summoner.Ability;
namespace AEAssist.AI.Summoner
{
    [Job(ClassJobType.Summoner)]
    public class SMN_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new SMNGCD_SummonCarbuncle(),
            new SMNGCD_Aethercharge(),
            new SMNGCD_RuinIV(),

            new SMNGCD_Base()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            //new SMNAbility_SearingLight(),
            new SMNAbility_EnergyDrain(),
            new SMNAbility_Fester(),
            new SMNAbility_Deathflare(),
            new SMNAbility_EnkindleBahamut(),
            
        };
        public Task<bool> UsePotion()
        {
            return Task.FromResult(false);
        }
    }
}