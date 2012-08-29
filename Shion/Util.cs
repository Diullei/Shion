using System;

namespace Shion
{
    public class Util
    {
        public static dynamic GetValue(dynamic val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch (Exception)
            {
                try
                {
                    return Convert.ToBoolean(val);
                }
                catch (Exception)
                {
                    return val;// != null ? val.ToString() : null;
                }
            }
        }
    }
}