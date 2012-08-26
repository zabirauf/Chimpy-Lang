using System;

namespace ChimpyLang
{
	public class ExceptionHandler
	{
		private IEvaluable handler;
		private string localName;
		private ChimpyClass klass;

		public ExceptionHandler (ChimpyClass klass, string localName, IEvaluable handler)
		{
			this.localName=localName;
			this.klass=klass;
			this.handler=handler;
		}

		public bool Handle(ChimpyException e)
		{
			return klass.IsSubclass(e.RuntimeClass);
		}

		public ChimpyObject Run(Context context, ChimpyException e)
		{
			if(localName != null)
				context.SetLocal(localName, e.GetRuntimeObject());

			return handler.Eval(context);
		}
	}
}

