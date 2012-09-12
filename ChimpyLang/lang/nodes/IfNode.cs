using System;

namespace ChimpyLang
{
	public class IfNode: Node
	{
		private Node condition;
		private Node ifBody;
		private Node elseBody;

		public IfNode (Node condition, Node ifBody, Node elseBody)
		{
			this.condition = condition;
			this.ifBody = ifBody;
			this.elseBody = elseBody;
		}

		public override ChimpyObject Eval(Context context)
		{
			if (condition.Eval(context).IsTrue())
			{
				return ifBody.Eval(context);
			}
			else if (elseBody != null)
			{
				return elseBody.Eval(context);
			}

			return ChimpyRuntime.Nil;
		}


	}
}

