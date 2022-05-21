namespace AEAssist
{
    public interface ITriggerBase
    {
        void WriteFromJson(string[] values);
        string[] Pack2Json();
    }
}