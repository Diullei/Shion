using System;
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
            try
            {
                Init = AstTree.Factory(node.Init);
            }
            catch (Exception)
            {
            }

            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Id.ToString());
            if (Init != null)
            {
                sb.Append(" = ");
                sb.Append(Init.ToString());
            }

            return sb.ToString();
        }

        public dynamic Invoke(Scope scope)
        {
            dynamic init = null;
            init = Init != null ? ((IOperation)Init).Invoke(scope) : new Identifier {Id = "null"};

            scope.SetVar(((Identifier) Id).Id, init);
            return init;
        }
    }
}