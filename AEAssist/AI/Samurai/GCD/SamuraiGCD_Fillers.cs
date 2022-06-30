using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_Fillers : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            const int minimumGcdOneMin = 26;
            var baseGcdTime = RotationManager.Instance.GetBaseGCDSpell().AdjustedCooldown.TotalMilliseconds;
            var battleTime = AIRoot.GetBattleData<BattleData>().CurrBattleTimeInMs;
            var totalGcdTimeMs = baseGcdTime * minimumGcdOneMin;

            if (battleTime % totalGcdTimeMs == 0)
            {
                return 0;
            }

            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var baseGcdTime = RotationManager.Instance.GetBaseGCDSpell().AdjustedCooldown.TotalMilliseconds;

            if (Math.Abs(baseGcdTime - 2140) == 0) // 2.14second gcd 2 filler gcd needed
            {
                if (await SpellsDefine.Hakaze.DoGCD())
                {
                    return SpellsDefine.Hakaze.GetSpellEntity();
                }

                if (await SpellsDefine.Yukikaze.DoGCD())
                {
                    return SpellsDefine.Yukikaze.GetSpellEntity();
                }

                if (await SpellsDefine.Hagakure.DoAbility())
                {
                    return SpellsDefine.Hagakure.GetSpellEntity();
                }
            } else if (Math.Abs(baseGcdTime - 2070) == 0) // 2.07sec gcd 3 filler gcd needed
            {
                if (await SpellsDefine.Hakaze.DoGCD())
                {
                    return SpellsDefine.Hakaze.GetSpellEntity();
                }
                
                if (await SpellsDefine.Jinpu.DoGCD())
                {
                    return SpellsDefine.Jinpu.GetSpellEntity();
                }
                
                if (await SpellsDefine.Gekko.DoGCD())
                {
                    return SpellsDefine.Gekko.GetSpellEntity();
                }
                
                if (await SpellsDefine.Hagakure.DoAbility())
                {
                    return SpellsDefine.Hagakure.GetSpellEntity();
                }
            }else if (Math.Abs(baseGcdTime - 2000) == 0) // 2.00 seconds gcd 4 filler gcd needed (get better gear lol)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (await SpellsDefine.Hakaze.DoGCD())
                    {
                        return SpellsDefine.Hakaze.GetSpellEntity();
                    }

                    if (await SpellsDefine.Yukikaze.DoGCD())
                    {
                        return SpellsDefine.Yukikaze.GetSpellEntity();
                    }
                
                    if (await SpellsDefine.Hagakure.DoAbility())
                    {
                        return SpellsDefine.Hagakure.GetSpellEntity();
                    }       
                }
            }

            return null;
        }
    }
}