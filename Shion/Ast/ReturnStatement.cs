﻿using System;

namespace Shion.Ast
{
    [AstType("ReturnStatement")]
    public class ReturnStatement : INode, IOperation
    {
        public INode Argument { get; set; }

        public INode New(dynamic node)
        {
            Argument = AstTree.Factory(node.Argument);
            return this;
        }

        public dynamic Invoke(Scope scope)
        {
            return ((IOperation) Argument).Invoke(scope);
        }
    }
}