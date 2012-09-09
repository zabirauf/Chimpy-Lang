using System;
using System.Collections.Generic;

namespace ChimpyLang
{
	public class TryNode : Node
	{
		private Node body;
		private List<CatchBlock> catchBlocks;

		public TryNode (Node body)
		{
			this.body = body;
			catchBlocks = new List<CatchBlock>();
		}

		public void AddCatchBlock(string typeName,string localName, Node body)
		{
			catchBlocks.Add(new CatchBlock(typeName,localName,body));
		}

		public ChimpyObject Eval(Context context)
		{
			Context tryContext = context.MakeChildContext();

			try
			{
				return body.Eval(tryContext);
			}
			catch(ChimpyException exception)
			{
				foreach (CatchBlock block in catchBlocks)
				{
					ExceptionHandler handler = block.ToExceptionHandler();
					if(handler.Handle(exception)) return handler.Run(tryContext,exception);
				}

				throw exception;
			}
		}


		private class CatchBlock
		{
			private string typeName;
			private string localName;
			private Node body;

			public CatchBlock(string typeName, string localName, Node body)
			{
				this.typeName = typeName;
				this.localName = localName;
				this.body = body;
			}

			public ExceptionHandler ToExceptionHandler()
			{
				return new ExceptionHandler(ChimpyRuntime.GetRootClass(typeName),localName,body);
			}

		}
	}

}

