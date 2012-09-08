using System.Collections.Generic;
using Shion.Ast;

namespace Shion
{
    public class JsContext
    {
        private readonly Dictionary<string, IOperation> _cache = new Dictionary<string, IOperation>();
        readonly Scope _context = new Scope();

        public object Run(string code)
        {
            if(_cache.ContainsKey(code))
            {
                return _cache[code].Invoke(_context);
            }

            var tree = new Esprima().Parse(code);
            var ast = AstTree.Factory(tree);

            _cache[code] = ast;

            return ((IOperation)ast).Invoke(_context);
        }

        public object Get(string id)
        {
            object val = null;
            if(_context.VarSet.ContainsKey(id))
            {
                val = _context.VarSet[id];
            }

            if (_context.ThisSet.ContainsKey(id))
            {
                val = _context.ThisSet[id];
            }

            return Util.GetValue(val);
        }

        public void Set(string id, object instance)
        {
            _context.ThisSet.Add(id, instance);
        }
    }
}