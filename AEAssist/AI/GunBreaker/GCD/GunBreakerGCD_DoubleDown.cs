﻿using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot;
using AEAssist.Helper;

namespace AEAssist.AI.GunBreaker.GCD
{
    public class GunBreakerGCD_DoubleDown : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!DataBinding.Instance.Burst)
                return -100;

            if (!SpellsDefine.DoubleDown.IsReady())
                return -1;

            if(SpellsDefine.NoMercy.CoolDownInGCDs(4))
                return -2;
            //if(TargetHelper.)

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.DoubleDown.GetSpellEntity();
            if (await spell.DoGCD())
                return spell;
            return null;
        }
    }
}