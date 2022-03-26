using System;
using System.Collections.Generic;
using System.Net;
using AEAssist.AI;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.Define
{
    public enum SongStrategyEnum
    {
        WM_MB_AP,
        MB_WM_AP,
        MB_AP_WM
    }
    
    public static class BardSpellEx
    {
        public static SpellData GetWindBite()
        {
            if (Core.Me.ClassLevel < Spells.Windbite.LevelAcquired)
                return null;


            if (Core.Me.ClassLevel < Spells.Stormbite.LevelAcquired)
            {
                if (!ActionManager.HasSpell(Spells.Windbite.Id))
                    return null;
                return Spells.Windbite;
            }
            
            if (!ActionManager.HasSpell(Spells.Stormbite.Id))
                return null;

            return Spells.Stormbite;
        }

        public static int GetWindBiteAura()
        {
            if (Core.Me.ClassLevel < Spells.Windbite.LevelAcquired)
                return 0;


            if (Core.Me.ClassLevel < Spells.Stormbite.LevelAcquired)
            {
                if (!ActionManager.HasSpell(Spells.Windbite.Id))
                    return 0;
                return AurasDefine.Windbite;
            }
            
            if (!ActionManager.HasSpell(Spells.Stormbite.Id))
                return 0;

            return AurasDefine.StormBite;
        }

        public static SpellData GetVenomousBite()
        {
            if (Core.Me.ClassLevel < Spells.VenomousBite.LevelAcquired)
                return null;


            if (Core.Me.ClassLevel < Spells.CausticBite.LevelAcquired)
            {
                if (!ActionManager.HasSpell(Spells.VenomousBite.Id))
                    return null;
                return Spells.VenomousBite;
            }
            
            if (!ActionManager.HasSpell(Spells.CausticBite.Id))
                return null;

            return Spells.CausticBite;
        }
        
        public static int GetVenomousBiteAura()
        {
            if (Core.Me.ClassLevel < Spells.VenomousBite.LevelAcquired)
                return 0;


            if (Core.Me.ClassLevel < Spells.CausticBite.LevelAcquired)
            {
                if (!ActionManager.HasSpell(Spells.VenomousBite.Id))
                    return 0;
                return AurasDefine.VenomousBite;
            }
            
            if (!ActionManager.HasSpell(Spells.CausticBite.Id))
                return 0;

            return AurasDefine.CausticBite;
        }

        public static bool IsTargetHasAura_WindBite(Character target)
        {
            var id = GetWindBiteAura();
            if (id == 0)
                return true; // 让上层觉得已经有Buff了

            return target.ContainMyAura((uint) id, 0);
        }
        
        public static bool IsTargetHasAura_VenomousBite(Character target)
        {
            var id = GetVenomousBiteAura();
            if (id == 0)
                return true; // 让上层觉得已经有Buff了

            return target.ContainMyAura((uint) id, 0);
        }

        public static bool IsTargetNeedIronJaws(Character target)
        {
            if (Core.Me.ClassLevel < Spells.IronJaws.LevelAcquired)
                return false;

            var ve_id = GetVenomousBiteAura();
            if (ve_id == 0)
                return false;
            var wind_id = GetWindBiteAura();
            if (wind_id == 0)
                return false;

            var buffCountInEnd = HasBuffsCountInEnd();
            LogHelper.Info("当前快要结束的Buff数量 : " + buffCountInEnd);
            if (buffCountInEnd >= 1 && !_lastIronJawWithBuff)
            {
                return true;
            }
            
            return !target.ContainMyAura((uint) ve_id, ConstValue.AuraTick)
                   || !target.ContainAura((uint) wind_id, ConstValue.AuraTick);
        }

        private static bool _lastIronJawWithBuff;

        public static void RecordIronJaw()
        {
            _lastIronJawWithBuff = HasBuffsCountInEnd() >= 1;
        }

        public static SpellData GetRefulgentArrow()
        {
            if (Core.Me.ClassLevel < Spells.StraightShot.LevelAcquired)
                return null;
            if (Core.Me.ClassLevel < Spells.RefulgentArrow.LevelAcquired)
                return Spells.StraightShot;
            if (!ActionManager.HasSpell(Spells.RefulgentArrow.Id))
            {
                return Spells.StraightShot;
            }

            return Spells.RefulgentArrow;
        }

        public static SpellData GetBlastArrow()
        {
            if (Core.Me.ClassLevel < Spells.BlastArrow.LevelAcquired)
                return null;
            return Spells.BlastArrow;
        }

        public static SpellData GetHeavyShot()
        {
            if (Core.Me.HasAura(AurasDefine.StraighterShot))
            {
                if (Core.Me.ClassLevel < Spells.RefulgentArrow.LevelAcquired)
                    return Spells.StraightShot;
                if (!ActionManager.HasSpell(Spells.RefulgentArrow.Id))
                {
                    return Spells.StraightShot;
                }
                return Spells.RefulgentArrow;
            }


            if (Core.Me.ClassLevel < Spells.BurstShot.LevelAcquired)
                return Spells.HeavyShot;
            return Spells.BurstShot;
        }

        public static SpellData GetBuffs()
        {
            if (Spells.BattleVoice.IsReady())
            {
                return Spells.BattleVoice;
            }
            
            if (Spells.RadiantFinale.IsReady())
            {
                return Spells.RadiantFinale;
            }
            
            // if (Spells.RagingStrikes.IsReady())
            // {
            //     return Spells.RagingStrikes;
            // }

            return null;
        }

        public static bool IsBuff(SpellData spellData)
        {
            if (spellData == Spells.BattleVoice || spellData == Spells.RagingStrikes ||
                spellData == Spells.RadiantFinale)
                return true;
            return false;
        }

        public static int HasBuffsCount()
        {
            int count = 0;
            if (Core.Me.HasAura(AurasDefine.BattleVoice))
                count++;
            if (Core.Me.HasAura(AurasDefine.RagingStrikes))
                count++;
            if (Core.Me.HasAura(AurasDefine.RadiantFinale))
                count++;
            return count;
        }
        
        public static int HasBuffsCountInEnd(int leftMs = 4000)
        {
            int count = 0;
            if (Core.Me.ContainsMyInEndAura(AurasDefine.BattleVoice,leftMs))
                count++;
            if (Core.Me.ContainsMyInEndAura(AurasDefine.RagingStrikes,leftMs))
                count++;
            if (Core.Me.ContainsMyInEndAura(AurasDefine.RadiantFinale,leftMs))
                count++;
            return count;
        }
        
        public static double TimeUntilNextPossibleDoTTick()
        {
            if (ActionResourceManager.Bard.ActiveSong != ActionResourceManager.Bard.BardSong.None)
                return ActionResourceManager.Bard.Timer.TotalMilliseconds % 3000;

            return 0;
        }

        private static long _lastCastRagingStrikesTime;
        

        public static void RecordUsingRagingStrikesTime()
        {
            _lastCastRagingStrikesTime = TimeHelper.Now();
        }

        public static bool CheckCanUseBuffs(int delayGCD = 2)
        {
            if (!Core.Me.HasMyAura(AurasDefine.RagingStrikes))
            {
                return false;
            }

            if (TimeHelper.Now() - _lastCastRagingStrikesTime >= AIRoot.Instance.GetGCDDuration() * delayGCD)
            {
                return true;
            }

            return false;
        }

        public static SpellData GetQuickNock()
        {
            if (!Spells.Ladonsbite.IsReady())
            {
                if (!Spells.QuickNock.IsReady())
                    return null;
                return Spells.QuickNock;
            }

            return Spells.Ladonsbite;
        }
    }
}