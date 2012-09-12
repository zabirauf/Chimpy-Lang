using System;

namespace ChimpyLang
{
	public class OrNode : Node
	{

		private Node receiver;
		private Node argument;

		public OrNode (Node receiver, Node argument)
		{
			this.receiver = receiver;
			this.argument = argument;
		}

		public override ChimpyObject Eval(Context context)
		{
			ChimpyObject receiverEvaled = receiver.Eval(context);
			if(receiverEvaled.IsTrue())
				return receiverEvaled;
			return argument.Eval(context);
		}
	}
}

