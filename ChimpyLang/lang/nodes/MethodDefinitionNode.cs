using System;
using System.Collections.Generic;
namespace ChimpyLang
{
	public class MethodDefinitionNode : Node
	{
		private string name;
		private Node body;
		private List<string> parameters;

		public MethodDefinitionNode (string name, List<string> parameters, Node body)
		{
			this.name = name;
			this.parameters = parameters;
			this.body = body;
		}

		public override ChimpyObject Eval(Context context)
		{
			string [] parametersName;
			if(parameters == null)
			{
				parametersName = new string[0];
			}
			else
			{
				parametersName = parameters.ToArray();
			}

			context.CurrentClass.AddMethod(name,new InterpretedMethod(name,parametersName,body));
			return ChimpyRuntime.Nil;
		}
	}
}

