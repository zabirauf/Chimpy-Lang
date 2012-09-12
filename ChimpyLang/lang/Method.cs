using System;

namespace ChimpyLang
{
	public abstract class Method
	{
		public abstract ChimpyObject Call(ChimpyObject receiver, ChimpyObject [] arguments);
	}
}

