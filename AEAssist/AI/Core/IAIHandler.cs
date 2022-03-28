using System.Threading.Tasks;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public interface IAIHandler
    {
        bool Check(SpellData lastSpell);

        Task<SpellData> Run();
    }
}