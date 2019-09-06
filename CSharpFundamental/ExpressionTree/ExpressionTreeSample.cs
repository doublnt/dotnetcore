using System;
using System.Linq.Expressions;

namespace CSharpFundamental.ExpressionTree
{
    internal class ExpressionTreeSample
    {
        public void DoExpressionThing()
        {
            CalculateExpression();

            Func<string, string> func = a => a + "100860";

            Expression<Func<string, string>> expressionFunc = a => a + "100860";

            CalculateExprssionTreeDelegate(expressionFunc);

            Console.WriteLine(func("Hsdhfskafhad"));

            Console.WriteLine("------------------------------");


            ConstructExpressionTree();
        }

        private void CalculateExpression()
        {
            Expression firstArgs = Expression.Constant(2);
            Expression secondArgs = Expression.Constant(3);

            Expression add = Expression.Add(firstArgs, secondArgs);
              
            Console.WriteLine(add);
        }

        private string CalculateExprssionTreeDelegate(Expression<Func<string, string>> expression)
        {
            var func = expression.Compile();
            return func("Hello from robert!");
        }

        private void ConstructExpressionTree()
        {
            Expression<Func<string, string, bool>> expressionFunc = (a, b) => a.StartsWith(b);

            var func = expressionFunc.Compile();

            Console.WriteLine(func("Robert", "Ro"));

            var method = typeof(string).GetMethod("StartsWith", new[] {typeof(string)});

            var target = Expression.Parameter(typeof(string), "x");
            var methodArg = Expression.Parameter(typeof(string), "y");

            Expression[] methodArgs = {methodArg};

            Expression call = Expression.Call(target, method, methodArgs);

            var lambdaParameters = new[] {target, methodArg};
            var lambda = Expression.Lambda<Func<string, string, bool>>(call, lambdaParameters);

            var complied = lambda.Compile();

            Console.WriteLine(complied("Robert", "Roe"));
        }
    }
}
