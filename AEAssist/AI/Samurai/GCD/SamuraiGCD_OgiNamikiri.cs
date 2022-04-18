using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SamuraiGCD_OgiNamikiri : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            if (Core.Me.HasAura(AurasDefine.Kaiten))
            {
                var ta = Core.Me.CurrentTarget as Character;
                if (Core.Me.HasAura(AurasDefine.OgiReady))
                    //if (SpellsDefine.KaeshiSetsugekka.Cooldown.TotalMilliseconds <= 65 && ta.HasMyAura(AurasDefine.Higanbana))
                        return 1;
            }
            return -1;
        }

        public async Task<SpellData> Run()
        {
            if (await SpellHelper.CastGCD(SpellsDefine.OgiNamikiri, Core.Me.CurrentTarget))
            {
                AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell = KaeshiSpell.OgiNamikiri;
                return SpellsDefine.OgiNamikiri;
            }
            return null;
        }
    }
}
