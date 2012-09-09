using System;

namespace ChimpyLang
{
	public class InstanceVariableNode :Node
	{
		private string name;

		public InstanceVariableNode (string name)
		{
			this.name = name;
		}

		public ChimpyObject Eval(Context context)
		{
			return context.CurrentSelf.GetInstanceVariables(name);
		}
	}
}

