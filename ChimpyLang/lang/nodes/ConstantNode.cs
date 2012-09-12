using System;

namespace ChimpyLang
{
	public class ConstantNode : Node
	{
		private string name;
		public ConstantNode (string name)
		{
			this.name=name;
		}

		public override ChimpyObject Eval(Context context)
		{
			return context.CurrentClass.GetConstant(name);
		}
	}
}

