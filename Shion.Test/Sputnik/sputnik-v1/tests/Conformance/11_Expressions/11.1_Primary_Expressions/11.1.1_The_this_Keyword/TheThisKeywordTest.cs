using System;
using NUnit.Framework;

namespace Shion.Test.Sputnik.v1._11_Expressions._11_1_Primary_Expressions._11_1_1_The_this_Keyword
{
    [TestFixture]
    public class TheThisKeywordTest : BaseTest
	{
        private const string TestPath = @"C:\Users\dgomes\Documents\GitHub\Shion\Shion.Test\Sputnik\sputnik-v1\tests\Conformance\11_Expressions\11.1_Primary_Expressions\11.1.1_The_this_Keyword\";

        [Test]
        [Category("Sputnik Expressions")]
        [Category("ECMA 11.1.1")]
        [TestCase(TestPath + @"S11.1.1_A1.js", ExpectedException = typeof(Exception), ExpectedMessage = "Invalid left-hand side in assignment")]
        [TestCase(TestPath + @"S11.1.1_A2.js")]
        [TestCase(TestPath + @"S11.1.1_A3.1.js")]
        [TestCase(TestPath + @"S11.1.1_A3.2.js")]
        public void Test(string file)
        {
            RunTest(file);
        }
	}
}
