using System;

namespace Shion.Test
{
    public class TestUtil
    {
        private readonly JsContext _context;

        public TestUtil(JsContext context)
        {
            _context = context;
        }

        public void ThrowError(string message)
        {
            throw new Exception(message);
        }

        public object Eval(string code)
        {
            return _context.Run(code);
        }
    }
}