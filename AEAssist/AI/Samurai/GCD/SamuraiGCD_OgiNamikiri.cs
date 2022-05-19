using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;
using ff14bot.Managers;
using AEAssist.AI.Samurai.SpellQueue;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_OgiNamikiri : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            //if (!DataBinding.Instance.Burst)
            //{
            //    var Me = Core.Me as Character;
            //    if(Me.GetAuraById(AurasDefine.OgiReady).TimespanLeft.TotalMilliseconds<6000)
            //        return 0;
            //    return -10;
            //}
            //var ta = Core.Me.CurrentTarget as Character;
            if (Core.Me.HasAura(AurasDefine.OgiReady))
            {
                return 1;
            }

            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            if (!Core.Me.HasAura(AurasDefine.Kaiten))
                await SpellsDefine.HissatsuKaiten.DoAbility();
            AISpellQueueMgr.Instance.Apply<SpellQueue_OgiNamikiriCombo>();
            await Task.CompletedTask;
            return null;
        }
    }
}