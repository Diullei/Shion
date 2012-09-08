using System;
using System.Collections.Generic;

namespace Shion.Ast
{
    [AstType("BlockStatement")]
    public class BlockStatement : INode, IOperation
    {
        public List<INode> Body { get; set; }

        public INode New(dynamic node)
        {
            this.Body = new List<INode>();

            for (var j = 0; j < node.Body.Count; j++)
            {
                this.Body.Add(AstTree.Factory(node.Body[j]));
            }

            return this;
        }

        public dynamic Invoke(Context context)
        {
            object result = null;
            Body.ForEach(line =>
            {
                result = ((IOperation)line).Invoke(context);
            });
            return result;
        }
    }
}