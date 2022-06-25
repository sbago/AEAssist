using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using ff14bot;
using System;
using Buddy.Coroutines;

namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_SummonCarbuncle : IAIHandler
    {
        uint spell = SpellsDefine.SummonCarbuncle;
        public int Check(SpellEntity lastSpell)
        {
            
            if (SMN_SpellHelper.HasCarbuncle())
                return -4;
           
            if (!spell.IsReady())
                return -1;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            spell.GetSpellEntity().SpellTargetType = SpellTargetType.Self;

            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;

        }

        public async Task<SpellEntity> DelayedRun()
        {
            spell.GetSpellEntity().SpellTargetType = SpellTargetType.Self;
            int randomTimer = new Random().Next(2000, 4000);

            await Coroutine.Sleep(randomTimer);
            if (Check(null)>=0)
                if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;

        }
    }
}