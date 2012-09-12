using System;

namespace ChimpyLang
{
	public class AndNode:Node
	{
		private Node receiver;
		private Node argument;

		public AndNode (Node receiver, Node argument)
		{
			this.receiver = receiver;
			this.argument = argument;
		}

		public override ChimpyObject Eval(Context context)
		{
			ChimpyObject receiverEvaled = receiver.Eval(context);
			if(receiverEvaled.IsTrue())
				return argument.Eval(context);
			return receiverEvaled;
		}

	}
}

