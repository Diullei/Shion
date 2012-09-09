using System;
using NUnit.Framework;
using Shion.Ast;

namespace Shion.Test.Sputnik
{
    [TestFixture]
    public class WhiteSpaceTest : BaseTest
	{
        private const string TestPath = @"C:\Users\dgomes\Documents\GitHub\Shion\Shion.Test\Sputnik\sputnik-v1\tests\Conformance\07_Lexical_Conventions\7.2_White_Space\";

        [Test]
        [Category("ECMA 7.2")]
        [TestCase(TestPath + @"S7.2_A1.1_T1.js")]
        [TestCase(TestPath + @"S7.2_A1.1_T2.js")]
        [TestCase(TestPath + @"S7.2_A1.2_T1.js")]
        [TestCase(TestPath + @"S7.2_A1.2_T2.js")]
        [TestCase(TestPath + @"S7.2_A1.3_T1.js")]
        [TestCase(TestPath + @"S7.2_A1.3_T2.js")]
        [TestCase(TestPath + @"S7.2_A1.4_T1.js")]
        [TestCase(TestPath + @"S7.2_A1.4_T2.js")]
        [TestCase(TestPath + @"S7.2_A1.5_T1.js")]
        [TestCase(TestPath + @"S7.2_A1.5_T2.js")]
        [TestCase(TestPath + @"S7.2_A2.1_T1.js")]
        [TestCase(TestPath + @"S7.2_A2.1_T2.js")]
        [TestCase(TestPath + @"S7.2_A2.2_T1.js")]
        [TestCase(TestPath + @"S7.2_A2.2_T2.js")]
        [TestCase(TestPath + @"S7.2_A2.3_T1.js")]
        [TestCase(TestPath + @"S7.2_A2.3_T2.js")]
        [TestCase(TestPath + @"S7.2_A2.4_T1.js")]
        [TestCase(TestPath + @"S7.2_A2.4_T2.js")]
        [TestCase(TestPath + @"S7.2_A2.5_T1.js")]
        [TestCase(TestPath + @"S7.2_A2.5_T2.js")]
        [TestCase(TestPath + @"S7.2_A3.1_T1.js")]
        [TestCase(TestPath + @"S7.2_A3.1_T2.js")]
        [TestCase(TestPath + @"S7.2_A3.2_T1.js")]
        [TestCase(TestPath + @"S7.2_A3.2_T2.js")]
        [TestCase(TestPath + @"S7.2_A3.3_T1.js")]
        [TestCase(TestPath + @"S7.2_A3.3_T2.js")]
        [TestCase(TestPath + @"S7.2_A3.4_T1.js")]
        [TestCase(TestPath + @"S7.2_A3.4_T2.js")]
        [TestCase(TestPath + @"S7.2_A3.5_T1.js")]
        [TestCase(TestPath + @"S7.2_A3.5_T2.js")]
        [TestCase(TestPath + @"S7.2_A4.1_T1.js")]
        [TestCase(TestPath + @"S7.2_A4.1_T2.js")]
        [TestCase(TestPath + @"S7.2_A4.2_T1.js")]
        [TestCase(TestPath + @"S7.2_A4.2_T2.js")]
        [TestCase(TestPath + @"S7.2_A4.3_T1.js")]
        [TestCase(TestPath + @"S7.2_A4.3_T2.js")]
        [TestCase(TestPath + @"S7.2_A4.4_T1.js")]
        [TestCase(TestPath + @"S7.2_A4.4_T2.js")]
        [TestCase(TestPath + @"S7.2_A4.5_T1.js")]
        [TestCase(TestPath + @"S7.2_A4.5_T2.js")]
        [TestCase(TestPath + @"S7.2_A5_T1.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.2_A5_T2.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.2_A5_T3.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.2_A5_T4.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        [TestCase(TestPath + @"S7.2_A5_T5.js", ExpectedException = typeof(SyntaxError), ExpectedMessage = "Unexpected token ILLEGAL")]
        public void Test(string file)
        {
            RunTest(file);
        }
	}
}
