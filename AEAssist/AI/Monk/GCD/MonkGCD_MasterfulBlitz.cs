using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Objects;

namespace AEAssist.AI.Monk.GCD
{
    public class MonkGCD_MasterfulBlitz : IAIHandler
    {
        //Elixir Field 苍气炮 Action Id:3545 阴必杀
        //Flint Strike 爆裂脚 Action Id:25882 阳必杀
        //Celestial Revolution 翻天脚 Action Id:25765 兔必杀
        //Tornado Kick 斗魂旋风脚 Action Id:3543 真必杀
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var target = Core.Me.CurrentTarget as Character;
            return await MonkSpellHelper.BaseGCDCombo(target);
        }
    }
}