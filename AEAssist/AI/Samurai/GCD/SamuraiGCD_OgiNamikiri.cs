using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_OgiNamikiri : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (Core.Me.HasAura(AurasDefine.Kaiten))
            {
                var ta = Core.Me.CurrentTarget as Character;
                if (Core.Me.HasAura(AurasDefine.OgiReady) && ta.HasAura(AurasDefine.Higanbana))
                {
                    if (SamuraiSpellHelper.SenCounts() == 0 && ta.GetAuraById(AurasDefine.Higanbana).TimespanLeft.TotalMilliseconds < 11000)
                        return -3;
                    if (ta.GetAuraById(AurasDefine.Higanbana).TimespanLeft.TotalMilliseconds < 4000)
                        return -4;
                    if (DataManager.GetSpellData(SpellsDefine.KaeshiSetsugekka).Cooldown.TotalMilliseconds < 70000)
                        return -2;
                    return 1;
                }
            }

            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            if (await SpellsDefine.OgiNamikiri.DoGCD())
            {
                AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell = KaeshiSpell.OgiNamikiri;
                return SpellsDefine.OgiNamikiri.GetSpellEntity();
            }

            return null;
        }
    }
}