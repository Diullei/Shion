using System.Collections.Generic;
using Shion.Ast;

namespace Shion
{
    public class JsContext
    {
        private readonly Dictionary<string, IOperation> _cache = new Dictionary<string, IOperation>();
        readonly Scope _scope = new Scope();

        public object Run(string code)
        {
            if(_cache.ContainsKey(code))
            {
                return _cache[code].Invoke(_scope);
            }

            var tree = new Esprima().Parse(code);
            var ast = AstTree.Factory(tree);

            _cache[code] = ast;

            return ((IOperation)ast).Invoke(_scope);
        }

        public object Get(string id)
        {
            object val = null;
            if(_scope.VarSet.ContainsKey(id))
            {
                val = _scope.VarSet[id];
            }

            if (_scope.ThisSet.ContainsKey(id))
            {
                val = _scope.ThisSet[id];
            }

            return Util.GetValue(val);
        }

        public void Set(string id, object instance)
        {
            _scope.ThisSet.Add(id, instance);
        }
    }
}