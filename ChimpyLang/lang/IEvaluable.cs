using System;

namespace ChimpyLang
{
	public interface IEvaluable
	{
		ChimpyObject Eval(Context context);
	}
}

