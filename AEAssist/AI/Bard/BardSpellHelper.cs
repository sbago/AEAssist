using AEAssist.Define;
using AEAssist.Define.DataStruct;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Bard
{
    public enum SongStrategyEnum
    {
        WM_MB_AP,
        MB_WM_AP,
        MB_AP_WM
    }

    public static class BardSpellHelper
    {
        public static CircleList<SpellEntity> Songs = new CircleList<SpellEntity>();

        public static void Init()
        {
            Songs.Clear();
            Songs.Add(SpellsDefine.TheWanderersMinuet.GetSpellEntity());
            Songs.Add(SpellsDefine.MagesBallad.GetSpellEntity());
            Songs.Add(SpellsDefine.ArmysPaeon.GetSpellEntity());
        }

        public static SpellEntity GetWindBite()
        {
            if (!SpellsDefine.Windbite.IsUnlock())
                return null;


            if (!SpellsDefine.Stormbite.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.Windbite))
                    return null;
                return SpellsDefine.Windbite.GetSpellEntity();
            }

            if (!ActionManager.HasSpell(SpellsDefine.Stormbite))
                return null;

            return SpellsDefine.Stormbite.GetSpellEntity();
        }

        public static int GetWindBiteAura()
        {
            if (!SpellsDefine.Windbite.IsUnlock())
                return 0;


            if (!SpellsDefine.Stormbite.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.Windbite))
                    return 0;
                return AurasDefine.Windbite;
            }

            if (!ActionManager.HasSpell(SpellsDefine.Stormbite))
                return 0;

            return AurasDefine.StormBite;
        }

        public static SpellEntity GetVenomousBite()
        {
            if (!SpellsDefine.VenomousBite.IsUnlock())
                return null;


            if (!SpellsDefine.CausticBite.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.VenomousBite))
                    return null;
                return SpellsDefine.VenomousBite.GetSpellEntity();
            }

            if (!ActionManager.HasSpell(SpellsDefine.CausticBite))
                return null;

            return SpellsDefine.CausticBite.GetSpellEntity();
        }

        public static int GetVenomousBiteAura()
        {
            if (!SpellsDefine.VenomousBite.IsUnlock())
                return 0;


            if (!SpellsDefine.CausticBite.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.VenomousBite))
                    return 0;
                return AurasDefine.VenomousBite;
            }

            if (!ActionManager.HasSpell(SpellsDefine.CausticBite))
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

        public static bool IsTargetNeedIronJaws(Character target, int timeLeft)
        {
            if (!SpellsDefine.IronJaws.IsUnlock())
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
                if (AEAssist.DataBinding.Instance.EarlyDecisionMode)
                    timeLeft += SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;

                return !target.ContainMyAura((uint) ve_id, timeLeft)
                       || !target.ContainAura((uint) wind_id, timeLeft);
            }

            var buffCountInEnd = HasBuffsCountInEnd();
            //LogHelper.Info("当前快要结束的Buff数量 : " + buffCountInEnd);
            if (buffCountInEnd >= 1 && !AIRoot.GetBattleData<BardBattleData>().IsTargetLastIronJawWithBuff())
            {
                if (ttk_ironJaws > 0 && target.ContainMyAura((uint) ve_id, ttk_ironJaws * 1000) &&
                    TTKHelper.IsTargetTTK(target, ttk_ironJaws, false))
                    return NormalCheck();
                return true;
            }


            return NormalCheck();
        }

        public static void RecordIronJaw()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            AIRoot.GetBattleData<BardBattleData>().lastIronJawWithBuffWithObj[targetId] = HasBuffsCount() >= 1;
        }

        public static void RemoveRecordIronJaw()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            AIRoot.GetBattleData<BardBattleData>().lastIronJawWithBuffWithObj[targetId] = false;
        }

        public static SpellEntity GetRefulgentArrow()
        {
            if (!SpellsDefine.StraightShot.IsUnlock())
                return null;
            if (!SpellsDefine.RefulgentArrow.IsUnlock())
                return SpellsDefine.StraightShot.GetSpellEntity();
            if (!ActionManager.HasSpell(SpellsDefine.RefulgentArrow)) return SpellsDefine.StraightShot.GetSpellEntity();

            return SpellsDefine.RefulgentArrow.GetSpellEntity();
        }

        public static SpellEntity GetBlastArrow()
        {
            if (!SpellsDefine.BlastArrow.IsUnlock())
                return null;
            return SpellsDefine.BlastArrow.GetSpellEntity();
        }

        public static SpellEntity GetBaseGCD()
        {
            if (Core.Me.HasAura(AurasDefine.StraighterShot) || SpellsDefine.Barrage.RecentlyUsed())
            {
                if (!SpellsDefine.RefulgentArrow.IsUnlock())
                    return SpellsDefine.StraightShot.GetSpellEntity();
                if (!ActionManager.HasSpell(SpellsDefine.RefulgentArrow))
                    return SpellsDefine.StraightShot.GetSpellEntity();

                return SpellsDefine.RefulgentArrow.GetSpellEntity();
            }


            return GetHeavyShot();
        }

        public static SpellEntity GetHeavyShot()
        {
            if (!SpellsDefine.BurstShot.IsUnlock())
                return SpellsDefine.HeavyShot.GetSpellEntity();
            return SpellsDefine.BurstShot.GetSpellEntity();
        }

        public static SpellEntity GetBuffs()
        {
            if (SpellsDefine.BattleVoice.IsReady()) return SpellsDefine.BattleVoice.GetSpellEntity();

            if (SpellsDefine.RadiantFinale.IsReady()) return SpellsDefine.RadiantFinale.GetSpellEntity();

            // if (Spells.RagingStrikes.IsReady())
            // {
            //     return Spells.RagingStrikes;
            // }

            return null;
        }

        public static bool IsBuff(SpellEntity SpellEntity)
        {
            if (SpellEntity.Id == SpellsDefine.BattleVoice || SpellEntity.Id == SpellsDefine.RagingStrikes ||
                SpellEntity.Id == SpellsDefine.RadiantFinale)
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
            if (AIRoot.Instance.CloseBurst)
                return false;
            if (SpellsDefine.RagingStrikes.GetSpellEntity().Cooldown.TotalMilliseconds < time) return true;

            if (!SpellsDefine.RagingStrikes.RecentlyUsed() && !Core.Me.HasAura(AurasDefine.RagingStrikes)) return false;

            if (SpellsDefine.BattleVoice.GetSpellEntity().Cooldown.TotalMilliseconds < time) return true;

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
                if (AIRoot.GetBattleData<BattleData>().lastGCDIndex
                    - SpellHistoryHelper.GetLastGCDIndex(SpellsDefine.RagingStrikes) >
                    delayGCD)
                    return true;

                return false;
            }

            if (SpellsDefine.RagingStrikes.IsReady()) return false;

            if (SpellsDefine.RagingStrikes.GetSpellEntity().Cooldown.TotalMilliseconds > 60000)
                return true;

            return false;
        }

        public static SpellEntity GetQuickNock()
        {
            if (IsShadowBiteReady()) return SpellsDefine.Shadowbite.GetSpellEntity();

            if (!SpellsDefine.Ladonsbite.IsReady())
            {
                if (!SpellsDefine.QuickNock.IsReady())
                    return null;
                return SpellsDefine.QuickNock.GetSpellEntity();
            }

            return SpellsDefine.Ladonsbite.GetSpellEntity();
        }

        public static bool IsShadowBiteReady()
        {
            if (!SpellsDefine.Shadowbite.IsReady()) return false;

            if (Core.Me.ContainMyAura(AurasDefine.ShadowBiteReady)) return true;

            return false;
        }

        public static int PrepareSwitchSong()
        {
            if (!AEAssist.DataBinding.Instance.UseSong)
                return -110;
            var currSong = ActionResourceManager.Bard.ActiveSong;
            var remainTime = ActionResourceManager.Bard.Timer.TotalMilliseconds - 500;


            if (!AIRoot.Instance.CloseBurst)
            {
                if (SpellsDefine.ArmysPaeon.GetSpellEntity().Cooldown.TotalMilliseconds > 1000
                    && SpellsDefine.MagesBallad.GetSpellEntity().Cooldown.TotalMilliseconds > 1000
                    && SpellsDefine.TheWanderersMinuet.GetSpellEntity().Cooldown.TotalMilliseconds > 1000)
                    return -103;

                if (AIRoot.GetBattleData<BardBattleData>().NeedSwitchByNextSongQueue((int) currSong, remainTime))
                    return 100;

                switch (currSong)
                {
                    case ActionResourceManager.Bard.BardSong.None:
                        return 101;
                    case ActionResourceManager.Bard.BardSong.MagesBallad:
                        if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_MB_TimeLeftForSwitch)
                            return 102;
                        break;
                    case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                        if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_AP_TimeLeftForSwitch)
                            return 103;
                        break;
                    case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                        if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_WM_TimeLeftForSwitch)
                            return 104;
                        break;
                }

                return -100;
            }

            if (SpellsDefine.ArmysPaeon.GetSpellEntity().Cooldown.TotalMilliseconds > 1000
                && SpellsDefine.MagesBallad.GetSpellEntity().Cooldown.TotalMilliseconds > 1000)
                return -102;

            // 关爆发的时候,让歌唱完
            if (currSong != ActionResourceManager.Bard.BardSong.None)
            {
                if (AIRoot.GetBattleData<BardBattleData>().NeedSwitchByNextSongQueue((int) currSong, remainTime))
                    return 201;

                if (remainTime <= ConstValue.SongsTimeLeftCheckWhenCloseBuff) return 202;

                return -101;
            }

            return 301;
        }
    }
}