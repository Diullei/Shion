using System;
using Shion.Ast;

namespace Shion
{
    public class Util
    {
        public static dynamic GetValue(dynamic val)
        {
            try
            {
                if (val is Identifier)
                {
                    if (val.Id == "undefined")
                        return new Undefined();
                    if (val.Id == "null")
                        return new Null();
                }
                else if (val == "True" || val == "False")
                    return Convert.ToBoolean(val);
                else if (val is FunctionDef)
                    return val;

                return Convert.ToInt32(val);
            }
            catch (Exception)
            {
                return val;// != null ? val.ToString() : null;
            }
        }
    }
}