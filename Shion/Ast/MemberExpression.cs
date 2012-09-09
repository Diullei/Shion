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
            Arguments = new List<INode>();

            Computed = node.Computed;
            Object = AstTree.Factory(node.Object);
            Property = AstTree.Factory(node.Property);
            if (Property is Identifier)
            {
                ((Identifier) Property).IsMember = true;
            }

            return this;
        }

        public dynamic Invoke(Scope scope)
        {
            var obj = ((IOperation)Object).Invoke(scope);
            var args = new List<object>();
            foreach (var t in Arguments)
            {
                args.Add(((IOperation)t).Invoke(scope));
            }
            var prop = ((Identifier)Property).Id;

            var isNative = false;
            var result = Native.GetIfIsNative(obj, prop, ref isNative);
            if (isNative)
                return result;

            if (obj is Scope)
            {
                //var thisSet = ((Scope)obj).ThisSet;
                //return thisSet.ContainsKey(prop) ? thisSet[prop] : new Undefined();
                return ((Scope) obj).GetThisValue(prop);
            }
            else
            {
                if (obj is Native)
                {
                    ((Native)obj).SetCurrentScope(scope);
                }

                try
                {
                    return obj.GetType().GetMethod(prop).Invoke(obj, args.ToArray());
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }
    }
}