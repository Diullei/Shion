using System;
using System.Text;

namespace Shion.Ast
{
    [AstType("Identifier")]
    public class Identifier : INode, IOperation
    {
        public string Id { get; set; }

        public bool IsMember { get; set; }

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
            if(Id == "undefined")
                return new Undefined();
            else if (Id == "null")
                return new Null();

            return scope.Get(Id, IsMember);
        }
    }
}