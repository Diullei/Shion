using System;

namespace Shion.Ast
{
    public class SyntaxError : Exception
    {
        public SyntaxError(string message)
            : base(message)
        {
        }
    }
}