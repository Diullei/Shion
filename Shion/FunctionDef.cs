using System.Collections.Generic;
using Shion.Ast;

namespace Shion
{
    public class FunctionDef
    {
        public Dictionary<string, object> Args { get; set; }

        public IOperation Operations { get; set; }

        public object Invoke(Context context)
        {
            return Operations.Invoke(context);
        }
    }
}