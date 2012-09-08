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

            Id = AstTree.Factory(node.Id);
            Body = AstTree.Factory(node.Body);
            for (var j = 0; j < node.Params.Count; j++)
            {
                this.Params.Add(AstTree.Factory(node.Params[j]));
            }

            return this;
        }

        public dynamic Invoke(Scope context)
        {
            //Params.ForEach(p => { context.ArgSet[((Identifier) p).Id] = null; });
            context.FunctionSet[((Identifier)Id).Id] = new FunctionDef { Body = Body, Params = Params };
            return null;
        }
    }

    //public class Function
    //{
    //    public INode Body { get; set; }
    //    public List<INode> Params { get; set; }
    //}
}