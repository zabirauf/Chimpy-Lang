using System;
using System.Collections.Generic;
using System.IO;
namespace ChimpyLang
{
	/// <summary>
	/// Evaluation context. Determines how a node will be evaluated.
  	/// A context tracks local variables, self, and the current class under which
  	/// methods and constants will be added.
  	/// There are three different types of context:
  	/// 1) In the root of the script, self = main object, class = Object
  	/// 2) Inside a method body, self = instance of the class, class = method class
  	/// 3) Inside a class definition self = the class, class = the class
	/// </summary>
	public class Context
	{
		private ChimpyObject currentSelf;
		private ChimpyClass currentClass;
		private Dictionary<string,ChimpyObject> locals;
		/// <summary>
		/// A context can share local variables with a parent. For example, in the
  		/// try block.
		/// </summary>
		private Context parent;

		public Context (ChimpyObject currentSelf, ChimpyClass currentClass, Context parent)
		{
			this.currentClass=currentClass;
			this.currentSelf=currentSelf;
			this.parent=parent;

			if(parent == null)
			{
				locals=new Dictionary<string, ChimpyObject>();
			}
			else
			{
				locals=parent.locals;
			}
		}

        public Context(ChimpyObject currentSelf, ChimpyClass currentClass)
            : this(currentSelf, currentClass, null)
		{
			
		}

		public Context(ChimpyObject currentSelf)
            :this(currentSelf,currentSelf.chimpyClass)
		{
			
		}

        public Context()
            : this(ChimpyRuntime.MainObject)
		{
			
		}

		public ChimpyObject CurrentSelf
		{
			get
			{
				return this.currentSelf;
			}
		}

		public ChimpyClass CurrentClass
		{
			get
			{
				return this.currentClass;
			}
		}

		public ChimpyObject GetLocal(string name)
		{
			ChimpyObject value=null;
			locals.TryGetValue(name,out value);
			return value;
		}

		public bool HasLocal(string name)
		{
			return locals.ContainsKey(name);
		}

		public void SetLocal(string name,ChimpyObject value)
		{
			locals.Add(name,value);
		}

		public Context MakeChildContext()
		{
			return new Context(currentSelf,currentClass,this);
		}

		//TODO: Create the Eval when ANTLR has been integerated 2 Methods unimplemented
		public ChimpyObject Eval(TextReader reader)
		{
			try
			{
				ChimpyLexer lexer = new ChimpyLexer(new Antlr.Runtime.ANTLRReaderStream(reader) );
				ChimpyParser parser = new ChimpyParser(new Antlr.Runtime.CommonTokenStream(lexer));
				Node node = parser.parse();
				if(node == null) return ChimpyRuntime.Nil;
				return node.Eval(this);
			}
			catch (ChimpyException e)
			{
				throw e;
			}
			catch (Exception e)
			{
				throw new ChimpyException(e);
			}

		}



	}
}

