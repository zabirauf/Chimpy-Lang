using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChimpyLang
{
    class ArgumentError : ChimpyException
    {

        public ArgumentError(string method, int expected, int actual)
            :base("Expected " + expected + " arguments for " + method + ", got " + actual)
        {
            this.SetRuntimeClass("ArgumentError");
        }
    }
}
