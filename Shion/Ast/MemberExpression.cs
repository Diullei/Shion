using System;
using System.Collections.Generic;

namespace Shion.Ast
{
    [AstType("MemberExpression")]
    public class MemberExpression : INode, IOperation
    {
        public bool Computed { get; set; }
        public INode Object { get; set; }
        public INode Property { get; set; }
        public List<INode> Arguments { get; set; }

        public INode New(dynamic node)
        {
            Computed = node.Computed;
            Object = AstTree.Factory(node.Object);
            Property = AstTree.Factory(node.Property);

            return this;
        }

        public dynamic Invoke(Scope context)
        {
            var obj = ((IOperation)Object).Invoke(context);
            var args = new List<object>();
            foreach (var t in Arguments)
            {
                args.Add(((IOperation)t).Invoke(context));
            }
            var prop = ((Identifier)Property).Id;

            if (obj is Scope)
            {
                if (prop == "toString")
                    return "[object Object]";
                throw new Exception();
            }
            else
                return obj.GetType().GetMethod(prop).Invoke(obj, args.ToArray());
        }
    }
}