using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shion.Ast
{
    public static class AstTree
    {
        private static Dictionary<string, Type> _cache = new Dictionary<string, Type>();

        private static void LoadCache()
        {
            if (_cache.Count > 0)
                return;

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().ToList())
            {
                var attr = type.GetAttribute<AstTypeAttribute>();
                if (attr != null)
                {
                    _cache[attr.Identifier] = type;
                }
            }
        }

        public static INode Factory(dynamic tree)
        {
            LoadCache();

            if (_cache.ContainsKey(tree.Type))
            {
                return ((INode)Activator.CreateInstance(_cache[tree.Type])).New(tree);
            }
            
            throw new Exception("Invalid " + tree.Type);
        }
    }
}