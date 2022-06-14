using System;
using System.Linq;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Monk
{
    public class MonkSpellHelper
    {
        public static void SetPostion()
        {
            var target = Core.Me.CurrentTarget as Character;
            if (UsingDot())
            {
                if (AIRoot.GetBattleData<BattleData>().lastGCDSpell == SpellsDefine.SnapPunch.GetSpellEntity())
                {
                    if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 10000) == false)
                    {
                        MeleePosition.Intance.RequiredPosition = MeleePosition.Position.Back;
                        return;
                    }
                }
            }

            MeleePosition.Intance.RequiredPosition = MeleePosition.Position.Side;
            return;
        }

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

        public static bool InOpoOpoForm()
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

            if (ActionManager.LastSpellId == SpellsDefine.Bootshine ||
                ActionManager.LastSpellId == SpellsDefine.DragonKick ||
                ActionManager.LastSpellId == SpellsDefine.ArmOfTheDestroyer)
            {
                return true;
            }

            return false;
        }

        // private static async Task<SpellEntity> UseAOECombo(Character target)
        // {
        //     if (InCoeurlForm())
        //     {
        //         if (SpellsDefine.Rockbreaker.IsUnlock())
        //         {
        //             //Rockbreaker 地烈劲
        //             if (await SpellsDefine.Rockbreaker.DoGCD())
        //             {
        //                 return SpellsDefine.Rockbreaker.GetSpellEntity();
        //             }
        //         }
        //         else
        //         {
        //             await UseSingleCombo(target);
        //         }
        //
        //     }
        //
        //     if (InRaptorForm())
        //     {
        //         if (SpellsDefine.FourPointFury.IsUnlock())
        //         {
        //             //Four-point Fury 四面脚
        //             if (await SpellsDefine.FourPointFury.DoGCD())
        //             {
        //                 return SpellsDefine.FourPointFury.GetSpellEntity();
        //             }
        //         }
        //
        //         //Twin Snakes 双掌打
        //         if (await SpellsDefine.TwinSnakes.DoGCD())
        //         {
        //             return SpellsDefine.TwinSnakes.GetSpellEntity();
        //         }
        //     }
        //
        //     //Shadow of the Destroyer 破坏神脚 Action Id:25767
        //     if (SpellsDefine.ShadowOfTheDestroyer.IsUnlock())
        //     {
        //         if (await SpellsDefine.ShadowOfTheDestroyer.DoGCD())
        //         {
        //             return SpellsDefine.ShadowOfTheDestroyer.GetSpellEntity();
        //         }
        //     }
        //
        //     if (Core.Me.HasMyAura(AurasDefine.LeadenFist))
        //     {
        //         //Bootshine 连击
        //         if (await SpellsDefine.Bootshine.DoGCD())
        //         {
        //             return SpellsDefine.Bootshine.GetSpellEntity();
        //         }
        //     }
        //
        //     //Arm of the Destroyer 破坏神冲
        //     if (await SpellsDefine.ArmOfTheDestroyer.DoGCD())
        //     {
        //         return SpellsDefine.ArmOfTheDestroyer.GetSpellEntity();
        //     }
        //
        //     return null;
        // }

        public static async Task<SpellEntity> DoOpoOpoGCDS(Character target)
        {
            if (TargetHelper.CheckNeedUseAOE(target, 5, 5, 3))
            {
                if (SpellsDefine.ShadowOfTheDestroyer.IsUnlock())
                {
                    if (await SpellsDefine.ShadowOfTheDestroyer.DoGCD())
                    {
                        return SpellsDefine.ShadowOfTheDestroyer.GetSpellEntity();
                    }
                }

                if (SpellsDefine.ArmOfTheDestroyer.IsUnlock())
                {
                    //Arm of the Destroyer 破坏神冲
                    if (await SpellsDefine.ArmOfTheDestroyer.DoGCD())
                    {
                        return SpellsDefine.ArmOfTheDestroyer.GetSpellEntity();
                    }
                }
            }

            if (Core.Me.HasMyAura(AurasDefine.LeadenFist) || !SpellsDefine.DragonKick.IsUnlock())
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

        private static async Task<SpellEntity> DoRaptorGCDS(Character target)
        {
            if (InRaptorForm())
            {
                if (TargetHelper.CheckNeedUseAOE(target, 5, 5, 3))
                {
                    if (SpellsDefine.FourPointFury.IsUnlock())
                    {
                        //Four-point Fury 四面脚
                        if (await SpellsDefine.FourPointFury.DoGCD())
                        {
                            return SpellsDefine.FourPointFury.GetSpellEntity();
                        }
                    }
                }


                if (!Core.Me.HasMyAura(AurasDefine.RiddleOfFire) && SpellsDefine.RiddleofFire.CoolDownInGCDs(4))
                {
                    if (!target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 7000))
                    {
                        if (await SpellsDefine.TwinSnakes.DoGCD())
                        {
                            return SpellsDefine.TwinSnakes.GetSpellEntity();
                        }
                    }
                }

                if (Core.Me.HasMyAura(AurasDefine.RiddleOfFire))
                {
                    if (!target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 7000))
                    {
                        if (await SpellsDefine.TwinSnakes.DoGCD())
                        {
                            return SpellsDefine.TwinSnakes.GetSpellEntity();
                        }
                    }
                }

                if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 8000))
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

            return null;
        }

        private static async Task<SpellEntity> DoCoeurlGCDS(Character target)
        {
            if (InCoeurlForm())
            {
                if (TargetHelper.CheckNeedUseAOE(target, 5, 5, 3))
                {
                    if (SpellsDefine.Rockbreaker.IsUnlock())
                    {
                        //Rockbreaker 地烈劲
                        if (await SpellsDefine.Rockbreaker.DoGCD())
                        {
                            return SpellsDefine.Rockbreaker.GetSpellEntity();
                        }
                    }
                }

                if (UsingDot() == false)
                {
                    //Snap Punch 崩拳
                    if (await SpellsDefine.SnapPunch.DoGCD())
                    {
                        return SpellsDefine.SnapPunch.GetSpellEntity();
                    }
                }

                if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 5000))
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
            return null;
        }

        // private static async Task<SpellEntity> UseSingleCombo(Character target)
        // {
        //     if (InCoeurlForm())
        //     {
        //         if (UsingDot() == false)
        //         {
        //             //Snap Punch 崩拳
        //             if (await SpellsDefine.SnapPunch.DoGCD())
        //             {
        //                 return SpellsDefine.SnapPunch.GetSpellEntity();
        //             }
        //         }
        //
        //         if (target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 5000))
        //         {
        //             //Snap Punch 崩拳
        //             if (await SpellsDefine.SnapPunch.DoGCD())
        //             {
        //                 return SpellsDefine.SnapPunch.GetSpellEntity();
        //             }
        //         }
        //
        //         //Demolish 破碎拳
        //         if (await SpellsDefine.Demolish.DoGCD())
        //         {
        //             return SpellsDefine.Demolish.GetSpellEntity();
        //         }
        //     }
        //
        //     if (InRaptorForm())
        //     {
        //         if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 5000))
        //         {
        //             //True Strike 正拳
        //             if (await SpellsDefine.TrueStrike.DoGCD())
        //             {
        //                 return SpellsDefine.TrueStrike.GetSpellEntity();
        //             }
        //         }
        //
        //         //Twin Snakes 双掌打
        //         if (await SpellsDefine.TwinSnakes.DoGCD())
        //         {
        //             return SpellsDefine.TwinSnakes.GetSpellEntity();
        //         }
        //     }
        //
        //     if (Core.Me.HasMyAura(AurasDefine.LeadenFist))
        //     {
        //         //Bootshine 连击
        //         if (await SpellsDefine.Bootshine.DoGCD())
        //         {
        //             return SpellsDefine.Bootshine.GetSpellEntity();
        //         }
        //     }
        //
        //     //Dragon Kick 双龙脚
        //     if (await SpellsDefine.DragonKick.DoGCD())
        //     {
        //         return SpellsDefine.DragonKick.GetSpellEntity();
        //     }
        //
        //     return null;
        // }

        public static async Task<SpellEntity> BaseGCDCombo(Character target)
        {
            if (InCoeurlForm())
            {
                return await DoCoeurlGCDS(target);
            }

            if (InRaptorForm())
            {
                return await DoRaptorGCDS(target);
            }

            return await DoOpoOpoGCDS(target);
            // if (TargetHelper.CheckNeedUseAOE(target, 5, 5, 3)) return await UseAOECombo(target);
            //
            // return await UseSingleCombo(target);
        }

        public static bool UsingDot()
        {
            if (!AEAssist.DataBinding.Instance.UseDot)
            {
                return false;
            }

            var target = Core.Me.CurrentTarget as Character;
            if (TTKHelper.IsTargetTTK(target) ||
                DotBlacklistHelper.IsBlackList(target))
            {
                return false;
            }

            return true;
        }

        private static async Task<SpellEntity> UseLunarNadiCombo(Character target)
        {
            return await DoOpoOpoGCDS(target);
        }

        private static async Task<SpellEntity> UseSolarNadiCombo(Character target)
        {
            //combo1
            if (!ActionResourceManager.Monk.MastersGauge.Contains(ActionResourceManager.Monk.Chakra.Raptor))
            {
                // if we have ROF, buff, go first
                if (Core.Me.HasMyAura(AurasDefine.RiddleOfFire) || SpellsDefine.RiddleofFire.RecentlyUsed())
                {
                    if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 2000))
                    {
                        if (Core.Me.HasMyAura(AurasDefine.LeadenFist))
                        {
                            //Bootshine 连击
                            if (await SpellsDefine.Bootshine.DoGCD())
                            {
                                LogHelper.Info("PerfectBalance - combo 1 - do it because ROF + Buff");
                                return SpellsDefine.Bootshine.GetSpellEntity();
                            }
                        }

                        //Dragon Kick 双龙脚
                        if (await SpellsDefine.DragonKick.DoGCD())
                        {
                            LogHelper.Info("PerfectBalance - combo 1 - do it because ROF + Buff");
                            return SpellsDefine.DragonKick.GetSpellEntity();
                        }
                    }
                }
                // if we not have ROF, other two is done, we have to use it
                else if (ActionResourceManager.Monk.MastersGauge.Contains(ActionResourceManager.Monk.Chakra.Coeurl) &&
                         ActionResourceManager.Monk.MastersGauge.Contains(ActionResourceManager.Monk.Chakra.OpoOpo))
                {
                    if (Core.Me.HasMyAura(AurasDefine.LeadenFist))
                    {
                        //Bootshine 连击
                        if (await SpellsDefine.Bootshine.DoGCD())
                        {
                            LogHelper.Info("PerfectBalance - combo 1 - do it because other two is done");
                            return SpellsDefine.Bootshine.GetSpellEntity();
                        }
                    }

                    //Dragon Kick 双龙脚
                    if (await SpellsDefine.DragonKick.DoGCD())
                    {
                        LogHelper.Info("PerfectBalance - combo 1 - do it because other two is done");
                        return SpellsDefine.DragonKick.GetSpellEntity();
                    }
                }
            }

            //combo2
            if (!ActionResourceManager.Monk.MastersGauge.Contains(ActionResourceManager.Monk.Chakra.Coeurl))
            {
                // if we need it maintain the buff
                if (!Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 3000))
                {
                    if (await SpellsDefine.TwinSnakes.DoGCD())
                    {
                        LogHelper.Info("PerfectBalance - combo 2 - do it to refresh buff");
                        return SpellsDefine.TwinSnakes.GetSpellEntity();
                    }
                }

                // if we not having RoF, it goes first, because high dmg goes to later
                if (!Core.Me.HasMyAura(AurasDefine.RiddleOfFire) && !SpellsDefine.RiddleofFire.RecentlyUsed())
                {
                    if (await SpellsDefine.TwinSnakes.DoGCD())
                    {
                        LogHelper.Info(
                            "PerfectBalance - combo 2 - do it because we don't have ROF, low dmg combo 2 go first");
                        return SpellsDefine.TwinSnakes.GetSpellEntity();
                    }
                }

                // if we have other two, we have to use this
                if (ActionResourceManager.Monk.MastersGauge.Contains(ActionResourceManager.Monk.Chakra.Raptor) &&
                    ActionResourceManager.Monk.MastersGauge.Contains(ActionResourceManager.Monk.Chakra.OpoOpo))
                {
                    if (await SpellsDefine.TwinSnakes.DoGCD())
                    {
                        LogHelper.Info("PerfectBalance - combo 2 - do it because other two is done");
                        return SpellsDefine.TwinSnakes.GetSpellEntity();
                    }
                }
            }

            //combo 3
            if (!ActionResourceManager.Monk.MastersGauge.Contains(ActionResourceManager.Monk.Chakra.OpoOpo))
            {
                if (Core.Me.HasMyAura(AurasDefine.RiddleOfFire) || SpellsDefine.RiddleofFire.RecentlyUsed())
                {
                    if (UsingDot() && !target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 5000))
                    {
                        if (await SpellsDefine.Demolish.DoGCD())
                        {
                            LogHelper.Info("PerfectBalance - combo 3 - do it in rof to refresh dot");
                            return SpellsDefine.Demolish.GetSpellEntity();
                        }
                    }
                    else
                    {
                        if (await SpellsDefine.SnapPunch.DoGCD())
                        {
                            LogHelper.Info("PerfectBalance - combo 3 - do it because we don't need to refresh dot");
                            return SpellsDefine.SnapPunch.GetSpellEntity();
                        }
                    }
                }

                if (ActionResourceManager.Monk.MastersGauge.Contains(ActionResourceManager.Monk.Chakra.Coeurl) &&
                    !Core.Me.HasMyAura(AurasDefine.RiddleOfFire))
                {
                    if (await SpellsDefine.SnapPunch.DoGCD())
                    {
                        LogHelper.Info(
                            "PerfectBalance - combo 3 - do it because we don't have RoF, combo2 is done, push combo 1 to later,");
                        return SpellsDefine.SnapPunch.GetSpellEntity();
                    }
                }
            }


            return null;
        }

        public static async Task<SpellEntity> PerfectBalanceGCDCombo(Character target)
        {
            if (!SpellsDefine.ElixirField.IsUnlock())
            {
                AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
            }
            else
            {
                //有阳打阴 两个都有也打阴
                if (ActionResourceManager.Monk.ActiveNadi == ActionResourceManager.Monk.Nadi.Both ||
                    ActionResourceManager.Monk.ActiveNadi == ActionResourceManager.Monk.Nadi.Solar)
                {
                    AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                }
                //有阴打阳
                else if (ActionResourceManager.Monk.ActiveNadi == ActionResourceManager.Monk.Nadi.Lunar)
                {
                    AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Solar;
                }
                //什么都没有 
                //todo 如果时间都够 怎么接下来打阳
                else if (ActionResourceManager.Monk.ActiveNadi == ActionResourceManager.Monk.Nadi.None &&
                         AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo == MonkNadiCombo.None)
                {
                    //如果双buff时间都够 打阴
                    if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.DisciplinedFist, 7000) &&
                        target.HasMyAuraWithTimeleft(AurasDefine.Demolish, 9000))
                    {
                        AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Lunar;
                    }
                    //如果时间不够打阳
                    else
                    {
                        AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo = MonkNadiCombo.Solar;
                    }
                }
            }

            if (AIRoot.GetBattleData<MonkBattleData>().CurrentMonkNadiCombo == MonkNadiCombo.Solar)
            {
                return await UseSolarNadiCombo(target);
            }

            return await UseLunarNadiCombo(target);
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

        public static bool LastSpellWasNadi()
        {
            var bdls = AIRoot.GetBattleData<BattleData>().lastGCDSpell;
            SpellEntity[] GCDs =
            {
                SpellsDefine.ElixirField.GetSpellEntity(),
                SpellsDefine.FlintStrike.GetSpellEntity(),
                SpellsDefine.CelestialRevolution.GetSpellEntity(),
                SpellsDefine.TornadoKick.GetSpellEntity(),
                SpellsDefine.RisingPhoenix.GetSpellEntity(),
                SpellsDefine.PhantomRush.GetSpellEntity()
            };
            if (GCDs.Contains(bdls))
            {
                return true;
            }

            return false;
        }

        public static bool MasterfulBiltzReady()
        {
            if (ActionResourceManager.Monk.BlitzTimer > TimeSpan.Zero)
            {
                return true;
            }

            return false;
        }
    }
}