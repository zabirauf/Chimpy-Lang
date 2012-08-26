using System;

namespace ChimpyLang
{
	public class MethodNotFound:ChimpyException
	{
		public MethodNotFound (string method):base(method+" not found")
		{
			SetRuntimeClass("MethodNotFound");
		}
	}
}

