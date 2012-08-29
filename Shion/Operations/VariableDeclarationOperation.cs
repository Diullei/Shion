namespace Rasengan.Operations
{
    public class VariableDeclarationOperation : IOperation
    {
        private Context _context;
        private readonly string _id;
        private readonly IOperation _value = new LiteralOperation(null);

        public VariableDeclarationOperation(string id, dynamic value)
        {
            _id = id;

            if(value.Type == "Literal")
            {
                _value = new LiteralOperation(value.Value);
            }
            else if (value.Type == "BinaryExpression")
            {
                _value = new BinaryExpressionOperation(value);
            }
        }

        public dynamic Invoke(Context context)
        {
            _context = context;
            _context.VarSet.Add(_id, _value.Invoke(_context));
            return _value;
        }
    }
}