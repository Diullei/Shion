using System;
using System.Collections.Generic;

namespace Rasengan.Operations
{
    public class CallExpressionOperation : IOperation
    {
        private List<IOperation> _arguments = new List<IOperation>();
        private IOperation _callee;

        public CallExpressionOperation(dynamic op)
        {
            for (var i = 0; i < op.Arguments.Count; i++)
            {
                var arg = op.Arguments[i];
                _arguments.Add(OpFactory.Factory(arg));
            }

            _callee = OpFactory.Factory(op.Callee);
        }

        public dynamic Invoke(Context context)
        {
            if(_callee is MemberExpressionOperation)
            {
                (_callee as MemberExpressionOperation).Arguments(_arguments);
                return (_callee as MemberExpressionOperation).Invoke(context);
            }

            throw new Exception("Invalid Call Expression");
        }
    }
}