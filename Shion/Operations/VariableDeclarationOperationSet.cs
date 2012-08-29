using System.Collections.Generic;

namespace Rasengan.Operations
{
    public class VariableDeclarationOperationSet : List<VariableDeclarationOperation>, IOperation
    {
        public VariableDeclarationOperationSet(dynamic op)
        {
            for (var j = 0; j < op.Declarations.Count; j++)
            {
                var id = op.Declarations[j].Id.Name;
                var init = op.Declarations[j].Init;//.Value;
                Add(new VariableDeclarationOperation(id, init));
            }
        }

        public dynamic Invoke(Context context)
        {
            object result = null;

            ForEach(op =>
                        {
                            result = op.Invoke(context);
                        });
            return result;
        }
    }
}