using System;
using System.Collections.Generic;

namespace Shion.Ast
{
    [AstType("NewExpression")]
    public class NewExpression : INode, IOperation
    {
        public INode Callee { get; set; }
        public List<INode> Arguments { get; set; }

        public INode New(dynamic node)
        {
            Callee = AstTree.Factory(node.Callee);
            Arguments = new List<INode>();
            for (var j = 0; j < node.Arguments.Count; j++)
            {
                this.Arguments.Add(AstTree.Factory(node.Arguments[j]));
            }
            return this;
        }

        public dynamic Invoke(Scope scope)
        {
            var newScope = new Scope();

            // copy global scope
            //if(scope.IsGlobal)
            {
                scope.CloneVarSet(newScope);
                //foreach (var m in scope.VarSet) { newScope.VarSet[m.Key] = m.Value; }
                scope.CloneThisSet(newScope);
                //foreach (var m in scope.ThisSet) { newScope.ThisSet[m.Key] = m.Value; }
                scope.CloneFunctionSet(newScope);
                //foreach (var m in scope.FunctionSet) { newScope.FunctionSet[m.Key] = m.Value; }
            }

            var index = 0;
            if (Arguments != null)
                Arguments.ForEach(a =>
                {
                    try
                    {
                        newScope.SetArgument(((Identifier)Arguments[index]).Id, ((Literal)a).Value);
                    }
                    catch (Exception)
                    {
                        newScope.SetArgument(Guid.NewGuid().ToString(), ((Literal)a).Value);
                    }
                    index++;
                });

            var id = ((Identifier)Callee).Id;
            FunctionDef fn = scope.Get(id);

            fn.SetArgs(Arguments);

            var result = fn.Invoke(newScope);

            return result;
        }
    }
}