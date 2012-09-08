using System;
using System.Collections.Generic;
using Shion.Ast;

namespace Shion
{
    public class FunctionDef
    {
        public INode Body { get; set; }
        public List<INode> Params { get; set; }
        public List<INode> Arguments { get; set; }

        public void SetArgs(List<INode> arguments)
        {
            Arguments = arguments;
        }

        public object Invoke(Context context)
        {
            var index = 0;
            Arguments.ForEach(a =>
                                  {
                                      try
                                      {
                                          context.Arguments[((Identifier)Params[index]).Id] = ((Literal)a).Value;
                                      }
                                      catch (Exception)
                                      {
                                          context.Arguments[Guid.NewGuid().ToString()] = ((Literal)a).Value;
                                      }
                                      index++;
                                  });
            return ((IOperation)Body).Invoke(context);
        }
    }
}