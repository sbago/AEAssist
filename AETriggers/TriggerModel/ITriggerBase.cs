namespace AETriggers.TriggerModel
{
    public interface ITriggerBase
    {
        string CondName { get;}
        string Remark { get; }

        bool Check();
    }
}