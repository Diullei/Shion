using System;
using System.IO;
using NUnit.Framework;
using Shion.Ast;

namespace Shion.Test
{
    public class BaseTest
    {
        protected JsContext Context;

        [SetUp]
        public void Setup()
        {
            Context = new JsContext();
            Context.Set("___testUtil", new TestUtil());
            Context.Run("function $ERROR(message){ return ___testUtil.ThrowError(message); }");
        }

        protected void RunTest(string file)
        {
            try
            {
                Context.Run(File.ReadAllText(file));
            }
            catch (SyntaxError ex)
            {
                var message = ex.Message;
                if (message.StartsWith("Line "))
                {
                    throw new SyntaxError(message.Substring(message.IndexOf(':') + 1).Trim());
                }
                throw;
            }
            catch (ReferenceError ex)
            {
                var message = ex.Message;
                if (message.StartsWith("Line "))
                {
                    throw new ReferenceError(message.Substring(message.IndexOf(':') + 1).Trim());
                }
                throw;
            }
        }
    }
}