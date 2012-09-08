using System;

namespace ChimpyLang
{
	public class SelfNode : Node
	{
		public SelfNode ()
		{
		}

		public ChimpyObject Eval(Context context)
		{
			return context.CurrentSelf;
		}
	}
}

