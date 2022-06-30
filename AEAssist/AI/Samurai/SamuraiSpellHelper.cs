using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Samurai
{
    public class SamuraiSpellHelper
    {
        public static SpellEntity GetBaseSpell()
        {
            if (!Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {
                if (ActionManager.LastSpell == SpellsDefine.Hakaze.GetSpellEntity().SpellData)
                {
                    if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                        return SpellsDefine.Yukikaze.GetSpellEntity();
                    if (Core.Me.GetAuraById(AurasDefine.Shifu)?.TimeLeft <
                        Core.Me.GetAuraById(AurasDefine.Jinpu)?.TimeLeft ||
                        !Core.Me.HasAura(AurasDefine.Shifu))
                        return SpellsDefine.Shifu.GetSpellEntity();
                    return SpellsDefine.Jinpu.GetSpellEntity();
                }

                if (ActionManager.LastSpell == SpellsDefine.Shifu.GetSpellEntity().SpellData)
                    return SpellsDefine.Kasha.GetSpellEntity();
                if (ActionManager.LastSpell == SpellsDefine.Jinpu.GetSpellEntity().SpellData)
                    return SpellsDefine.Gekko.GetSpellEntity();
                return SpellsDefine.Hakaze.GetSpellEntity();
            }

            if (Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                    return SpellsDefine.Kasha.GetSpellEntity();
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                    return SpellsDefine.Gekko.GetSpellEntity();
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                    return SpellsDefine.Yukikaze.GetSpellEntity();
            }

            return null;
        }

        public static async Task<SpellEntity> CoolDownPhaseGCD()
        {
            // https://www.thebalanceffxiv.com/jobs/melee/samurai/basic-guide/
            // Hakaze -> Yukikaze -> Hakaze -> Jinpu -> Gekko -> Hakaze -> Shifu -> Kasha -> Midare Setsugekka -> repeat
            // refer to the balance level 90 samurai
            if (SpellsDefine.Hakaze.IsUnlock())
            {
                if (SpellsDefine.Hakaze.IsReady())
                {
                    await SpellsDefine.Hakaze.DoGCD();
                    return SpellsDefine.Hakaze.GetSpellEntity();
                }
            }
            
            if (SpellsDefine.Yukikaze.IsUnlock())
            {
                if (SpellsDefine.Yukikaze.IsReady())
                {
                    await SpellsDefine.Yukikaze.DoGCD();
                    return SpellsDefine.Yukikaze.GetSpellEntity();
                }
            }
            
            if (SpellsDefine.Hakaze.IsUnlock())
            {
                if (SpellsDefine.Hakaze.IsReady())
                {
                    await SpellsDefine.Hakaze.DoGCD();
                    return SpellsDefine.Hakaze.GetSpellEntity();
                }
            }

            if (SpellsDefine.Jinpu.IsUnlock())
            {
                if (SpellsDefine.Jinpu.IsReady())
                {
                    await SpellsDefine.Jinpu.DoGCD();
                    return SpellsDefine.Jinpu.GetSpellEntity();
                }
            }

            if (SpellsDefine.Gekko.IsUnlock())
            {
                if (SpellsDefine.Gekko.IsReady())
                {
                    await SpellsDefine.Gekko.DoGCD();
                    return SpellsDefine.Gekko.GetSpellEntity();
                }
            }

            if (SpellsDefine.Hakaze.IsUnlock())
            {
                if (SpellsDefine.Hakaze.IsReady())
                {
                    await SpellsDefine.Hakaze.DoGCD();
                    return SpellsDefine.Hakaze.GetSpellEntity();
                }
            }
            
            if (SpellsDefine.Shifu.IsUnlock())
            {
                if (SpellsDefine.Shifu.IsReady())
                {
                    await SpellsDefine.Shifu.DoGCD();
                    return SpellsDefine.Shifu.GetSpellEntity();
                }
            }
            
            if (SpellsDefine.Kasha.IsUnlock())
            {
                if (SpellsDefine.Kasha.IsReady())
                {
                    await SpellsDefine.Kasha.DoGCD();
                    return SpellsDefine.Kasha.GetSpellEntity();
                }
            }
            
            if (SpellsDefine.HissatsuShinten.IsUnlock())
            {
                if (SpellsDefine.HissatsuShinten.IsReady())
                {
                    await SpellsDefine.HissatsuShinten.DoAbility();
                    return SpellsDefine.HissatsuShinten.GetSpellEntity();
                }
            }
            
            if (SpellsDefine.MidareSetsugekka.IsUnlock())
            {
                if (SpellsDefine.MidareSetsugekka.IsReady())
                {
                    await SpellsDefine.MidareSetsugekka.DoGCD();
                    return SpellsDefine.MidareSetsugekka.GetSpellEntity();
                }
            }

            return null;
        }

        public static async Task<SpellEntity> OddMinutesBurst()
        {
            // https://www.thebalanceffxiv.com/jobs/melee/samurai/basic-guide/
            // get battle time first
            
            var checkOddOrEven = CheckOddOrEvenBattleTime();
            if (checkOddOrEven != 1) return null;
            
            // do odd minute bursts
                
            if (SpellsDefine.HissatsuShinten.IsUnlock())
            {
                if (SpellsDefine.HissatsuShinten.IsReady())
                {
                    await SpellsDefine.HissatsuShinten.DoAbility();
                    return SpellsDefine.HissatsuShinten.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.MidareSetsugekka.IsUnlock())
            {
                if (SpellsDefine.MidareSetsugekka.IsReady())
                {
                    await SpellsDefine.MidareSetsugekka.DoGCD();
                    return SpellsDefine.MidareSetsugekka.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.KaeshiSetsugekka.IsUnlock())
            {
                if (SpellsDefine.KaeshiSetsugekka.IsReady())
                {
                    await SpellsDefine.KaeshiSetsugekka.DoAbility();
                    return SpellsDefine.KaeshiSetsugekka.GetSpellEntity();
                }
            }

            if (SpellsDefine.MeikyoShisui.IsUnlock())
            {
                if (SpellsDefine.MeikyoShisui.IsReady())
                {
                    await SpellsDefine.MeikyoShisui.DoAbility();
                    return SpellsDefine.MeikyoShisui.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Gekko.IsUnlock())
            {
                if (SpellsDefine.Gekko.IsReady())
                {
                    await SpellsDefine.Gekko.DoGCD();
                    return SpellsDefine.Gekko.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.HissatsuShinten.IsUnlock())
            {
                if (SpellsDefine.HissatsuShinten.IsReady())
                {
                    await SpellsDefine.HissatsuShinten.DoAbility();
                    return SpellsDefine.HissatsuShinten.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Higanbana.IsUnlock())
            {
                if (SpellsDefine.Higanbana.IsReady())
                {
                    await SpellsDefine.Higanbana.DoGCD();
                    return SpellsDefine.Higanbana.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Gekko.IsUnlock())
            {
                if (SpellsDefine.Gekko.IsReady())
                {
                    await SpellsDefine.Gekko.DoGCD();
                    return SpellsDefine.Gekko.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Kasha.IsUnlock())
            {
                if (SpellsDefine.Kasha.IsReady())
                {
                    await SpellsDefine.Kasha.DoGCD();
                    return SpellsDefine.Kasha.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Hakaze.IsUnlock())
            {
                if (SpellsDefine.Hakaze.IsReady())
                {
                    await SpellsDefine.Hakaze.DoGCD();
                    return SpellsDefine.Hakaze.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Yukikaze.IsUnlock())
            {
                if (SpellsDefine.Yukikaze.IsReady())
                {
                    await SpellsDefine.Yukikaze.DoGCD();
                    return SpellsDefine.Yukikaze.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.HissatsuShinten.IsUnlock())
            {
                if (SpellsDefine.HissatsuShinten.IsReady())
                {
                    await SpellsDefine.HissatsuShinten.DoAbility();
                    return SpellsDefine.HissatsuShinten.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.MidareSetsugekka.IsUnlock())
            {
                if (SpellsDefine.MidareSetsugekka.IsReady())
                {
                    await SpellsDefine.MidareSetsugekka.DoGCD();
                    return SpellsDefine.MidareSetsugekka.GetSpellEntity();
                }
            }

            return null;
        }
        
        public static async Task<SpellEntity> EvenMinutesBurst()
        {
            // https://www.thebalanceffxiv.com/jobs/melee/samurai/basic-guide/
            // get battle time first
            var checkOddOrEven = CheckOddOrEvenBattleTime();
            if (checkOddOrEven != 0) return null;
            // do Even minute bursts
                
            if (SpellsDefine.HissatsuShinten.IsUnlock())
            {
                if (SpellsDefine.HissatsuShinten.IsReady())
                {
                    await SpellsDefine.HissatsuShinten.DoAbility();
                    return SpellsDefine.HissatsuShinten.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.MidareSetsugekka.IsUnlock())
            {
                if (SpellsDefine.MidareSetsugekka.IsReady())
                {
                    await SpellsDefine.MidareSetsugekka.DoGCD();
                    return SpellsDefine.MidareSetsugekka.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.KaeshiSetsugekka.IsUnlock())
            {
                if (SpellsDefine.KaeshiSetsugekka.IsReady())
                {
                    await SpellsDefine.KaeshiSetsugekka.DoAbility();
                    return SpellsDefine.KaeshiSetsugekka.GetSpellEntity();
                }
            }

            if (SpellsDefine.HissatsuSenei.IsUnlock())
            {
                if (SpellsDefine.HissatsuSenei.IsReady())
                {
                    await SpellsDefine.HissatsuSenei.DoAbility();
                    return SpellsDefine.HissatsuSenei.GetSpellEntity();
                }
            }

            if (SpellsDefine.MeikyoShisui.IsUnlock())
            {
                if (SpellsDefine.MeikyoShisui.IsReady())
                {
                    await SpellsDefine.MeikyoShisui.DoAbility();
                    return SpellsDefine.MeikyoShisui.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Gekko.IsUnlock())
            {
                if (SpellsDefine.Gekko.IsReady())
                {
                    await SpellsDefine.Gekko.DoGCD();
                    return SpellsDefine.Gekko.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.HissatsuShinten.IsUnlock())
            {
                if (SpellsDefine.HissatsuShinten.IsReady())
                {
                    await SpellsDefine.HissatsuShinten.DoAbility();
                    return SpellsDefine.HissatsuShinten.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Higanbana.IsUnlock())
            {
                if (SpellsDefine.Higanbana.IsReady())
                {
                    await SpellsDefine.Higanbana.DoGCD();
                    return SpellsDefine.Higanbana.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Gekko.IsUnlock())
            {
                if (SpellsDefine.Gekko.IsReady())
                {
                    await SpellsDefine.Gekko.DoGCD();
                    return SpellsDefine.Gekko.GetSpellEntity();
                }
            }
            
            if (SpellsDefine.HissatsuShinten.IsUnlock())
            {
                if (SpellsDefine.HissatsuShinten.IsReady())
                {
                    await SpellsDefine.HissatsuShinten.DoAbility();
                    return SpellsDefine.HissatsuShinten.GetSpellEntity();
                }
            }
            
            if (SpellsDefine.OgiNamikiri.IsUnlock())
            {
                if (SpellsDefine.OgiNamikiri.IsReady())
                {
                    await SpellsDefine.OgiNamikiri.DoGCD();
                    return SpellsDefine.OgiNamikiri.GetSpellEntity();
                }
            }
            
            if (SpellsDefine.KaeshiNamikiri.IsUnlock())
            {
                if (SpellsDefine.KaeshiNamikiri.IsReady())
                {
                    await SpellsDefine.KaeshiNamikiri.DoAbility();
                    return SpellsDefine.KaeshiNamikiri.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Kasha.IsUnlock())
            {
                if (SpellsDefine.Kasha.IsReady())
                {
                    await SpellsDefine.Kasha.DoGCD();
                    return SpellsDefine.Kasha.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Hakaze.IsUnlock())
            {
                if (SpellsDefine.Hakaze.IsReady())
                {
                    await SpellsDefine.Hakaze.DoGCD();
                    return SpellsDefine.Hakaze.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.Yukikaze.IsUnlock())
            {
                if (SpellsDefine.Yukikaze.IsReady())
                {
                    await SpellsDefine.Yukikaze.DoGCD();
                    return SpellsDefine.Yukikaze.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.HissatsuShinten.IsUnlock())
            {
                if (SpellsDefine.HissatsuShinten.IsReady())
                {
                    await SpellsDefine.HissatsuShinten.DoAbility();
                    return SpellsDefine.HissatsuShinten.GetSpellEntity();
                }
            }
                
            if (SpellsDefine.MidareSetsugekka.IsUnlock())
            {
                if (SpellsDefine.MidareSetsugekka.IsReady())
                {
                    await SpellsDefine.MidareSetsugekka.DoGCD();
                    return SpellsDefine.MidareSetsugekka.GetSpellEntity();
                }
            }

            return null;
        }


        public static int CheckOddOrEvenBattleTime()
        {
            var currentBattleTime = AIRoot.GetBattleData<BattleData>().CurrBattleTimeInMs;
            var battleTimeInMinutes = currentBattleTime / 60000;
            var reminderInMinutes = battleTimeInMinutes % 2;
            
            // ODD
            if (reminderInMinutes == 1)
            {
                return 1;
            }
            
            // EVEN 
            if (reminderInMinutes == 0)
            {
                return 0;
            }

            return -1;
        }
        
        public static async Task<SpellEntity> AoEGCD()
        {

            if (TargetHelper.CheckNeedUseAOE(8, 5))
            {
                if (SpellsDefine.Fuga.IsUnlock())
                {
                    if (SpellsDefine.Fuga.IsReady())
                    {
                        await SpellsDefine.Fuga.DoGCD();
                        return SpellsDefine.Fuga.GetSpellEntity();
                    }
                }
            }
            
            if (TargetHelper.CheckNeedUseAOE(0, 5))
            {
                if (SpellsDefine.Oka.IsUnlock())
                {
                    if (SpellsDefine.Oka.IsReady())
                    {
                        await SpellsDefine.Oka.DoGCD();
                        return SpellsDefine.Oka.GetSpellEntity();
                    }
                }
            }
            
            if (TargetHelper.CheckNeedUseAOE(8, 5))
            {
                if (SpellsDefine.Fuga.IsUnlock())
                {
                    if (SpellsDefine.Fuga.IsReady())
                    {
                        await SpellsDefine.Fuga.DoGCD();
                        return SpellsDefine.Fuga.GetSpellEntity();
                    }
                }
            }
            
            if (TargetHelper.CheckNeedUseAOE(0, 5))
            {
                if (SpellsDefine.Mangetsu.IsUnlock())
                {
                    if (SpellsDefine.Mangetsu.IsReady())
                    {
                        await SpellsDefine.Mangetsu.DoGCD();
                        return SpellsDefine.Mangetsu.GetSpellEntity();
                    }
                }
            }
            
            if (SpellsDefine.HissatsuShinten.IsUnlock())
            {
                if (SpellsDefine.HissatsuShinten.IsReady())
                {
                    await SpellsDefine.HissatsuShinten.DoAbility();
                    return SpellsDefine.HissatsuShinten.GetSpellEntity();
                }
            }
            
            if (TargetHelper.CheckNeedUseAOE(0, 5))
            {
                if (SpellsDefine.TenkaGoken.IsUnlock())
                {
                    if (SpellsDefine.TenkaGoken.IsReady())
                    {
                        await SpellsDefine.TenkaGoken.DoGCD();
                        return SpellsDefine.TenkaGoken.GetSpellEntity();
                    }
                }
            }
            
            return null;
        }

        public static SpellEntity IaijutsuCanSpell()
        {
            if (!Core.Me.HasAura(AurasDefine.Kaiten))
                return null;
            if (!Core.Me.HasAura(AurasDefine.Kaiten))
                return null;
            return null;
        }

        public static uint SenCounts()
        {
            uint counts = 0;
            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                counts++;

            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                counts++;

            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                counts++;
            return counts;
        }

        public static bool IaijutsuCanSpellTime()
        {
            var target = Core.Me as GameObject;
            if (Core.Me.HasAura(AurasDefine.MeikyoShisui))
                return false;
            return true;
        }

        public static SpellEntity GetIaijutsuSpell()
        {
            var spell = SpellsDefine.MidareSetsugekka;
            var Sen = SenCounts();
            var ta = Core.Me.CurrentTarget as Character;
            // if (spell.Cooldown.TotalSeconds != 0 && Core.Me.HasAura(AurasDefine.OgiReady) && ta.HasMyAura(AurasDefine.Higanbana))
            //     return SpellsDefine.OgiNamikiri;
            if (Sen == 0) return null;
            if (Sen == 1) spell = SpellsDefine.Higanbana;
            if (Sen == 2)
            {
                if (TargetHelper.CheckNeedUseAOE(Core.Me.CurrentTarget, 5, 5))
                    return SpellsDefine.TenkaGoken.GetSpellEntity();
                return null;
            }

            return spell.GetSpellEntity();
        }

        public static SpellEntity KaeshiCanSpell()
        {
            if (AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell == KaeshiSpell.MidareSetsugekka)
                return SpellsDefine.KaeshiSetsugekka.GetSpellEntity();
            if (AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell == KaeshiSpell.OgiNamikiri)
                return SpellsDefine.KaeshiNamikiri.GetSpellEntity();
            return null;
        }

        public static bool NeedUseKaiten()
        {
            if (false) ;
            return false;
        }
    }
}