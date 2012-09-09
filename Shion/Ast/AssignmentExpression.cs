using System;
using System.Text;

namespace Shion.Ast
{
    [AstType("AssignmentExpression")]
    public class AssignmentExpression : INode, IOperation
    {
        public string Operator { get; set; }
        public INode Left { get; set; }
        public INode Right { get; set; }

        public INode New(dynamic node)
        {
            Operator = node.Operator;
            Left = AstTree.Factory(node.Left);
            Right = AstTree.Factory(node.Right);
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Left.ToString());
            sb.Append(Operator);
            sb.Append(Right.ToString());

            return sb.ToString();
        }

        public dynamic Invoke(Scope scope)
        {
            string id = null;

            if (Left is MemberExpression)
                id = ((Identifier)((MemberExpression)Left).Property).Id;

            var val = ((IOperation)Right).Invoke(scope);

            if (Left is MemberExpression)
            {
                scope.SetThis(id, val);
            }
            else if (Left is Identifier)
            {
                scope.SetVar(((Identifier)Left).Id, val);
            }
            else
                throw new Exception();

            return val;
        }
    }
}