using System;
using NUnit.Framework;
using Shion.Ast;

namespace Shion.Test.Sputnik
{
    [TestFixture]
    public class LineTerminatorsTest : BaseTest
	{
        private const string TestPath = @"C:\Users\dgomes\Documents\GitHub\Shion\Shion.Test\Sputnik\sputnik-v1\tests\Conformance\07_Lexical_Conventions\7.3_Line_Terminators\";

        [Test]
        [Category("ECMA 7.3")]
        [TestCase(TestPath + @"S7.3_A1.1_T1.js")]
        [TestCase(TestPath + @"S7.3_A1.1_T2.js")]
        [TestCase(TestPath + @"S7.3_A1.2_T1.js")]
        [TestCase(TestPath + @"S7.3_A1.2_T2.js")]
        [TestCase(TestPath + @"S7.3_A1.3.js")]
        [TestCase(TestPath + @"S7.3_A1.4.js")]
        [TestCase(TestPath + @"S7.3_A2.1_T1.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A2.1_T2.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A2.2_T1.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A2.2_T2.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A2.3.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A2.4.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A3.1_T1.js", ExpectedException = typeof(ReferenceError), ExpectedMessage = "comment is not defined")]
        [TestCase(TestPath + @"S7.3_A3.1_T2.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected identifier")]
        [TestCase(TestPath + @"S7.3_A3.1_T3.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected identifier")]
        [TestCase(TestPath + @"S7.3_A3.2_T1.js", ExpectedException = typeof(ReferenceError), ExpectedMessage = "comment is not defined")]
        [TestCase(TestPath + @"S7.3_A3.2_T2.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected identifier")]
        [TestCase(TestPath + @"S7.3_A3.2_T3.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected identifier")]
        [TestCase(TestPath + @"S7.3_A3.3_T1.js", ExpectedException = typeof(ReferenceError), ExpectedMessage = "comment is not defined")]
        [TestCase(TestPath + @"S7.3_A3.3_T2.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected identifier")]
        [TestCase(TestPath + @"S7.3_A3.4_T1.js", ExpectedException = typeof(ReferenceError), ExpectedMessage = "comment is not defined")]
        [TestCase(TestPath + @"S7.3_A3.4_T2.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected identifier")]
        [TestCase(TestPath + @"S7.3_A4_T1.js")]
        [TestCase(TestPath + @"S7.3_A4_T2.js")]
        [TestCase(TestPath + @"S7.3_A4_T3.js")]
        [TestCase(TestPath + @"S7.3_A4_T4.js")]
        [TestCase(TestPath + @"S7.3_A5.1_T1.js")]
        [TestCase(TestPath + @"S7.3_A5.1_T2.js")]
        [TestCase(TestPath + @"S7.3_A5.2_T1.js")]
        [TestCase(TestPath + @"S7.3_A5.2_T2.js")]
        [TestCase(TestPath + @"S7.3_A5.3.js")]
        [TestCase(TestPath + @"S7.3_A5.4.js")]
        [TestCase(TestPath + @"S7.3_A6_T1.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A6_T2.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A6_T3.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A6_T4.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.3_A7_T1.js")]
        [TestCase(TestPath + @"S7.3_A7_T2.js")]
        [TestCase(TestPath + @"S7.3_A7_T3.js")]
        [TestCase(TestPath + @"S7.3_A7_T4.js")]
        [TestCase(TestPath + @"S7.3_A7_T5.js")]
        [TestCase(TestPath + @"S7.3_A7_T6.js")]
        [TestCase(TestPath + @"S7.3_A7_T7.js")]
        [TestCase(TestPath + @"S7.3_A7_T8.js")]
        public void Test(string file)
        {
            RunTest(file);
        }
	}
}
