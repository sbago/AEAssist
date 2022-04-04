using System.Threading.Tasks;
using AEAssist.DataBinding;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper.Ability
{
    public class ReaperAbility_Enshroud : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!SpellsDefine.Enshroud.IsReady())
                return false;
            if (lastSpell == SpellsDefine.Gluttony)
                return false;
            return ReaperSpellHelper.ReadyToEnshroud();
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastAbility(SpellsDefine.Enshroud, Core.Me))
            {
                AIRoot.Instance.ReaperBattleData.EnshroundTime = TimeHelper.Now();
                return SpellsDefine.Enshroud;
            }

            return null;
        }
    }
}