using System.Linq;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Monk
{
    public class MonkSpellHelper
    {
        public static bool InCoeurlForm()
        {
            if (Core.Me.HasMyAura(AurasDefine.CoeurlForm))
            {
                return true;
            }
            
            if (ActionManager.LastSpellId == SpellsDefine.TrueStrike ||
                ActionManager.LastSpellId == SpellsDefine.TwinSnakes ||
                ActionManager.LastSpellId == SpellsDefine.FourPointFury)
            {
                return true;
            }

            return false;
        }
        public static bool InOpoOpeForm()
        {
            if (Core.Me.HasMyAura(AurasDefine.OpoOpoForm))
            {
                return true;
            }
            
            if (ActionManager.LastSpellId == SpellsDefine.Demolish ||
                ActionManager.LastSpellId == SpellsDefine.SnapPunch ||
                ActionManager.LastSpellId == SpellsDefine.Rockbreaker)
            {
                return true;
            }

            return false;
        }
        public static bool InRaptorForm()
        {
            if (Core.Me.HasMyAura(AurasDefine.RaptorForm))
            {
                return true;
            }
            
            if (ActionManager.LastSpellId == SpellsDefine.Bootshine  ||
                ActionManager.LastSpellId == SpellsDefine.DragonKick ||
                ActionManager.LastSpellId == SpellsDefine.ArmOfTheDestroyer)
            {
                return true;
            }

            return false;
        }
        
        private static async Task<SpellEntity> UseAOECombo(Character target)
        {
            if (InCoeurlForm())
            {
                // if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 6000))
                // {
                //     //Snap Punch 崩拳
                //     if (await SpellsDefine.SnapPunch.DoGCD())
                //     {
                //         return SpellsDefine.SnapPunch.GetSpellEntity();
                //     }
                // }
                
                //Rockbreaker 地烈劲
                if (await SpellsDefine.Rockbreaker.DoGCD())
                {
                    return SpellsDefine.Rockbreaker.GetSpellEntity();
                }
            }

            if (InRaptorForm())
            {
                if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 4000))
                {
                    //Four-point Fury 四面脚
                    if (await SpellsDefine.FourPointFury.DoGCD())
                    {
                        return SpellsDefine.FourPointFury.GetSpellEntity();
                    }
                }
                //Twin Snakes 双掌打
                if (await SpellsDefine.TwinSnakes.DoGCD())
                {
                    return SpellsDefine.TwinSnakes.GetSpellEntity();
                }
            }
            //Shadow of the Destroyer 破坏神脚 Action Id:25767
            if (SpellsDefine.ShadowOfTheDestroyer.IsUnlock())
            {
                if (await SpellsDefine.ShadowOfTheDestroyer.DoGCD())
                {
                    return SpellsDefine.ShadowOfTheDestroyer.GetSpellEntity();
                }
            }
            if (Core.Me.HasMyAura(AurasDefine.LeadenFist))
            {
                //Bootshine 连击
                if (await SpellsDefine.Bootshine.DoGCD())
                {
                    return SpellsDefine.Bootshine.GetSpellEntity();
                }
            }
            //Arm of the Destroyer 破坏神冲
            if (await SpellsDefine.ArmOfTheDestroyer.DoGCD())
            {
                return SpellsDefine.ArmOfTheDestroyer.GetSpellEntity();
            }

            return null;
        }


        private static async Task<SpellEntity> UseSingleCombo(Character target)
        {
            if (InCoeurlForm())
            {
                if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 6000))
                {
                    //Snap Punch 崩拳
                    if (await SpellsDefine.SnapPunch.DoGCD())
                    {
                        return SpellsDefine.SnapPunch.GetSpellEntity();
                    }
                }
                //Demolish 破碎拳
                if (await SpellsDefine.Demolish.DoGCD())
                {
                    return SpellsDefine.Demolish.GetSpellEntity();
                }
            }

            if (InRaptorForm())
            {
                LogHelper.Info(Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 4000).ToString());
                if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 4000))
                {
                    //True Strike 正拳
                    if (await SpellsDefine.TrueStrike.DoGCD())
                    {
                        return SpellsDefine.TrueStrike.GetSpellEntity();
                    }
                }
                //Twin Snakes 双掌打
                if (await SpellsDefine.TwinSnakes.DoGCD())
                {
                    return SpellsDefine.TwinSnakes.GetSpellEntity();
                }
            }
            if (Core.Me.HasMyAura(AurasDefine.LeadenFist))
            {
                //Bootshine 连击
                if (await SpellsDefine.Bootshine.DoGCD())
                {
                    return SpellsDefine.Bootshine.GetSpellEntity();
                }
            }
            //Dragon Kick 双龙脚
            if (await SpellsDefine.DragonKick.DoGCD())
            {
                return SpellsDefine.DragonKick.GetSpellEntity();
            }

            return null;
        }

        public static async Task<SpellEntity> BaseGCDCombo(Character target)
        {
            if (TargetHelper.CheckNeedUseAOE(target, 5, 5, 3)) return await UseAOECombo(target);

            return await UseSingleCombo(target);
        }

        private static async Task<SpellEntity> UseLunarNadiCombo(Character target)
        {
            
            if (Core.Me.HasMyAura(AurasDefine.LeadenFist))
            {
                //Bootshine 连击
                if (await SpellsDefine.Bootshine.DoGCD())
                {
                    return SpellsDefine.Bootshine.GetSpellEntity();
                }
            }
            //Dragon Kick 双龙脚
            if (await SpellsDefine.DragonKick.DoGCD())
            {
                return SpellsDefine.DragonKick.GetSpellEntity();
            }
            
            return null;
        }
        
        private static async Task<SpellEntity> UseSolarNadiCombo(Character target)
        {
            
            return null;
        }

        public static async Task<SpellEntity> PerfectBalanceGCDCombo(Character target)
        {
            if (AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo == MonkNadiCombo.Solar)
            {
                return await UseSolarNadiCombo(target);
            }
            if (AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo == MonkNadiCombo.Lunar)
            {
                return await UseLunarNadiCombo(target);
            }

            if (HasBothNadi())
            {
                AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                return await UseLunarNadiCombo(target);
            }
            
            if (HasLunarNadi() && !HasSolarNadi())
            {
                AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Solar;
                return await UseSolarNadiCombo(target);
            }
            
            if (HasSolarNadi() && !HasLunarNadi())
            {
                AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                return await UseLunarNadiCombo(target);
            }

            if (!HasLunarNadi() && !HasSolarNadi() && AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo == MonkNadiCombo.None)
            {
                if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 7000) &&
                    target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 9000))
                {
                    AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                    return await UseLunarNadiCombo(target);
                }
                AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Solar;
                return await UseSolarNadiCombo(target);
            }

            return null;
        }

        public static bool HasLunarNadi()
        {
            //Lunar Nadi
            // ActionResourceManager.CostTypesStruct.offset_C == 2
            
            //offset_9: 2, offset_A: 3, offset_B: 1,
            //2 = combo 1, 3 = combo2, 1 = combo1
            //offset_9 = first
            //offset_A = second
            //offset_B = third
            
            //timer3: 3930 => time left for combo
            if (ActionResourceManager.CostTypesStruct.offset_C == 2 ||
                ActionResourceManager.CostTypesStruct.offset_C == 6)
            {
                return true;
            }

            return false;
        }
        public static bool HasSolarNadi()
        {
            // Solar Nadi
            // ActionResourceManager.CostTypesStruct.offset_C == 4
            if (ActionResourceManager.CostTypesStruct.offset_C == 4 ||
                ActionResourceManager.CostTypesStruct.offset_C == 6)
            {
                return true;
            }

            return false;
        }
        public static bool HasBothNadi()
        {
            //Lunar Nadi + Solar Nadi
            // ActionResourceManager.CostTypesStruct.offset_C == 6
            if (ActionResourceManager.CostTypesStruct.offset_C == 6)
            {
                return true;
            }

            return false;
        }

        public static bool LastSpellWasGCD()
        {
            var bdls = AIRoot.GetBattleData<BattleData>().lastGCDSpell;
            SpellEntity[] GCDs =
            {
                SpellsDefine.Bootshine.GetSpellEntity(),
                SpellsDefine.DragonKick.GetSpellEntity(),
                SpellsDefine.ArmOfTheDestroyer.GetSpellEntity(),
                SpellsDefine.ShadowOfTheDestroyer.GetSpellEntity(),
                SpellsDefine.TwinSnakes.GetSpellEntity(),
                SpellsDefine.TrueStrike.GetSpellEntity(),
                SpellsDefine.FourPointFury.GetSpellEntity(),
                SpellsDefine.Rockbreaker.GetSpellEntity(),
                SpellsDefine.Demolish.GetSpellEntity(),
                SpellsDefine.SnapPunch.GetSpellEntity(),
            };
            if (GCDs.Contains(bdls))
            {
                return true;
            }

            return false;
        }
    }
}