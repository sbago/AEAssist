using System.Threading.Tasks;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public interface IAIHandler
    {
        bool Check(LocalPlayer self);

        void Run(LocalPlayer self);
    }
}