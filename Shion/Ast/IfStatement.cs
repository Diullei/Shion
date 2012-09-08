using System;

namespace Shion.Ast
{
    [AstType("IfStatement")]
    public class IfStatement : INode, IOperation
    {
        public INode Test { get; set; }
        public INode Consequent { get; set; }
        public INode Alternate { get; set; }

        public INode New(dynamic node)
        {
            Test = AstTree.Factory(node.Test);
            Consequent = AstTree.Factory(node.Consequent);

            if (node.Alternate != null)
                Alternate = AstTree.Factory(node.Alternate);

            return this;
        }

        public dynamic Invoke(Scope scope)
        {
            if(((IOperation)Test).Invoke(scope))
            {
                return ((IOperation) Consequent).Invoke(scope);
            }
            
            return Alternate != null ? ((IOperation)Alternate).Invoke(scope) : null;
        }
    }
}