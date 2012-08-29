namespace Rasengan.Operations
{
    public class LiteralOperation : IOperation
    {
        private readonly object _value;

        public LiteralOperation(object value)
        {
            _value = value;
        }

        public dynamic Invoke(Context context)
        {
            return Util.GetValue(_value);
        }
    }
}