using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJavascriptRuntime
{
    public class GlobalScope
    {
        public Function Object { get; private set; } = new Function(null, AJavascriptRuntime.Object.Prototype);
        public Function Function { get; private set; } = new Function(null, AJavascriptRuntime.Function.Prototype);
    }
}
