using System;

namespace ChimpyLang
{
	public class LocalAssignNode :Node
	{
		private string name;
		private Node expression;

		public LocalAssignNode (string name,Node expression)
		{
			this.name = name;
			this.expression = expression;
		}

		public ChimpyObject Eval(Context context)
		{
			ChimpyObject value = expression.Eval(context);
			context.SetLocal(name,value);
			return value;
		}
	}
}

