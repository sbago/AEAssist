using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class AIMgrs
    {
        public static readonly AIMgrs Instance = new AIMgrs();

        public List<IAIHandler> BardAI_GCDs = new List<IAIHandler>()
        {
            new BardGCD_Barrage_RefulgentArrow(),
            new BardGCD_QuickNock(),
            new BardGCD_Dot(),
            new BardGCD_BlastArrow(),
            new BardGCD_ApexArrow(),
            new BardGCD_HeavyShot()
        };

        public List<IAIHandler> BardAI_Abilitys = new List<IAIHandler>()
        {
            new BardAbility_UsePotion(),
            new BardAbility_PitchPerfect(),
            new BardAbility_Songs(),
            new BardAbility_RagingStrikes(),
            new BardAbility_EmpyrealArrow(),
            new BardAbility_MaxChargeBloodletter(),
            new BardAbility_Buffs(),
            new BardAbility_Barrage(),
            new BardAbility_Sidewinder(),
            new BardAbility_Bloodletter()
        };

        public async Task<SpellData> HandleGCD(ClassJobType classJobType,SpellData lastGCD)
        {
            switch (classJobType)
            {
                case ClassJobType.Bard:
                    foreach (var v in BardAI_GCDs)
                    {
                        if (v.Check(lastGCD))
                        {
                            return await v.Run();
                        }
                    }
                    break;
            }

            return null;
        }
        
        public async Task<SpellData> HandleAbility(ClassJobType classJobType,SpellData lastAbility)
        {
            switch (classJobType)
            {
                case ClassJobType.Bard:
                    foreach (var v in BardAI_Abilitys)
                    {
                        if (v.Check(lastAbility))
                        {
                            return await v.Run();
                        }
                    }
                    break;
            }

            return null;
        }
    }
}