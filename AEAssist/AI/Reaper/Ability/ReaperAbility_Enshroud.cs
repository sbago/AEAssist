using System.Threading.Tasks;
using AEAssist;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.Ability
{
    public class ReaperAbility_Enshroud : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Enshroud.IsReady())
                return -1;
            if (lastSpell == SpellsDefine.Gluttony)
                return -2;
            return ReaperSpellHelper.ReadyToEnshroud();
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.Enshroud, Core.Me))
            {
                return SpellsDefine.Enshroud;
            }

            return null;
        }
    }
}