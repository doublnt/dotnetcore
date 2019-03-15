using IronPython.Hosting;

using Microsoft.Scripting.Hosting;

namespace CSharpFundamental
{
    public class PythonEmbedded
    {
        public void ExecutePythonCode()
        {
            ScriptEngine engine = Python.CreateEngine();
            engine.Execute("print 'Hello World'");
        }

        public void ExecutePythonMethodInCode()
        {
            // string python = @"
            // def sayHello(user):
            //     print 'Hello %(name)s' % {'name' : user}
            // ";

            // ScriptEngine engine = Python.CreateEngine();
            // ScriptScope scope = engine.CreateScope();

            // engine.Execute(python, scope);
            // dynamic function = scope.GetVariable("sayHello");
            // function("Jon");
        }
    }
}
