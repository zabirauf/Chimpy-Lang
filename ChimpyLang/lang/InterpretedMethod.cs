using System;

namespace ChimpyLang
{
	public delegate ChimpyObject MethodCall(ChimpyObject receiver, ChimpyObject [] arguments);

	public class InterpretedMethod:Method
	{
		private string name;
		private IEvaluable body;
		private string[] parameters;
		private MethodCall delegatedMethodCall;



		public InterpretedMethod (string name, string [] parameters,IEvaluable body)
		{
			this.name=name;
			this.parameters=parameters;
			this.body=body;
			this.delegatedMethodCall = null;
		}

		public InterpretedMethod(MethodCall delegatedMethodCall)
		{
			this.delegatedMethodCall = delegatedMethodCall;
		}

		public override ChimpyObject Call(ChimpyObject receiver, ChimpyObject [] arguments)
		{
			if(delegatedMethodCall != null)
				return delegatedMethodCall(receiver,arguments);

			Context context = new Context(receiver);
			if(parameters.Length != arguments.Length)
				throw new ArgumentError(name,parameters.Length,arguments.Length);
			for (int i=0;i<parameters.Length;i++)
			{
				context.SetLocal(parameters[i],arguments[i]);
			}

            return body.Eval(context);
		}

	}
}

