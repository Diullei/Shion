using System;
using System.Linq;
using System.Reflection;

namespace Shion.Ast
{
    public static class AstTree
    {
        public static INode Factory(dynamic tree)
        {
            INode node = null;
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().ToList())
            {
                var attr = type.GetAttribute<AstTypeAttribute>();
                if(attr != null)
                {
                    if(attr.Identifier == tree.Type)
                    {
                        return ((INode)Activator.CreateInstance(type)).New(tree);
                    }
                }
            }

            throw new Exception("Invalid " + tree.Type);
        }
    }
}