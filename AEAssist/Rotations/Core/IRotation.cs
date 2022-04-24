using System.Threading.Tasks;
using AEAssist.Define;

namespace AEAssist
{
    public interface IRotation
    {
        /// <summary>
        /// init after job switch
        /// </summary>
        void Init(); 
        Task<bool> PreCombatBuff();
        SpellEntity GetBaseGCDSpell();
    }
}