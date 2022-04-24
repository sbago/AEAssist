using System;
using System.Linq;
using System.Threading.Tasks;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.Define
{
    public enum SpellTargetType
    {
        Self = -1,
        CurrTarget = 0,
        PM1 = 1,
        PM2,
        PM3,
        PM4,
        PM5,
        PM6,
        PM7,
        PM8
    }


    public class SpellEntity : Entity
    {
        public static SpellEntity Create()
        {
            return ObjectPool.Instance.Fetch<SpellEntity>();
        }
        
        public static SpellEntity Create(uint spellId)
        {
            var spell = Create();
            spell.SpellData = DataManager.GetSpellData(spellId);
            return spell;
        }
        
        protected override void OnDestroy()
        {
            ObjectPool.Instance.Return(this);
        }

        public SpellEntity()
        {
            
        }

        public SpellEntity(uint id)
        {
            SpellData = DataManager.GetSpellData(id);
        }

        public SpellEntity(uint id, SpellTargetType targetIndex) : this(id)
        {
            this.SpellTargetType = targetIndex;
        }

        public SpellData SpellData;
        public SpellTargetType SpellTargetType;

        public uint Id => SpellData.Id;

        public TimeSpan Cooldown => SpellData.Cooldown;

        public TimeSpan AdjustedCooldown => SpellData.AdjustedCooldown;
        

        public async Task<bool> DoAction()
        {
            if (SpellData == null)
                return false;
            if (SpellData.SpellType == SpellType.Weaponskill)
            {
                return await DoGCD();
            }

            return await DoAbility();
        }


        public BattleCharacter GetTarget()
        {
            switch (SpellTargetType)
            {
                case SpellTargetType.Self:
                    return Core.Me;
                case SpellTargetType.CurrTarget:
                    return Core.Me.CurrentTarget as BattleCharacter;
                case SpellTargetType.PM1:
                case SpellTargetType.PM2:
                case SpellTargetType.PM3:
                case SpellTargetType.PM4:
                case SpellTargetType.PM5:
                case SpellTargetType.PM6:
                case SpellTargetType.PM7:
                case SpellTargetType.PM8:
                    if (!PartyManager.IsInParty)
                        return null;
                    var index = (int) SpellTargetType - 1;
                    var count = 0;
                    foreach (var v in PartyManager.AllMembers)
                    {
                        if (count == index)
                        {
                            return v.BattleCharacter;
                        }

                        count++;
                    }

                    break;
            }

            return null;
        }

        public async Task<bool> DoGCD()
        {
            if (SpellData == null)
                return false;
            var target = GetTarget();
            if (target == null)
                return false;
            await SpellHelper.CastGCD(SpellData, target);
            return false;
        }
        
        public async Task<bool> DoAbility()
        {
            if (SpellData == null)
                return false;
            var target = GetTarget();
            if (target == null)
                return false;
            return await SpellHelper.CastAbility(SpellData, target);
        }
        
        public bool RecentlyUsed(int span = 1000)
        {
            var time = SpellHistoryHelper.GetLastSpellTime(SpellData.Id);
            if (TimeHelper.Now() - time < span)
                return true;
            return false;
        }

        public bool CanCastGCD()
        {
            return SpellHelper.CanCastGCD(SpellData, GetTarget());
        }
    }
}