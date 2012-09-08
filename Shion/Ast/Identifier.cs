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

        public dynamic Invoke(Scope scope)
        {
            object val = null;
            if (scope.Arguments.ContainsKey(Id))
            {
                val = scope.Arguments[Id];
            }
            if (scope.VarSet.ContainsKey(Id))
            {
                val = scope.VarSet[Id];
            }
            else if (scope.ThisSet.ContainsKey(Id))
            {
                val = scope.ThisSet[Id];
            }

            return Util.GetValue(val);
        }
    }
}