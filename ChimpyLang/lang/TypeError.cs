using System;

namespace ChimpyLang
{
	/// <summary>
	/// Exception raised when an unexpected object type is passed to as a method argument.
	/// </summary>
	public class TypeError:ChimpyException
	{
		public TypeError (string expected,Object actual):base("Expected type "+expected+", got "+ actual.GetType().ToString() )
		{
			SetRuntimeClass("TypeError");
		}
	}
}

