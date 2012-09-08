using System;

namespace ChimpyLang
{
	public class LiteralNode
	{
		ChimpyObject value;
		public LiteralNode (ChimpyObject value)
		{
			this.value = value;
		}

		public ChimpyObject Eval(Context context)
		{
			return value;
		}
	}
}

