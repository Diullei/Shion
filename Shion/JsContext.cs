using System;
using System.Collections.Generic;
using Shion.Ast;

namespace Shion
{
    public class JsContext
    {
        private readonly Dictionary<string, IOperation> _cache = new Dictionary<string, IOperation>();
        private readonly Scope _scope = new Scope { IsGlobal = true};

        public JsContext()
        {
            Native.SetUp(this);
        }

        public object Run(string code)
        {
            return Run(null, code);
        }

        public object Run(Scope scope, string code)
        {
            if(_cache.ContainsKey(code))
            {
                return _cache[code].Invoke(scope ?? _scope);
            }

            dynamic tree = null;

            try
            {
                tree = new Esprima().Parse(code);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Invalid left-hand side in assignment"))
                    throw new ReferenceError(ex.Message);
                throw new SyntaxError(ex.Message);
            }

            var ast = AstTree.Factory(tree);

            _cache[code] = ast;

            return ((IOperation)ast).Invoke(scope ?? _scope);
        }

        public object Get(string id)
        {
            return Get(null, id);
        }

        public object Get(Scope scope, string id)
        {
            object val = (scope ?? _scope).Get(id);
            //if((scope ?? _scope).VarSet.ContainsKey(id))
            //{
            //    val = (scope ?? _scope).VarSet[id];
            //}

            //if ((scope ?? _scope).ThisSet.ContainsKey(id))
            //{
            //    val = (scope ?? _scope).ThisSet[id];
            //}

            return val;
            //return Util.GetValue(val);
        }

        public void Set(string id, object instance)
        {
            Set(null, id, instance);
        }

        public void Set(Scope scope, string id, object instance)
        {
            (scope ?? _scope).SetThis(id, instance);
        }
    }
}