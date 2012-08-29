namespace Shion.Ast
{
    public interface IOperation
    {
        dynamic Invoke(Context context);
    }
}