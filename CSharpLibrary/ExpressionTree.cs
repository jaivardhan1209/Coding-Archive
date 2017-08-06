using Codepractice.Custom;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Codepractice.CSharpLibrary
{
    public static class ExpressionTree
    {
        public static void ConstructSimplestExpression()
        {
            Expression<Func<int>> expression;

            expression = () => 0; // Construct expression tree through lambda expression syntax.

           // expression = Expression.Lambda<Func<int>>(Expression.Constant(0)); // Construct the tree through API syntax.
        }

        public static void CompileAndRunSimpestExpression(int n)
        {
            ParameterExpression pe = Expression.Parameter(typeof(Test), "s");

            MemberExpression me = Expression.Property(pe, "Age");

            ConstantExpression constant = Expression.Constant(18, typeof(int));

            BinaryExpression body = Expression.GreaterThanOrEqual(me, constant);

            var ExpressionTree = Expression.Lambda<Func<Test, bool>>(body, new[] { pe });

            Console.WriteLine("Expression Tree: {0}", ExpressionTree);

            Console.WriteLine("Expression Tree Body: {0}", ExpressionTree.Body);

            Console.WriteLine("Number of Parameters in Expression Tree: {0}",
                                            ExpressionTree.Parameters.Count);

            Console.WriteLine("Parameters in Expression Tree: {0}", ExpressionTree.Parameters[0]);
        }

        public static Expression<Func<T, bool>> GetExpression<T>(string propertyName, string propertyValue)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var someValue = Expression.Constant(propertyValue, typeof(string));
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);

            return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
        }

    }
}
