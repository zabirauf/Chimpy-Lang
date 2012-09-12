using System;

namespace ChimpyLang
{
	public delegate ChimpyObject OperatorMethodCall<T>(T recevier,T argument);

	public class OperatorMethod<T>:Method
	{
		OperatorMethodCall<T> operatorMethodCall;

		public OperatorMethod(OperatorMethodCall<T> operatorMethodCall)
		{
			this.operatorMethodCall = operatorMethodCall;
		}
		public override ChimpyObject Call(ChimpyObject receiver, ChimpyObject [] arguments)
		{

			T self=(T) (receiver as ValueObject).Value;
			T arg =(T) (arguments[0] as ValueObject).Value;


			return operatorMethodCall(self,arg);
			//return Perform(self,arg);

		}

		//public abstract ChimpyObject Perform(T receiver,T argument);
	}
}

