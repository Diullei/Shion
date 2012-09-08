namespace Shion.Ast
{
    public interface IOperation
    {
        dynamic Invoke(Scope context);
    }
}