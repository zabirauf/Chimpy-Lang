using System;

namespace ChimpyLang
{
	public class InstanceVariableAssignNode : Node
	{
		private string name;
		private Node expression;

		public InstanceVariableAssignNode (string name,Node expression)
		{
			this.name = name;
			this.expression = expression;
		}

		public ChimpyObject Eval(Context context)
		{
			ChimpyObject value = expression.Eval(context);
			context.CurrentSelf.SetInstanceVariable(name,value);
			return value;
		}
	}
}

