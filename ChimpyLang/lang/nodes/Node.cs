using System;

namespace ChimpyLang
{
	public abstract class Node : IEvaluable
	{
		public abstract ChimpyObject Eval(Context context);
	}
}

