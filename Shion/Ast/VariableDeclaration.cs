using System.Collections.Generic;
using System.Text;

namespace Shion.Ast
{
    [AstType("VariableDeclaration")]
    public class VariableDeclaration : INode, IOperation
    {
        public List<INode> Declarations { get; set; }

        public INode New(dynamic node)
        {
            this.Declarations = new List<INode>();

            for (var j = 0; j < node.Declarations.Count; j++)
            {
                this.Declarations.Add(AstTree.Factory(node.Declarations[j]));
            }

            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("var ");

            var index = 0;
            foreach (var d in Declarations)
            {
                if (index > 0) sb.Append(", ");
                sb.Append(d.ToString());
                index++;
            }

            sb.Append("; ");

            return sb.ToString();

        }

        public dynamic Invoke(Context context)
        {
            object result = null;
            Declarations.ForEach(op =>
            {
                result = ((IOperation)op).Invoke(context);
            });
            return result;
        }
    }
}
