using System.Threading.Tasks;

namespace AEAssist.Job
{
    public interface IRotation
    {
        Task<bool> Rest();
        Task<bool> PreCombatBuff();
        Task<bool> Pull();
        Task<bool> Heal();
        Task<bool> CombatBuff();
        Task<bool> Combat();
        Task<bool> PullBuff();
    }
}