using AJavascriptRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class AJavascriptRuntimeTests
    {
        [Fact]
        public void test_the_prototype_map()
        {
            //Arrange

            var jsr = new JavaScriptRuntime();
            var window = jsr.GlobalScope;

            var Object = window.Object;
            var Function = window.Function;



            //Act

            /*
             //JavaScript: paste this in a console
             var MyFunc = new Function();
             var myObj = new MyFunc();
             var MyDerivedFunc = new Function();
             MyDerivedFunc.prototype = Object.create(MyFunc.prototype);
             MyDerivedFunc.prototype["constructor"] = MyDerivedFunc;
             var myDerivedObject = new MyDerivedFunc();
             */


            var MyFunc = new Function();
            var myObj = MyFunc.New();
            var MyDerivedFunc = new Function();
            MyDerivedFunc.prototype = AJavascriptRuntime.Object.create(MyFunc.prototype);
            MyDerivedFunc.prototype["constructor"] = MyDerivedFunc;
            var myDerivedObject = MyDerivedFunc.New();



            //Assert

            /*
             //JavaScript: paste this in a console; all statements should be true
             Object.prototype === Object.__proto__.__proto__ &&
             Function.__proto__ === Object.__proto__ &&
             Function.__proto__ === Function.prototype &&
             Function.prototype.__proto__ === Object.prototype &&
             MyFunc.__proto__ === Object.__proto__ &&
             MyFunc.__proto__ === Function.__proto__ &&
             myObj.__proto__ === MyFunc.prototype &&
             myObj.__proto__.__proto__ == Object.prototype &&
             MyFunc.prototype["constructor"] === MyFunc &&
             myObj["constructor"] === MyFunc &&
             myDerivedObject.__proto__ === MyDerivedFunc.prototype &&
             myDerivedObject.__proto__.__proto__ === MyFunc.prototype &&
             myDerivedObject.__proto__.__proto__.__proto__ === Object.prototype &&
             myDerivedObject["constructor"] == MyDerivedFunc
             */


            Assert.True(Object.prototype == Object.__proto__.__proto__);
            Assert.True(Function.__proto__ == Object.__proto__);
            Assert.True(Function.__proto__ == Function.prototype);
            Assert.True(Function.prototype.__proto__ == Object.prototype);
            Assert.True(MyFunc.__proto__ == Object.__proto__);
            Assert.True(MyFunc.__proto__ == Function.__proto__);
            Assert.True(myObj.__proto__ == MyFunc.prototype);
            Assert.True(myObj.__proto__.__proto__ == Object.prototype);
            Assert.True(MyFunc.prototype["constructor"] == MyFunc); 
            Assert.True(myObj["constructor"] == MyFunc);
            Assert.True(myDerivedObject.__proto__ == MyDerivedFunc.prototype);
            Assert.True(myDerivedObject.__proto__.__proto__ == MyFunc.prototype);
            Assert.True(myDerivedObject.__proto__.__proto__.__proto__ == Object.prototype);
            Assert.True(myDerivedObject["constructor"] == MyDerivedFunc);

        }

    }
}
