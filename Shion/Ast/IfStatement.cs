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

        public dynamic Invoke(Scope context)
        {
            if(((IOperation)Test).Invoke(context))
            {
                return ((IOperation) Consequent).Invoke(context);
            }
            
            return Alternate != null ? ((IOperation)Alternate).Invoke(context) : null;
        }
    }
}