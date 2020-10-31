using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Rogison.Web.Helpers;

namespace Rogison.Helpers
{
    public static class Extensions
    {
        public static bool EqualsEx(this string s, string value)
        {
            return s.Equals(value, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EndsWithEx(this string s, string value)
        {
            return s.EndsWith(value, StringComparison.OrdinalIgnoreCase);
        }

        public static bool StartsWithEx(this string s, string value)
        {
            return s.StartsWith(value, StringComparison.OrdinalIgnoreCase);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            if (property.IndexOf(',') != -1)
            {
                return OrderBy<T>(source, property.Split(','));
            }

            return ApplyOrder<T>(source, property, "OrderBy");
        }
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }
        static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<string> properties)
        {
            // iterate the property names to sort and apply the sort
            IOrderedQueryable<T> sortedData = null;

            foreach (string col in properties)
            {
                string colName = col.Trim();
                bool descending = false;

                if (colName.StartsWith("-"))
                {
                    descending = true;
                    colName = col.Substring(1).Trim();
                }

                // first iteration
                if (sortedData == null)
                {
                    if (descending)
                    {
                        sortedData = source.AsQueryable().OrderByDescending(colName);
                    }
                    else
                    {
                        sortedData = source.AsQueryable().OrderBy(colName);
                    }
                }
                else
                {
                    // subsequent iterations...
                    if (descending)
                    {
                        sortedData = sortedData.ThenByDescending(colName);
                    }
                    else
                    {
                        sortedData = sortedData.ThenBy(colName);
                    }
                }
            }

            return sortedData;
        }
    }
}
