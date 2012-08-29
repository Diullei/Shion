using System;
using System.Collections.Generic;
using System.Text;

namespace Shion.Ast
{
    [AstType("CallExpression")]
    public class CallExpression : INode, IOperation
    {
        public INode Callee { get; set; }
        public List<INode> Arguments { get; set; }

        public INode New(dynamic node)
        {
            Arguments = new List<INode>();

            for (var i = 0; i < node.Arguments.Count; i++)
            {
                Arguments.Add(AstTree.Factory(node.Arguments[i]));
            }

            Callee = AstTree.Factory(node.Callee);

            return this;
        }

        public dynamic Invoke(Context context)
        {
            if (Callee is MemberExpression)
            {
                (Callee as MemberExpression).Arguments = Arguments;
                return (Callee as MemberExpression).Invoke(context);
            }

            throw new Exception("Invalid Call Expression");
        }
    }
}