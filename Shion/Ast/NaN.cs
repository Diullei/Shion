namespace Shion.Ast
{
    public class NaN
    {
        public override bool Equals(object obj)
        {
            return (obj is NaN);
        }

        public bool Equals(NaN other)
        {
            return !ReferenceEquals(null, other);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return "NaN";
        }
    }
}