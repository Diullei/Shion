using System;
using System.IO;
using NUnit.Framework;

namespace Shion.Test
{
    public class BaseTest
    {
        protected JsContext Context;

        [SetUp]
        public void Setup()
        {
            Context = new JsContext();
            Context.Set("___testUtil", new TestUtil(Context));
            Context.Run("function $ERROR(message){ return ___testUtil.ThrowError(message); }");
            Context.Run("function eval(code){ return ___testUtil.Eval(code); }");
        }

        protected void RunTest(string file)
        {
            try
            {
                Context.Run(File.ReadAllText(file));
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (message.StartsWith("Line "))
                {
                    throw new Exception(message.Substring(message.IndexOf(':') + 1).Trim());
                }
                else
                    throw;
            }
        }
    }
}