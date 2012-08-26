using System;

namespace ChimpyLang
{
	public class InterpretedMethod:Method
	{
		private string name;
		private IEvaluable body;
		private string[] parameters;

		public InterpretedMethod (string name, string [] parameters,IEvaluable body)
		{
			this.name=name;
			this.parameters=parameters;
			this.body=body;
		}

		public override ChimpyObject Call(ChimpyObject receiver, ChimpyObject [] arguments)
		{
			Context context = new Context(receiver);
			if(parameters.Length != arguments.Length)
				throw new ArgumentError(name,parameters.Length,arguments.Length);
			for (int i=0;i<parameters.Length;i++)
			{
				context.SetLocal(parameters[i],arguments[i]);
			}
		}

	}
}

