using System;

namespace ChimpyLang
{
	public class NotNode:Node
	{
		private Node receiver;

		public NotNode (Node receiver)
		{
			this.receiver = receiver;
		}

		public ChimpyObject Eval(Context context)
		{
			if(receiver.Eval(context).IsTrue())
				return ChimpyRuntime.False;
			return ChimpyRuntime.True;

		}
	}
}

