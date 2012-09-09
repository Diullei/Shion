using System;
using System.Collections.Generic;

namespace Shion.Ast
{
    [AstType("UpdateExpression")]
    public class UpdateExpression : INode, IOperation
    {
        public string Operator { get; set; }
        public INode Argument { get; set; }

        public INode New(dynamic node)
        {
            Operator = node.Operator;
            Argument = AstTree.Factory(node.Argument);

            return this;
        }

        public dynamic Invoke(Scope scope)
        {
            switch (Operator)
            {
                case "++":
                    if(Argument is MemberExpression)
                    {
                        if (((MemberExpression)Argument).Object is ThisExpression)
                        {
                            var val = ((IOperation) Argument).Invoke(scope);
                            return scope.Handle(
                                    ((Identifier)((MemberExpression) Argument).Property).Id, 
                                    true,
                                    HandleHelp(val));
                        }
                        else
                            return new NaN();
                    }
                    break;
                default:

                    throw new Exception("Invalid operator: " + Operator);
            }
            return new Undefined();
        }

        private static dynamic HandleHelp(dynamic value)
        {
            if(value is Undefined)
                return new NaN();
            else if (value is Null)
                return new NaN();
            else
            {
                var val = Util.GetValue(value);
                if (val is Undefined)
                    return new NaN();
                if (val is Null)
                    return new NaN();
            }
            return value++;
        }
    }
}