namespace AEAssist.TriggerAction
{
    [Trigger("UsePotion",Tooltip = "Immediately use the Potion configured in PotionSetting\n" +
                                   "立即使用爆发药设置中的爆发药",
        NeedParams = false)]
    public class TriggerAction_UsePotion : ITriggerAction
    {
        public void WriteFromJson(string[] values)
        {
        }

        public string[] Pack2Json()
        {
            return null;
        }
    }
}