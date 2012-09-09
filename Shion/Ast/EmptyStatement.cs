namespace Shion.Ast
{
    [AstType("EmptyStatement")]
    public class EmptyStatement : INode, IOperation
    {
        public INode New(dynamic node)
        {
            return this;
        }

        public dynamic Invoke(Scope scope)
        {
            return new Undefined();
        }
    }
}