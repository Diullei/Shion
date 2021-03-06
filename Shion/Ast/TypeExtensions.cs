﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Shion.Ast
{
    public static class TypeExtensions
    {
        public static T GetAttribute<T>(this Type typeWithAttributes)
            where T : Attribute
        {
            return GetAttributes<T>(typeWithAttributes).FirstOrDefault();
        }

        public static IEnumerable<T> GetAttributes<T>(this Type typeWithAttributes)
            where T : Attribute
        {
            object[] configAttributes = Attribute.GetCustomAttributes(typeWithAttributes, typeof(T), false);

            if (configAttributes != null)
            {
                foreach (T attribute in configAttributes)
                {
                    yield return attribute;
                }
            }
        }
    }
}