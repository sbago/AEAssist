using System.Threading.Tasks;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public interface IAIHandler
    {
        int Check(SpellData lastSpell);

        Task<SpellData> Run();
    }
}