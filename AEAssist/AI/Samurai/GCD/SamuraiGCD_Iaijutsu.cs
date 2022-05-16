using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_Iaijutsu : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (Core.Me.HasAura(AurasDefine.Kaiten))
                if(SamuraiSpellHelper.SenCounts() == 3 || SamuraiSpellHelper.SenCounts() == 1)
                    return 10;
            return -2;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SamuraiSpellHelper.GetIaijutsuSpell();
            if (spell == null) return null;
            if (await spell.DoGCD())
            {
                if (spell.Id == SpellsDefine.MidareSetsugekka &&
                    SpellsDefine.KaeshiSetsugekka.GetSpellEntity().Cooldown.TotalMilliseconds < 64000)
                    AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell = KaeshiSpell.MidareSetsugekka;
                return spell;
            }

            return null;
        }
    }
}