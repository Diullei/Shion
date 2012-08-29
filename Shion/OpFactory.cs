using Rasengan.Operations;

namespace Rasengan
{
    public class OpFactory
    {
        public static IOperation Factory(dynamic op)
        {
            if (op.Type == "VariableDeclaration")
            {
                return new VariableDeclarationOperationSet(op);
            }
            else if (op.Type == "Identifier")
            {
                return new IdentifierOperation(op.Name);
            }
            else if (op.Type == "Literal")
            {
                return new LiteralOperation(op.Value);
            }
            else if (op.Type == "BinaryExpression")
            {
                return new BinaryExpressionOperation(op);
            }
            else if (op.Type == "ExpressionStatement")
            {
                return OpFactory.Factory(op.Expression);
            }
            else if (op.Type == "CallExpression")
            {
                return new CallExpressionOperation(op);
            }
            else if (op.Type == "MemberExpression")
            {
                return new MemberExpressionOperation(op);
            }

            return null;
        }
    }
}