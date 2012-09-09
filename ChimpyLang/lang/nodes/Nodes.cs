using System;
using System.Collections.Generic;

namespace ChimpyLang
{
	public class Nodes : Node
	{
		private List<Node> nodes;
		public Nodes ()
		{
			nodes = new List<Node>();
		}

		public void Add(Node n)
		{
			nodes.Add(n);
		}

		public ChimpyObject Eval(Context context)
		{
			ChimpyObject lastEval = ChimpyRuntime.Nil;
			foreach(Node n in nodes)
			{
				lastEval = n.Eval(context);
			}

			return lastEval;
		}
	}
}

