namespace AEAssist.Utilities.CombatMessages
{
    public delegate bool MessageTest();
    
    public class CombatMessageStrategy : ICombatMessageStrategy
    {
        private MessageTest AETest;
        
        public CombatMessageStrategy(int priority, string message, MessageTest test) : this(priority, message, "", test) { }
        
        public CombatMessageStrategy(int priority, string message, string imageSource, MessageTest test)
        {
            Priority = priority;
            Message = message;
            ImageSource = imageSource;
            AETest = test;
        }
        
        public int Priority { get; }
        public string Message { get; }
        public string ImageSource { get; }
        
        public bool ShowMessage() => AETest();
    }
}