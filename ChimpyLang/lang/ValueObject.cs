using System;

namespace ChimpyLang
{
	public class ValueObject:ChimpyObject
	{
		private Object value;

		public ValueObject (ChimpyClass klass,Object value):base(klass)
		{
			this.value=value;
		}

		public ValueObject(string value):base("String")
		{
			this.value=value;
		}

		public ValueObject(int? value):base("Integer")
		{
			this.value=value;
		}

		public ValueObject(float? value):base("Float")
		{
			this.value=value;
		}

		public ValueObject(Object value):base("Object")
		{
			this.value=value;
		}

		public override Object ToJavaObject()
		{
			return value;
		}

		public override bool IsFalse()
		{
			return value == (Object) false || IsNil ();
		}

		public override bool IsNil()
		{
			return value == null;
		}

		public Object Value
		{
			get
			{
				return value;
			}
		}

		//TODO: Have to implement GetValueAs
	}
}

