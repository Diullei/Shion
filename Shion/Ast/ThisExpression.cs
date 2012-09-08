namespace Shion.Ast
{
    [AstType("ThisExpression")]
    public class ThisExpression : INode, IOperation
    {
        public INode New(dynamic node)
        {
            return this;
        }

        public dynamic Invoke(Context context)
        {
            return context;
        }
    }
}