using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.ExpressionTree
{
    class ExpressionTreeSample
    {
        public void DoExpressionThing()
        {
            CalculateExpression();

            Func<string, string> func = (a) => { return a + "100860"; };

            Expression<Func<string, string>> expressionFunc = (a) => a + "100860";

            CalculateExprssionTreeDelegate(expressionFunc);
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
    }
}
