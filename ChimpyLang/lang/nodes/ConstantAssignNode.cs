using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChimpyLang
{
    class ConstantAssignNode : Node
    {
        private Node expression;
        private string name;

        public ConstantAssignNode(string name, Node expression)
        {
            this.expression = expression;
            this.name = name;
        }

        public ChimpyObject Eval(Context context)
        {
            ChimpyObject value = expression.Eval(context);
            context.CurrentClass.SetConstant(name, value);
            return value;
        }
    }
}
