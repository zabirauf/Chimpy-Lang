using System;
using System.Collections.Generic;
using System.IO;

namespace ChimpyLang
{
	public class Bootstrapper
	{
		public class PrintMethod: Method
		{
			public override ChimpyObject Call(ChimpyObject receiver, ChimpyObject[] arguments)
			{
				foreach(ChimpyObject arg in arguments)
				{
					Console.WriteLine(arg.ToJavaObject());
				}

				return ChimpyRuntime.Nil;
			}
		}
		static public Context Run()
		{
			ChimpyClass objectClass = new ChimpyClass("Object");
			ChimpyRuntime.ObjectClass = objectClass;

			ChimpyObject main = new ChimpyObject();
			ChimpyRuntime.MainObject = main;
			ChimpyClass classClass = new ChimpyClass("Class");
			objectClass.chimpyClass = classClass;
			classClass.chimpyClass = classClass;
			main.chimpyClass = objectClass;

			objectClass.SetConstant("Object",objectClass);
			objectClass.SetConstant("Class",classClass);

			ChimpyRuntime.Nil = objectClass.NewSubclass("NilClass").NewInstance(null);
			ChimpyRuntime.True = objectClass.NewSubclass("TrueClass").NewInstance(true);
			ChimpyRuntime.False = objectClass.NewSubclass("FalseClass").NewInstance(false);

			ChimpyClass stringClass = objectClass.NewSubclass("String");
			ChimpyClass numberClass = objectClass.NewSubclass("Number");
			ChimpyClass integerClass = objectClass.NewSubclass("Integer");
			ChimpyClass floatClass = objectClass.NewSubclass("Float");
			ChimpyClass exceptionClass = objectClass.NewSubclass("Exception");

			exceptionClass.NewSubclass("IOException");
			exceptionClass.NewSubclass("TypeError");
			exceptionClass.NewSubclass("MethodNotFound");
			exceptionClass.NewSubclass("ArgumentError");
			exceptionClass.NewSubclass("FileNotFound");

			objectClass.AddMethod("print",new InterpretedMethod(delegate (ChimpyObject receiver, ChimpyObject[] arguments){
				foreach(ChimpyObject arg in arguments)
				{
					Console.WriteLine(arg.ToJavaObject());
				}

				return ChimpyRuntime.Nil;
			}));

			objectClass.AddMethod("class",new InterpretedMethod(delegate (ChimpyObject receiver, ChimpyObject[] arguments){
				return receiver.chimpyClass;
			}));

			objectClass.AddMethod("eval",new InterpretedMethod(delegate (ChimpyObject receiver, ChimpyObject[] arguments){
				Context context= new Context(receiver);
				StringReader code = new StringReader(arguments[0].AsString());
				return context.Eval(code);
			}));

			objectClass.AddMethod("require",new InterpretedMethod(delegate (ChimpyObject receiver, ChimpyObject[] arguments){
				Context context = new Context();
				string filename = arguments[0].AsString();

				try
				{
					return context.Eval(File.OpenText(filename));
				}
				catch (FileNotFoundException e)
				{
					throw new ChimpyException("FileNotFound","File not found "+filename);
				}
			}));



			classClass.AddMethod("new",new InterpretedMethod(delegate (ChimpyObject receiver, ChimpyObject[] arguments){
				ChimpyClass self = (ChimpyClass) receiver;
				ChimpyObject instance = self.NewInstance();
				if(self.HasMethod("initialize")) instance.Call("initialize",arguments);
				return instance;
			}));

			classClass.AddMethod("name",new InterpretedMethod(delegate (ChimpyObject receiver, ChimpyObject[] arguments){
				ChimpyClass self = (ChimpyClass) receiver;
				return new ValueObject(self.Name);
			}));

			classClass.AddMethod("superclass",new InterpretedMethod(delegate (ChimpyObject receiver, ChimpyObject[] arguments){
				ChimpyClass self = (ChimpyClass) receiver;
				return self.SuperClass;
			}));


			integerClass.AddMethod("+",new OperatorMethod<Int32>(delegate (Int32 receiver, Int32 argument){
				return new ValueObject((Int32)(receiver+argument));
			}));
			return new Context(main);
		}
	}
}

