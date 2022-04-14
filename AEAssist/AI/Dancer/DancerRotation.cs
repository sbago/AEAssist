using System.Threading.Tasks;
using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.AI
{
    [Rotation(ClassJobType.Dancer)]
    public class DancerRotation : IRotation
    {
        public void Init()
        {
            throw new System.NotImplementedException();
        }
        
        public Task<bool> PreCombatBuff()
        {
            throw new System.NotImplementedException();
        }
        
        public SpellData GetBaseGCDSpell()
        {
            throw new System.NotImplementedException();
        }
    }
}