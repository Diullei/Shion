using System;

namespace Shion.Ast
{
    public class AstTypeAttribute : Attribute
    {
        public string Identifier { get; set; }

        public AstTypeAttribute(string identifier)
        {
            Identifier = identifier;
        }
    }
}