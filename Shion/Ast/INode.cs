namespace Shion.Ast
{
    public interface INode
    {
        INode New(dynamic node);
    }
}