namespace Rasengan.Operations
{
    public class IdentifierOperation : IOperation
    {
        private string _id;

        public IdentifierOperation(string id)
        {
            _id = id;
        }

        public object Id
        {
            get { return _id; }
        }

        public dynamic Invoke(Context context)
        {
            object val = null;
            if (context.VarSet.ContainsKey(_id))
            {
                val = context.VarSet[_id];
            }

            if (context.ThisSet.ContainsKey(_id))
            {
                val = context.ThisSet[_id];
            }

            return Util.GetValue(val);
        }
    }
}