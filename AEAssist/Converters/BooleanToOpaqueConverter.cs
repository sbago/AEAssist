namespace AEAssist.Converters
{
    public class BooleanToOpaqueConverter :  BooleanConverter<double>
    {
            public BooleanToOpaqueConverter() : base(1.0, 0.0) { }
    }
}