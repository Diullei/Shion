using System.Text;

namespace Shion.Ast
{
    [AstType("Identifier")]
    public class Identifier : INode, IOperation
    {
        public string Id { get; set; }

        public INode New(dynamic node)
        {
            Id = node.Name;
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Id);

            return sb.ToString();
        }

        public dynamic Invoke(Context context)
        {
            object val = null;
            if (context.VarSet.ContainsKey(Id))
            {
                val = context.VarSet[Id];
            }

            if (context.ThisSet.ContainsKey(Id))
            {
                val = context.ThisSet[Id];
            }

            return Util.GetValue(val);
        }
    }
}