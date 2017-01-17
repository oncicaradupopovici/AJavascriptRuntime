using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJavascriptRuntime
{
    public class Object
    {
        internal static Object Prototype = new Object(null);

        private Dictionary<string, object> _ownProperties = new Dictionary<string, object>();

        public Object __proto__ { get; private set; }


        protected Object(Object proto)
        {
            this.__proto__ = proto;
        }

        public Object()
            : this(Object.Prototype)
        {
        }

        public static Object create(Object proto)
        {
            var obj = new Object(proto);
            return obj;
        }

        public object this[string propName]
        {
            get
            {
                return _ownProperties.ContainsKey(propName) ? _ownProperties[propName] : __proto__ != null ? __proto__[propName] : JavaScriptRuntime.undefined;
            }
            set
            {
                _ownProperties[propName] = value;
            }
        }
    }
}
