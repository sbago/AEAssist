using System.Windows.Media;
using AEAssist.Define;
using AEAssist.Define.DataStruct;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.BlackMage
{
    public static class BlackMageHelper
    {
        public static bool CanCastFire4()
        {
            if (Core.Me.CurrentMana >= 2400 &&
                BlackMageHelper.IsMaxAstralStacks())
            {
                // not sure what numbders excatly to put here
                if (Core.Me.HasAura(AurasDefine.LeyLines) &&
                    ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 5000)
                {
                    return true;
                }
                else if (ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 5500)
                {
                    return true;
                }
            }

            return false;
        }

        public static ushort PolyglotTimer => ActionResourceManager.CostTypesStruct.timer;

        public static bool IsTargetNeedThunder(Character target, int timeLeft)
        {
            // check thunder 4,3,2,1
            var thunder4 = AurasDefine.Thunder4;
            var thunder3 = AurasDefine.Thunder3;
            var thunder2 = AurasDefine.Thunder2;
            var thunder1 = AurasDefine.Thunder;

            // if not enough time left
            if (target.HasMyAuraWithTimeleft((uint) thunder4) && 
                !target.HasMyAuraWithTimeleft((uint) thunder4, timeLeft))
            {
                Logging.Write("Thunder4 fucked up");
                return true;
            }

            if (target.HasMyAuraWithTimeleft((uint) thunder3) && 
                !target.HasMyAuraWithTimeleft((uint) thunder3, timeLeft))
            {
                Logging.Write("Thunder3 fucked up");
                return true;
            }

            if (target.HasMyAuraWithTimeleft((uint) thunder2) && 
                !target.HasMyAuraWithTimeleft((uint) thunder2, timeLeft))
            {
                Logging.Write("Thunder2 fucked up");
                return true;
            }

            if (target.HasMyAuraWithTimeleft((uint) thunder1) && 
                !target.HasMyAuraWithTimeleft((uint) thunder1, timeLeft))
            {
                Logging.Write("Thunder1 fucked up");
                return true;
            }
            
            // if target has no dot from me, target needs dot
            if (!target.HasMyAuraWithTimeleft((uint) thunder4) &&
                !target.HasMyAuraWithTimeleft((uint) thunder3) &&
                !target.HasMyAuraWithTimeleft((uint) thunder2) &&
                !target.HasMyAuraWithTimeleft((uint) thunder1)
               )
            {
                Logging.Write("Thunder Auracheck fuckedup");
                return true;
            }

            return false;
        }

        public static bool LearnedParadox()
        {
            return Core.Me.ClassLevel >= ConstValue.ParadoxLevelAcquired;
        }
        
        public static bool IsParadoxReady()
        {
            if (!SpellsDefine.Paradox.IsUnlock())
            {
                return false;
            }
            var spell = SpellsDefine.Paradox.GetSpellEntity().SpellData;
            if (ActionManager.CanCastOrQueue(spell, Core.Me.CurrentTarget))
            {
                return true;
            }

            return false;
        }

        public static SpellEntity GetBlizzard3()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                if (aoeCount >= ConstValue.BlackMageAOECount)
                {
                    if (SpellsDefine.HighBlizzardII.IsUnlock())
                    {
                        return SpellsDefine.HighBlizzardII.GetSpellEntity();
                    }

                    // blizzard2 100 * 3 > blizzard3 260
                    if (aoeCount >= 3)
                    {
                        if (SpellsDefine.Blizzard2.IsUnlock())
                        {
                            return SpellsDefine.Blizzard2.GetSpellEntity();
                        }
                    }
                }
            }

            if (SpellsDefine.Blizzard3.IsUnlock())
            {
                return SpellsDefine.Blizzard3.GetSpellEntity();
            }

            return null;
        }

        public static SpellEntity GetDespair()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                if (aoeCount >= ConstValue.BlackMageAOECount)
                {
                    if (SpellsDefine.Flare.IsUnlock())
                    {
                        return SpellsDefine.Flare.GetSpellEntity();
                    }
                }
            }
            if (SpellsDefine.Despair.IsUnlock())
            {
                return SpellsDefine.Despair.GetSpellEntity();
            }
            return null;
        }

        public static SpellEntity GetXenoglossy()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                if (aoeCount >= ConstValue.BlackMageAOECount)
                {
                    if (SpellsDefine.Foul.IsUnlock())
                    {
                        return SpellsDefine.Foul.GetSpellEntity();
                    }
                }
            }
            if (SpellsDefine.Xenoglossy.IsUnlock())
            {
                return SpellsDefine.Xenoglossy.GetSpellEntity();
            }
            return null;
        }

        public static bool test()
        {
            return true;
        }
        
        public static SpellEntity GetParadox()
        {
            // if we learned paradox, go only paradox
            if (SpellsDefine.Paradox.IsUnlock())
            {
                if (BlackMageHelper.IsParadoxReady())
                {
                    return SpellsDefine.Paradox.GetSpellEntity();
                }
                return null;
            }
            // if we have not learned paradox, replace fire paradox with fire, nothing to go in ice
            if (SpellsDefine.Fire.IsUnlock())
            {
                return SpellsDefine.Fire.GetSpellEntity();
            }

            return null;
        }

        public static SpellEntity GetBlizzard4()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                // freeze 120 * 3 > blizzard4 310
                if (aoeCount >= 3)
                {
                    if (SpellsDefine.Freeze.IsUnlock())
                    {
                        return SpellsDefine.Freeze.GetSpellEntity();
                    }
                }
            }
            if (SpellsDefine.Blizzard4.IsUnlock())
            {
                return SpellsDefine.Blizzard4.GetSpellEntity();
            }
            return null;
        }

        public static SpellEntity GetThunder()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                // thunder4 20 * 2 > thunder 3 35
                if (aoeCount >= ConstValue.BlackMageAOECount)
                {
                    if (SpellsDefine.Thunder4.IsUnlock())
                    {
                        return SpellsDefine.Thunder4.GetSpellEntity();
                    }
                    
                    if (SpellsDefine.Thunder2.IsUnlock())
                    {
                        return SpellsDefine.Thunder2.GetSpellEntity();
                    }

                    // thunder2 15 * 3 > thunder2 35
                    else
                    {
                        if (SpellsDefine.Thunder2.IsUnlock())
                        {
                            return SpellsDefine.Thunder2.GetSpellEntity();
                        }
                    }
                }
            }
            if (SpellsDefine.Thunder3.IsUnlock())
            {
                return SpellsDefine.Thunder3.GetSpellEntity();
            }
            
            if (SpellsDefine.Thunder.IsUnlock())
            {
                return SpellsDefine.Thunder.GetSpellEntity();
            }

            return null;
        }

        public static SpellEntity GetFire2()
        {
            if (SpellsDefine.HighFireII.IsUnlock())
            {
                return SpellsDefine.HighFireII.GetSpellEntity();
            }

            if (SpellsDefine.Fire2.IsUnlock())
            {
                return SpellsDefine.Fire2.GetSpellEntity();
            }

            return null;
        }
        
        public static SpellEntity GetFire4()
        {
            if (SpellsDefine.Fire4.IsUnlock())
            {
                return SpellsDefine.Fire4.GetSpellEntity();
            }

            if (SpellsDefine.Fire.IsUnlock())
            {
                return SpellsDefine.Fire.GetSpellEntity();
            }

            return null;
        }

        public static bool InstantCasting()
        {
            if (Core.Me.HasAura(AurasDefine.Triplecast) || Core.Me.HasAura(AurasDefine.Swiftcast))
            {
                return true;
            }

            if (SpellsDefine.Triplecast.RecentlyUsed() || SpellsDefine.Swiftcast.RecentlyUsed())
            {
                return true;
            }

            return false;
        }
        
        public static bool UmbralHeatsReady()
        {
            // so this shit is, we need lv58 to have umbral hearts, and no requirements
            // and lv58, we need to finish request for have the blizzard4 to single target
            
            // if we can't even have  umbralhearts, always pass the check
            if (Core.Me.ClassLevel < 58)
            {
                return true;
            }

            if (ActionResourceManager.BlackMage.UmbralHearts == 3 || 
                SpellsDefine.Blizzard4.RecentlyUsed() ||
                SpellsDefine.Freeze.RecentlyUsed())
            {
                return true;
            }

            return false;

        }

        public static bool IsMaxAstralStacks()
        {
            if (ActionResourceManager.BlackMage.AstralStacks == 3)
            {
                return true;
            }

            if (SpellsDefine.Fire2.RecentlyUsed() ||
                SpellsDefine.Fire3.RecentlyUsed() ||
                SpellsDefine.HighFireII.RecentlyUsed()
               )
            {
                return true;
            }

            return false;
        }

        public static bool IsUmbralFinished()
        {
            // if we are in ice
            if (ActionResourceManager.BlackMage.UmbralStacks > 0)
            {
                if (BlackMageHelper.UmbralHeatsReady() &&
                    !BlackMageHelper.IsParadoxReady() &&
                    Core.Me.CurrentMana == 10000)
                {
                    return true;
                }
            }

            return false;
        }
        
        public static bool IsGCDOpen()
        {
            if (Core.Me.HasAura(AurasDefine.Triplecast))
            {
                return true;
            }

            if (SpellsDefine.Fire3.RecentlyUsed() ||
                SpellsDefine.Blizzard3.RecentlyUsed())
            {
                return true;
            }

            return false;
        }
    }
}