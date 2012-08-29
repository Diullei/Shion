using System.Text;

namespace Shion.Ast
{
    [AstType("ExpressionStatement")]
    public class ExpressionStatement : INode, IOperation
    {
        public INode Expression { get; set; }

        public INode New(dynamic node)
        {
            Expression = AstTree.Factory(node.Expression);
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Expression.ToString());
            sb.Append("; ");

            return sb.ToString();
        }

        public dynamic Invoke(Context context)
        {
            return ((IOperation) Expression).Invoke(context);
        }
    }
}