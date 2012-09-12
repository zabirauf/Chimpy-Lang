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

		public ValueObject(Int32? value):base("Integer")
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

        public string GetAsString()
        {
            string value = this.value as string;
            if (value == null)
                throw new TypeError("string", this.value);
            return value;
        }

        public Int32? GetAsInt()
        {
            Int32? value = this.value as Int32?;
            if (value == null)
                throw new TypeError("int", this.value);
            return value;
        }

        public float? GetAsFloat()
        {
            float? value = this.value as float?;
            if (value == null)
                throw new TypeError("float", this.value);
            return value;
        }
	}
}

