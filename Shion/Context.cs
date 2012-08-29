using System.Collections.Generic;

namespace Shion
{
    public class Context
    {
        public Context()
        {
            VarSet = new Dictionary<string, object>();
            ThisSet = new Dictionary<string, object>();
            FunctionSet = new Dictionary<string, object>();
        }

        public Dictionary<string, object> VarSet { get; set; }
        public Dictionary<string, object> ThisSet { get; set; }
        public Dictionary<string, object> FunctionSet { get; set; }
    }
}