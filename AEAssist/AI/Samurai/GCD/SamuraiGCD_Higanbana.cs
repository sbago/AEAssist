using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;
using AEAssist.AI.Samurai.SpellQueue;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_Higanbana : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var ta = Core.Me.CurrentTarget as Character;
            if( SamuraiSpellHelper.SenCounts() == 1)
                if(ta.HasMyAuraWithTimeleft(AurasDefine.Higanbana,3000))
                    return 10;
            return -2;
        }

        public async Task<SpellEntity> Run()
        {
            if (!Core.Me.HasAura(AurasDefine.Kaiten))
                await SpellsDefine.HissatsuKaiten.DoAbility();
            //AISpellQueueMgr.Instance.Apply<SpellQueue_Iaijutsu>();
            //await Task.CompletedTask;
            if (await SpellsDefine.Higanbana.DoGCD())
                return SpellsDefine.Higanbana.GetSpellEntity();
            return null;
        }
    }
}