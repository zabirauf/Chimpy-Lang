using System;

namespace ChimpyLang
{
	public class WhileNode:Node
	{
		private Node condition;
		private Node body;
		public WhileNode (Node condition, Node body)
		{
			this.condition = condition;
			this.body = body;
		}

		public ChimpyObject Eval(Context context)
		{
			while(condition.Eval(context).IsTrue())
			{
				body.Eval(context);
			}
			return ChimpyRuntime.Nil;
		}
	}
}

