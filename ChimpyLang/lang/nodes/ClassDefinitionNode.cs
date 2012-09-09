using System;

namespace ChimpyLang
{
	public class ClassDefinitionNode : Node
	{
		private string name;
		private string superName;
		private Node body;

		public ClassDefinitionNode (string name, string superName,Node body)
		{
			this.name = name;
			this.superName = superName;
			this.body = body;
		}

		public ChimpyObject Eval(Context context)
		{
			ChimpyClass klass;
			if(superName == null)
			{
				klass = new ChimpyClass(name);
			}
			else
			{
				ChimpyClass superClass = (ChimpyClass) context.CurrentClass.GetConstant(superName);
				klass = new ChimpyClass(name,superClass);
			}

			body.Eval(new Context(klass,klass));
			context.CurrentClass.SetConstant(name,klass);

			return klass;
		}
	}
}

