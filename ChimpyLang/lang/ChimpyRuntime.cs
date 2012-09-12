using System;

namespace ChimpyLang
{
	/// <summary>
	/// Language runtime. Mostly helper methods for retrieving global values.
	/// </summary>
	public class ChimpyRuntime
	{
		private static ChimpyClass objectClass;
		private static ChimpyObject mainObject;
		private static ChimpyObject nilObject;
		private static ChimpyObject trueObject;
		private static ChimpyObject falseObject;


		public static ChimpyClass ObjectClass
		{
			get
			{
				return objectClass;
			}
			set
			{
				objectClass = value;
			}
		}

		public static ChimpyObject MainObject
		{
			get
			{
				return mainObject;
			}

			set
			{
				mainObject = value ;
			}
		}

		public static ChimpyObject Nil
		{
			get
			{
				return nilObject;
			}

			set
			{
				nilObject = value;
			}
		}

		public static ChimpyObject True
		{
			get
			{
				return trueObject;
			}

			set
			{
				trueObject = value;
			}
		}

		public static ChimpyObject False
		{
			get
			{
				return falseObject;
			}

			set 
			{
				falseObject = value;
			}
		}

		public static ChimpyClass GetRootClass(string name)
		{
			return objectClass == null ? null : (ChimpyClass) objectClass.GetConstant(name);
		}

		public static ChimpyClass GetExceptionClass()
		{
			return GetRootClass("Exception");
		}

		public static ChimpyObject ToBoolean(bool value)
		{
			return value ? ChimpyRuntime.True : ChimpyRuntime.False;
		}


	}
}

