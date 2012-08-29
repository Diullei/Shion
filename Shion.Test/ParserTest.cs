using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shion.Test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void TestParseAutoSemiColonBeforeNewlineAndComments()
        {
            var tree = new Esprima().Parse(
                    "var s = 3\n"
                  + "/* */var t = 1;"
                );

            Assert.AreEqual("VariableDeclarator", tree.Body[0].Declarations[0].Type);
            Assert.AreEqual("s", tree.Body[0].Declarations[0].Id.Name);
            Assert.AreEqual("Literal", tree.Body[0].Declarations[0].Init.Type);
            Assert.AreEqual("3", tree.Body[0].Declarations[0].Init.Value);

            Assert.AreEqual("VariableDeclarator", tree.Body[1].Declarations[0].Type);
            Assert.AreEqual("t", tree.Body[1].Declarations[0].Id.Name);
            Assert.AreEqual("Literal", tree.Body[1].Declarations[0].Init.Type);
            Assert.AreEqual("1", tree.Body[1].Declarations[0].Init.Value);
        }
    }
}