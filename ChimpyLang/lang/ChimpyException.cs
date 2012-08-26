using System;

namespace ChimpyLang
{
	public class ChimpyException:Exception
	{

		private ChimpyClass runtimeClass;

		public ChimpyException (ChimpyClass runtimeClass,string message):base(message)
		{
			this.runtimeClass=runtimeClass;
		}

		public ChimpyException(ChimpyClass runtimeClass):base()
		{
			this.runtimeClass = runtimeClass;
		}

		public ChimpyException(string runtimeClassName,string message):base(message)
		{
			SetRuntimeClass(runtimeClassName);
		}

		public ChimpyException(string message):base(message)
		{
			this.runtimeClass = ChimpyRuntime.GetExceptionClass();
		}

		public ChimpyException(Exception inner):base("",inner)
		{
			SetRuntimeClass(inner.GetType().ToString());
		}

		public ChimpyObject GetRuntimeObject()
		{
			ChimpyObject instance=runtimeClass.NewInstance(this);
			instance.SetInstanceVariable("message",new ValueObject(this.Message));
			return instance;
		}

		public ChimpyClass RuntimeClass
		{
			get
			{
				return runtimeClass;
			}
		}

		protected void SetRuntimeClass(string name)
		{
			runtimeClass = ChimpyRuntime.GetExceptionClass().Subclass(name);
		}
	}
}

