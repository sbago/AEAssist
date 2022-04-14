using System.Threading.Tasks;
using ff14bot.Objects;

namespace AEAssist
{
    public interface IRotation
    {
        /// <summary>
        /// init after job switch
        /// </summary>
        void Init(); 
        Task<bool> PreCombatBuff();
        SpellData GetBaseGCDSpell();
    }
}