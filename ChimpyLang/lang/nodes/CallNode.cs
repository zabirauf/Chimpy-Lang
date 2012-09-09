using System;
using System.Collections.Generic;

namespace ChimpyLang
{
	public class CallNode : Node
	{
		private Node receiver;
		private string method;
		private List<Node> arguments;

		public CallNode (string method, Node receiver, List<Node> arguments)
		{
			this.method = method;
			this.receiver = receiver;
			this.arguments = arguments;
		}

        public CallNode(string method, Node receiver, Node argument)
            : this(method,receiver,new List<Node>())
		{
			this.arguments.Add(argument);
		}

        public CallNode(string method, List<Node> arguments)
            : this(method, null, arguments)
		{
			
		}

        public CallNode(string method)
            : this(method, null)
		{
			
		}

		public Node Receiver
		{
			set
			{
				this.receiver = value;
			}
		}

		public ChimpyObject Eval(Context context)
		{
			if(receiver == null && arguments == null && context.HasLocal(method))
			{
				return context.GetLocal(method);
			}

			ChimpyObject evaledReceiver;
			if(receiver == null)
			{
				evaledReceiver = context.CurrentSelf;
			}
			else
			{
				evaledReceiver = receiver.Eval(context);
			}

			List<ChimpyObject> evaledArguments = new List<ChimpyObject>();
			if(arguments != null)
			{
				foreach(Node arg in arguments)
				{
					evaledArguments.Add(arg.Eval(context));
				}
			}

			return evaledReceiver.Call(method,evaledArguments.ToArray());
		}
	}
}

