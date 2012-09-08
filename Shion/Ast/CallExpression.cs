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

        public dynamic Invoke(Scope scope)
        {
            if (Callee is MemberExpression)
            {
                (Callee as MemberExpression).Arguments = Arguments;
                return (Callee as MemberExpression).Invoke(scope);
            } 
            else if(Callee is Identifier)
            {
                if (((Identifier)Callee).Id == "toString")
                    return "[object Object]";

                var fn = (FunctionDef)scope.FunctionSet[((Identifier) Callee).Id];
                fn.SetArgs(Arguments);
                return fn.Invoke(scope);
            }

            throw new Exception("Invalid Call Expression");
        }
    }
}