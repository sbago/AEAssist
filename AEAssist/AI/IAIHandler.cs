using System.Threading.Tasks;
using AEAssist.Define;

namespace AEAssist.AI
{
    public interface IAIHandler
    {
        int Check(SpellEntity lastSpell);

        Task<SpellEntity> Run();
    }
}