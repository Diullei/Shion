using System;
using System.Collections.Generic;

namespace Shion.Ast
{
    [AstType("FunctionDeclaration")]
    public class FunctionDeclaration : INode, IOperation
    {
        public INode Id { get; set; }
        public INode Body { get; set; }
        public List<INode> Params { get; set; }

        public INode New(dynamic node)
        {
            Params = new List<INode>();

            try
            {
                Id = AstTree.Factory(node.Id);
            }
            catch (Exception)
            {
                Id = new Identifier() { Id = "<anonymous>" };
            }

            Body = AstTree.Factory(node.Body);
            for (var j = 0; j < node.Params.Count; j++)
            {
                this.Params.Add(AstTree.Factory(node.Params[j]));
            }

            return this;
        }

        public dynamic Invoke(Scope scope)
        {
            //Params.ForEach(p => { context.ArgSet[((Identifier) p).Id] = null; });
            var function = new FunctionDef { Body = Body, Params = Params };
            scope.SetFunction(((Identifier)Id).Id, function);
            return function;
        }
    }
}