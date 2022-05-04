using ff14bot.Managers;

namespace AEAssist.Helper
{
    public static class WorldHelper
    {
        public static ushort CurrZoneId;
        public static uint SubZoneId;
        public static ushort RawZoneId;

        public static void CheckZone()
        {
            var hasChange = false;
            if (CurrZoneId != WorldManager.ZoneId)
            {
                hasChange = true;
                CurrZoneId = WorldManager.ZoneId;
            }

            if (SubZoneId != WorldManager.SubZoneId)
            {
                hasChange = true;
                SubZoneId = WorldManager.SubZoneId;
            }

            if (RawZoneId != WorldManager.RawZoneId)
            {
                hasChange = true;
                RawZoneId = WorldManager.RawZoneId;
            }

            if (hasChange)
            {
                LogHelper.Info(
                    $"Enter new zone: {WorldManager.CurrentLocalizedZoneName} Id: {CurrZoneId} Sub: {WorldManager.SubZoneId} Raw: {WorldManager.RawZoneId}");
                TriggerLineSwitchHelper.ApplyTriggerLine(CurrZoneId, SubZoneId);
            }
        }
    }
}