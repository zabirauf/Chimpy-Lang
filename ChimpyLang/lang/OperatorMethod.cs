using System;

namespace ChimpyLang
{
	public abstract class OperatorMethod<T>:Method
	{
		public override ChimpyObject Call(ChimpyObject receiver, ChimpyObject [] arguments)
		{
			T self=(T) (receiver as ValueObject).Value;
			T arg =(T) (arguments[0] as ValueObject).Value;
			return Perform(self,arg);
		}

		public abstract ChimpyObject Perform(T receiver,T argument);
	}
}

