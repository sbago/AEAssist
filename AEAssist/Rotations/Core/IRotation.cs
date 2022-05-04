using System.Threading.Tasks;
using AEAssist.Define;

namespace AEAssist.Rotations.Core
{
    public interface IRotation
    {
        /// <summary>
        ///     init after job switch
        /// </summary>
        void Init();

        Task<bool> PreCombatBuff();
        SpellEntity GetBaseGCDSpell();
    }
}