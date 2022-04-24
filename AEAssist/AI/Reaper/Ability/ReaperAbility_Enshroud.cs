using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper
{
    public class ReaperAbility_Enshroud : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Enshroud.IsReady())
                return -1;
            return ReaperSpellHelper.ReadyToEnshroud();
        }

        public async Task<SpellEntity> Run()
        {
            if (await SpellsDefine.Enshroud.DoAbility()) return SpellsDefine.Enshroud;

            return null;
        }
    }
}