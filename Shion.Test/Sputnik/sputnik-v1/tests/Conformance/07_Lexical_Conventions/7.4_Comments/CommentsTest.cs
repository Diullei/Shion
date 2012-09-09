using System;
using NUnit.Framework;
using Shion.Ast;

namespace Shion.Test.Sputnik
{
    [TestFixture]
    public class CommentsTest : BaseTest
	{
        private const string TestPath = @"C:\Users\dgomes\Documents\GitHub\Shion\Shion.Test\Sputnik\sputnik-v1\tests\Conformance\07_Lexical_Conventions\7.4_Comments\";

        [Test]
        [Category("ECMA 7.4")]
        [TestCase(TestPath + @"S7.4_A1_T1.js")]
        [TestCase(TestPath + @"S7.4_A1_T2.js")]
        [TestCase(TestPath + @"S7.4_A2_T1.js")]
        [TestCase(TestPath + @"S7.4_A2_T2.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.4_A3.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token =")]
        public void Test(string file)
        {
            RunTest(file);
        }
	}
}
