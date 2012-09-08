using System;
using System.Text;

namespace Shion.Ast
{
    [AstType("Literal")]
    public class Literal : INode, IOperation
    {
        public object Value { get; set; }

        public INode New(dynamic node)
        {
            Value = node.Value;
            return this;
        }

        public override string ToString()
        {
            var value = Util.GetValue(Value);

            var sb = new StringBuilder();
            if (value is string) sb.Append("\"");
            sb.Append(value);
            if (value is string) sb.Append("\"");
            return sb.ToString();
        }

        public dynamic Invoke(Context context)
        {
            return Util.GetValue(Value);
        }
    }
}