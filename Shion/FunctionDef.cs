using System;
using System.Collections.Generic;
using Shion.Ast;

namespace Shion
{
    public class FunctionDef
    {
        public INode Body { get; set; }
        public List<INode> Params { get; set; }
        //public List<object> ParameterValues { get; set; }
        public List<INode> Arguments { get; set; }

        //public object ResolveParameterValue(INode node)
        //{
        //    var index = Params.IndexOf(node);
        //    return ParameterValues[index];
        //}

        public void SetArgs(List<INode> arguments)
        {
            //ParameterValues = new List<object>();

            //var index = 0;
            //foreach (var argument in arguments)
            //{
            //    if(index < Params.Count)
            //    {
            //        //if(Params[index] is Identifier)
            //        {
            //            ParameterValues.Add(((Literal)argument).Value);
            //        }
            //    }
            //    index++;
            //}

            Arguments = arguments;
        }

        public object Invoke(Scope scope)
        {
            var index = 0;
            if (Arguments != null)
                Arguments.ForEach(a =>
                                      {
                                          object val = null;
                                          if (a is Literal)
                                              val = ((Literal)a).Value;
                                          else
                                              val = ((IOperation) a).Invoke(scope);

                                          try
                                          {
                                              scope.SetArgument(((Identifier)Params[index]).Id, val);
                                          }
                                          catch (Exception)
                                          {
                                              scope.SetArgument(Guid.NewGuid().ToString(), val);
                                          }
                                          index++;
                                      });
            return ((IOperation)Body).Invoke(scope);
        }
    }
}