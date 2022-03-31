using AETriggers.TriggerModel;

namespace AETriggers
{
    public static class Entry
    {
        public static void Init()
        {
            TriggerHelper.CreateTemplateFile("./Triggers");
        }
    }
}