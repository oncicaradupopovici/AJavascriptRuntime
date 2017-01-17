using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AJavascriptRuntime
{
    public delegate object FunctionBody(Object context, object[] arguments);

    public class JavaScriptRuntime
    {
        public const string undefined = "undefined";

        public GlobalScope GlobalScope = new GlobalScope();

        public JavaScriptRuntime()
        {
        }

    }
    
}
