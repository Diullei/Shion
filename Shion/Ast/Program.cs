using System.Collections.Generic;
using System.Text;

namespace Shion.Ast
{
    [AstType("Program")]
    public class Program : INode, IOperation
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            Body.ForEach(b => sb.Append(b.ToString()));
            return sb.ToString();
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