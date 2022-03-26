using System.Collections.Generic;
using System.Linq;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Objects;

namespace AEAssist.Helper
{
    public static class AuraHelper
    {
        public static bool ContainAura(this Character character, uint id, int timeLeft = 0)
        {
            if (character.HasAura(id))
            {
                var aura = character.GetAuraById(id);
                if (aura.TimespanLeft.TotalMilliseconds > timeLeft)
                    return true;
            }

            return false;
        }
        
        public static bool ContainMyAura(this Character character, uint id, int timeLeft = 0)
        {
            if (character.HasMyAura(id))
            {
                var aura = character.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Id == id);
                if (aura.Any(vc=>vc.TimespanLeft.TotalMilliseconds > timeLeft))
                    return true;
            }

            return false;
        }

        public static bool ContainsMyInEndAura(this Character character, uint id, int timeLeft = 0)
        {
            if (character.HasMyAura(id))
            {
                var aura = character.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Id == id);
                if (aura.Any(vc=>vc.TimespanLeft.TotalMilliseconds <= timeLeft))
                    return true;
            }

            return false;
        }
        
        public static bool HasAnyAura(this GameObject unit, List<uint> auras,  int msLeft = 0)
        {
            var unitAsCharacter = unit as Character;

            if (unitAsCharacter == null || !unitAsCharacter.IsValid)
            {
                return false;
            }

            return unitAsCharacter.CharacterAuras.Any(r => auras.Contains(r.Id) && r.TimespanLeft.TotalMilliseconds >= msLeft);
        }
    }
}