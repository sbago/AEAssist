using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper
{
    public class ReaperGCD_BaseGCDCombo : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            // DoubleEnshroudPrefer 填充 这期间用不了普通GCD Combo所以只能填充这些
            if (SpellsDefine.Enshroud.RecentlyUsed() || Core.Me.ContainMyAura(AurasDefine.Enshrouded))
            {
                var spell = ReaperSpellHelper.GetShadowOfDeath();
                if (await spell.DoGCD())
                    return spell;
            }

            return await ReaperSpellHelper.BaseGCDCombo(Core.Me.CurrentTarget);
        }
    }
}