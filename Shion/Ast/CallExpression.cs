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

        public dynamic Invoke(Scope context)
        {
            if (Callee is MemberExpression)
            {
                (Callee as MemberExpression).Arguments = Arguments;
                return (Callee as MemberExpression).Invoke(context);
            } 
            else if(Callee is Identifier)
            {
                if (((Identifier)Callee).Id == "toString")
                    return "[object Object]";

                var fn = (FunctionDef)context.FunctionSet[((Identifier) Callee).Id];
                fn.SetArgs(Arguments);
                return fn.Invoke(context);
            }

            throw new Exception("Invalid Call Expression");
        }
    }
}