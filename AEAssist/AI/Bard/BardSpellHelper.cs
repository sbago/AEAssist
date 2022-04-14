using AEAssist.AI;
using AEAssist.Helper;
using ff14bot;
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

    public static class BardSpellHelper
    {
        public static CircleList<SpellData> Songs = new CircleList<SpellData>();

        public static void Init()
        {
            Songs.Clear();
            Songs.Add(SpellsDefine.TheWanderersMinuet);
            Songs.Add(SpellsDefine.MagesBallad);
            Songs.Add(SpellsDefine.ArmysPaeon);
        }

        public static SpellData GetWindBite()
        {
            if (Core.Me.ClassLevel < SpellsDefine.Windbite.LevelAcquired)
                return null;


            if (Core.Me.ClassLevel < SpellsDefine.Stormbite.LevelAcquired)
            {
                if (!ActionManager.HasSpell(SpellsDefine.Windbite.Id))
                    return null;
                return SpellsDefine.Windbite;
            }

            if (!ActionManager.HasSpell(SpellsDefine.Stormbite.Id))
                return null;

            return SpellsDefine.Stormbite;
        }

        public static int GetWindBiteAura()
        {
            if (Core.Me.ClassLevel < SpellsDefine.Windbite.LevelAcquired)
                return 0;


            if (Core.Me.ClassLevel < SpellsDefine.Stormbite.LevelAcquired)
            {
                if (!ActionManager.HasSpell(SpellsDefine.Windbite.Id))
                    return 0;
                return AurasDefine.Windbite;
            }

            if (!ActionManager.HasSpell(SpellsDefine.Stormbite.Id))
                return 0;

            return AurasDefine.StormBite;
        }

        public static SpellData GetVenomousBite()
        {
            if (Core.Me.ClassLevel < SpellsDefine.VenomousBite.LevelAcquired)
                return null;


            if (Core.Me.ClassLevel < SpellsDefine.CausticBite.LevelAcquired)
            {
                if (!ActionManager.HasSpell(SpellsDefine.VenomousBite.Id))
                    return null;
                return SpellsDefine.VenomousBite;
            }

            if (!ActionManager.HasSpell(SpellsDefine.CausticBite.Id))
                return null;

            return SpellsDefine.CausticBite;
        }

        public static int GetVenomousBiteAura()
        {
            if (Core.Me.ClassLevel < SpellsDefine.VenomousBite.LevelAcquired)
                return 0;


            if (Core.Me.ClassLevel < SpellsDefine.CausticBite.LevelAcquired)
            {
                if (!ActionManager.HasSpell(SpellsDefine.VenomousBite.Id))
                    return 0;
                return AurasDefine.VenomousBite;
            }

            if (!ActionManager.HasSpell(SpellsDefine.CausticBite.Id))
                return 0;

            return AurasDefine.CausticBite;
        }

        public static bool IsTargetHasAura_WindBite(Character target)
        {
            var id = GetWindBiteAura();
            if (id == 0)
                return true; // 让上层觉得已经有Buff了

            return target.ContainMyAura((uint) id);
        }

        public static bool IsTargetHasAura_VenomousBite(Character target)
        {
            var id = GetVenomousBiteAura();
            if (id == 0)
                return true; // 让上层觉得已经有Buff了

            return target.ContainMyAura((uint) id);
        }

        public static bool IsTargetNeedIronJaws(Character target)
        {
            if (Core.Me.ClassLevel < SpellsDefine.IronJaws.LevelAcquired)
                return false;

            var ve_id = GetVenomousBiteAura();
            if (ve_id == 0)
                return false;
            var wind_id = GetWindBiteAura();
            if (wind_id == 0)
                return false;

            var ttk_ironJaws = SettingMgr.GetSetting<BardSettings>().TTK_IronJaws;

            bool NormalCheck()
            {
                return !target.ContainMyAura((uint) ve_id, ConstValue.AuraTick)
                       || !target.ContainAura((uint) wind_id, ConstValue.AuraTick);
            }

            var buffCountInEnd = HasBuffsCountInEnd();
            //LogHelper.Info("当前快要结束的Buff数量 : " + buffCountInEnd);
            if (buffCountInEnd >= 1 && !AIRoot.Instance.BardBattleData.IsTargetLastIronJawWithBuff())
            {
                if (ttk_ironJaws > 0 && target.ContainMyAura((uint) ve_id, ttk_ironJaws * 1000) &&
                    TTKHelper.IsTargetTTK(target, ttk_ironJaws,false))
                    return NormalCheck();
                return true;
            }


            return NormalCheck();
        }

        public static void RecordIronJaw()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            AIRoot.Instance.BardBattleData.lastIronJawWithBuffWithObj[targetId] = HasBuffsCount() >= 1;
        }

        public static void RemoveRecordIronJaw()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            AIRoot.Instance.BardBattleData.lastIronJawWithBuffWithObj[targetId] = false;
        }

        public static SpellData GetRefulgentArrow()
        {
            if (Core.Me.ClassLevel < SpellsDefine.StraightShot.LevelAcquired)
                return null;
            if (Core.Me.ClassLevel < SpellsDefine.RefulgentArrow.LevelAcquired)
                return SpellsDefine.StraightShot;
            if (!ActionManager.HasSpell(SpellsDefine.RefulgentArrow.Id)) return SpellsDefine.StraightShot;

            return SpellsDefine.RefulgentArrow;
        }

        public static SpellData GetBlastArrow()
        {
            if (Core.Me.ClassLevel < SpellsDefine.BlastArrow.LevelAcquired)
                return null;
            return SpellsDefine.BlastArrow;
        }

        public static SpellData GetHeavyShot()
        {
            if (Core.Me.HasAura(AurasDefine.StraighterShot))
            {
                if (Core.Me.ClassLevel < SpellsDefine.RefulgentArrow.LevelAcquired)
                    return SpellsDefine.StraightShot;
                if (!ActionManager.HasSpell(SpellsDefine.RefulgentArrow.Id)) return SpellsDefine.StraightShot;

                return SpellsDefine.RefulgentArrow;
            }


            if (Core.Me.ClassLevel < SpellsDefine.BurstShot.LevelAcquired)
                return SpellsDefine.HeavyShot;
            return SpellsDefine.BurstShot;
        }

        public static SpellData GetBuffs()
        {
            if (SpellsDefine.BattleVoice.IsReady()) return SpellsDefine.BattleVoice;

            if (SpellsDefine.RadiantFinale.IsReady()) return SpellsDefine.RadiantFinale;

            // if (Spells.RagingStrikes.IsReady())
            // {
            //     return Spells.RagingStrikes;
            // }

            return null;
        }

        public static bool IsBuff(SpellData spellData)
        {
            if (spellData == SpellsDefine.BattleVoice || spellData == SpellsDefine.RagingStrikes ||
                spellData == SpellsDefine.RadiantFinale)
                return true;
            return false;
        }

        public static int HasBuffsCount()
        {
            var count = 0;
            if (Core.Me.HasAura(AurasDefine.BattleVoice))
                count++;
            if (Core.Me.HasAura(AurasDefine.RagingStrikes))
                count++;
            if (Core.Me.HasAura(AurasDefine.RadiantFinale))
                count++;
            return count;
        }

        public static int UnlockBuffsCount()
        {
            var count = 0;
            if (SpellsDefine.BattleVoice.IsUnlock())
                count++;
            if (SpellsDefine.RagingStrikes.IsUnlock())
                count++;
            if (SpellsDefine.RadiantFinale.IsUnlock())
                count++;
            return count;
        }

        public static int HasBuffsCountInEnd(int leftMs = 4000)
        {
            var count = 0;
            if (Core.Me.ContainsMyInEndAura(AurasDefine.BattleVoice, leftMs))
                count++;
            if (Core.Me.ContainsMyInEndAura(AurasDefine.RagingStrikes, leftMs))
                count++;
            if (Core.Me.ContainsMyInEndAura(AurasDefine.RadiantFinale, leftMs))
                count++;
            return count;
        }

        public static bool Prepare2BurstBuffs(int time = 10000)
        {
            if (AIRoot.Instance.BurstOff)
                return false;
            if (SpellsDefine.RagingStrikes.Cooldown.TotalMilliseconds < time) return true;

            if (!SpellsDefine.RagingStrikes.RecentlyUsed() && !Core.Me.HasAura(AurasDefine.RagingStrikes)) return false;

            if (SpellsDefine.BattleVoice.Cooldown.TotalMilliseconds < time) return true;

            return false;
        }

        public static double TimeUntilNextPossibleDoTTick()
        {
            if (ActionResourceManager.Bard.ActiveSong != ActionResourceManager.Bard.BardSong.None)
                return ActionResourceManager.Bard.Timer.TotalMilliseconds % 3000;

            return 0;
        }


        public static void RecordUsingRagingStrikesTime()
        {
        }

        public static bool CheckCanUseBuffs()
        {
            var delayGCD = SettingMgr.GetSetting<BardSettings>().BuffsDelay2GCD ? 2 : 1;
            var gcdActionTime = SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;

            var currSong = ActionResourceManager.Bard.ActiveSong;
            if (currSong == ActionResourceManager.Bard.BardSong.None)
                return false;

            if (SpellsDefine.RagingStrikes.RecentlyUsed() || Core.Me.HasMyAura(AurasDefine.RagingStrikes))
            {
                if (AIRoot.Instance.BattleData.lastGCDIndex
                    - SpellHistoryHelper.GetLastGCDIndex(SpellsDefine.RagingStrikes.Id) >
                    delayGCD)
                    return true;

                return false;
            }

            if (SpellsDefine.RagingStrikes.IsReady()) return false;

            if (SpellsDefine.RadiantFinale.IsReady() &&
                SpellsDefine.BattleVoice.Cooldown.TotalMilliseconds < 15000) return false;

            return true;
        }

        public static SpellData GetQuickNock()
        {
            if (IsShadowBiteReady()) return SpellsDefine.Shadowbite;

            if (!SpellsDefine.Ladonsbite.IsReady())
            {
                if (!SpellsDefine.QuickNock.IsReady())
                    return null;
                return SpellsDefine.QuickNock;
            }

            return SpellsDefine.Ladonsbite;
        }

        public static bool IsShadowBiteReady()
        {
            if (!SpellsDefine.Shadowbite.IsReady()) return false;

            if (Core.Me.ContainMyAura(AurasDefine.ShadowBiteReady)) return true;

            return false;
        }

        public static bool PrepareSwitchSong()
        {
            var currSong = ActionResourceManager.Bard.ActiveSong;
            var remainTime = ActionResourceManager.Bard.Timer.TotalMilliseconds;


            if (!AIRoot.Instance.BurstOff)
            {
                if (AIRoot.Instance.BardBattleData.nextSong == ActionResourceManager.Bard.BardSong.None
                    && currSong != ActionResourceManager.Bard.BardSong.None
                    && AIRoot.Instance.BardBattleData.nextSongDuration != 0)
                    if (remainTime <= 45000 - AIRoot.Instance.BardBattleData.nextSongDuration)
                        return true;

                switch (currSong)
                {
                    case ActionResourceManager.Bard.BardSong.None:
                        return true;
                    case ActionResourceManager.Bard.BardSong.MagesBallad:
                        if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_MB_TimeLeftForSwitch)
                            return true;
                        break;
                    case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                        if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_AP_TimeLeftForSwitch)
                            return true;
                        break;
                    case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                        if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_WM_TimeLeftForSwitch)
                            return true;
                        break;
                }

                return false;
            }

            // 关爆发的时候,让歌唱完
            if (currSong != ActionResourceManager.Bard.BardSong.None)
            {
                if (AIRoot.Instance.BardBattleData.nextSong == ActionResourceManager.Bard.BardSong.None
                    && AIRoot.Instance.BardBattleData.nextSongDuration != 0)
                    if (remainTime <= 45000 - AIRoot.Instance.BardBattleData.nextSongDuration)
                        return true;

                if (remainTime <= ConstValue.SongsTimeLeftCheckWhenCloseBuff)
                    return true;
                return false;
            }

            return true;
        }
    }
}