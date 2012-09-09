namespace Shion.Ast
{
    public class Undefined
    {
        public override bool Equals(object obj)
        {
            return (obj is Undefined);
        }

        public bool Equals(Undefined other)
        {
            return !ReferenceEquals(null, other);
        }

        public static bool operator !=(object a, Undefined b)
        {
            return a is Undefined;
        }

        public static bool operator ==(object a, Undefined b)
        {
            return !(a != b);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return "undefined";
        }
    }
}