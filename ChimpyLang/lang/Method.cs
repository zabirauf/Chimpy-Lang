using System;

namespace ChimpyLang
{
	public abstract class Method
	{
		/// <summary>
		/// Call the method.
		/// </summary>
		/// <param name='receiver'>
		/// Instance on which to call the method (self).
		/// </param>
		/// <param name='arguments'>
		/// Arguments passed to the method
		/// </param>
		public abstract ChimpyObject call(ChimpyObject receiver, ChimpyObject [] arguments);
	}
}

