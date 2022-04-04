using System.Threading.Tasks;
using ff14bot.Objects;

namespace AEAssist
{
    public interface IRotation
    {
        void Init();
        Task<bool> Rest();
        Task<bool> PreCombatBuff();
        Task<bool> Pull();
        Task<bool> Heal();
        Task<bool> CombatBuff();
        Task<bool> Combat();
        Task<bool> PullBuff();

        SpellData GetBaseGCDSpell();

        void HandleInCountDown1500();
    }
}