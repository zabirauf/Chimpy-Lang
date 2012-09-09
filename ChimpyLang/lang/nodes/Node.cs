using System;

namespace ChimpyLang
{
	public abstract class Node : IEvaluable
	{
		public extern ChimpyObject Eval(Context context);
	}
}

