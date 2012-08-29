using System.Text;

namespace Shion.Ast
{
    [AstType("VariableDeclarator")]
    public class VariableDeclarator : INode, IOperation
    {
        public INode Id { get; set; }
        public INode Init { get; set; }

        public INode New(dynamic node)
        {
            Id = AstTree.Factory(node.Id);
            Init = AstTree.Factory(node.Init);

            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Id.ToString());
            sb.Append(" = ");
            sb.Append(Init.ToString());

            return sb.ToString();

        }

        public dynamic Invoke(Context context)
        {
            var init = ((IOperation)Init).Invoke(context);
            context.VarSet.Add(((Identifier)Id).Id, init);
            return init;
        }
    }
}