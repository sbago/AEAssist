using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SamuraiGCD_Iaijutsu : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (Core.Me.HasAura(AurasDefine.Kaiten))
            {
                var ta = Core.Me.CurrentTarget as Character;
                if (Core.Me.HasAura(AurasDefine.OgiReady) && (SpellsDefine.KaeshiSetsugekka.Cooldown.TotalMilliseconds != 0) && ta.HasMyAura(AurasDefine.Higanbana))
                    return -1;
                return 10;
            }
            var target = Core.Me.CurrentTarget as Character;
            if(target.HasAura(AurasDefine.Higanbana))
                return -2;
            return -1;
        }

        public async Task<SpellData> Run()
        {
            var spell = SamuraiSpellHelper.GetIaijutsuSpell();
            if (spell == null) return null;
            if (await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget))
            {
                if (spell == SpellsDefine.MidareSetsugekka && (SpellsDefine.KaeshiSetsugekka.Cooldown.TotalMilliseconds < 62100))
                    AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell = KaeshiSpell.MidareSetsugekka;
                return spell;
            }
            return null;
        }
    }
}

