using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJavascriptRuntime
{
    public class Function : Object
    {
        private FunctionBody _body;
        public Object prototype { get; set; }

        internal static new Function Prototype = new Function(Object.Prototype);

        private Function(Object proto, FunctionBody body = null)
            : base(proto)
        {
            this._body = body ?? new FunctionBody((context, arguments) => JavaScriptRuntime.undefined);
        }

        public Function(FunctionBody body = null, Object prototype = null)
            : this(Function.Prototype, body)
        {
            if (prototype != null)
                this.prototype = prototype;
            else
            {
                this.prototype = new Object();
                this.prototype["constructor"] = this;
            }

        }

        public object call(Object thisBinding, params object[] arguments)
        {
            return _body(thisBinding, arguments);
        }

        public Object New(params object[] arguments)
        {
            var newObj = Object.create(prototype);
            call(newObj, arguments);
            return newObj;

        }
    }
}
