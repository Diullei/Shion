using System.Collections.Generic;

namespace Rasengan.Operations
{
    public class MemberExpressionOperation : IOperation
    {
        private readonly IOperation _object;
        private readonly IOperation _property;
        private List<IOperation> _arguments;

        public MemberExpressionOperation(dynamic op)
        {
            _object = OpFactory.Factory(op.Object);
            _property = OpFactory.Factory(op.Property);
        }

        public void Arguments(List<IOperation> arguments)
        {
            _arguments = arguments;
        }

        public dynamic Invoke(Context context)
        {
            var obj = _object.Invoke(context);
            var args = new List<object>();
            foreach (var t in _arguments)
            {
                args.Add(t.Invoke(context));
            }
            var prop = (string)((IdentifierOperation) _property).Id;
            return obj.GetType().GetMethod(prop).Invoke(obj, args.ToArray());
        }
    }
}