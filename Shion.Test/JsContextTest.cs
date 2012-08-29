using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shion.Test
{
    [TestClass]
    public class JsContextTest
    {
        public class ConsoleTest
        {
            public void log(string value)
            {
                Console.WriteLine(value);
            }
        }

        [TestMethod]
        public void VarDeclarationAndBasicOperationsTest()
        {
            var code = "var s = 3, r = 6\n"
                     + "/* */var t = 1;"
                     + "var name = 'string';"
                     + "var w = t + s;"
                     + "var z = (w + (((s) + 6)) + (1 * 2));"
                     ;

            var context = new JsContext();
            context.Run(code);

            Assert.AreEqual(3, context.Get("s"));
            Assert.AreEqual(6, context.Get("r"));
            Assert.AreEqual(1, context.Get("t"));
            Assert.AreEqual("string", context.Get("name"));
            Assert.AreEqual(4, context.Get("w"));
            Assert.AreEqual(15, context.Get("z"));

            var res = (bool)context.Run("z > w");
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void ExternalObjects()
        {
            var context = new JsContext();

            context.Set("console", new ConsoleTest());
            context.Run("console.log('teste')");
        }
    }
}