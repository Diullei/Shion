using System;
using Shion.Ast;

namespace Shion
{
    public class Native
    {
        private readonly JsContext _context;
        private Scope _scope;

        public Native(JsContext context)
        {
            _context = context;
        }

        public void SetCurrentScope(Scope scope)
        {
            _scope = scope;
        }

        public object Eval(string code)
        {
            return _context.Run(_scope, code);
        }

        public object IsNaN(dynamic val)
        {
            return val is NaN;
        }

        public object Function(string code)
        {
            return _context.Run(_scope, "(function(){" + code + "})");
        }

        public static dynamic GetIfIsNative(object node, string member, ref bool @is)
        {
            if (node is Identifier)
            {
                if (((Identifier)node).Id == "toString")
                {
                    @is = true;
                    return "[object Object]";
                }
            }
            else if (node is Scope)
            {
                if (member == "toString")
                {
                    @is = true;
                    return "[object Object]";
                }
            }

            return null;
        }

        public static void SetUp(JsContext context)
        {
            context.Set("___native", new Native(context));
            context.Run("function eval(code){ return ___native.Eval(code); }");
            context.Run("function Function(code){ return ___native.Function(code); }");
            context.Run("function isNaN(val){ return ___native.IsNaN(val); }");
        }
    }
}