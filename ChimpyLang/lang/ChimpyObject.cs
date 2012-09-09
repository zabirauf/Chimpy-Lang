using System;
using System.Collections.Generic;
using Antlr.Runtime;
namespace ChimpyLang
{
	public class ChimpyObject
	{
		private ChimpyClass _chimpyClass;
		private Dictionary<string,ChimpyObject> _instanceVariables;
	 	
		public ChimpyObject (ChimpyClass chimpyClass)
		{
			this._chimpyClass=chimpyClass;
			this._instanceVariables=new Dictionary<string,ChimpyObject>();
		}

        public ChimpyObject(string className)
            : this(ChimpyRuntime.GetRootClass(className))
		{
			
		}

		public ChimpyObject()
            :this(ChimpyRuntime.ObjectClass)
		{
			

		}


		//TODO: Check if same name can occur, i doubt it
		public ChimpyClass chimpyClass
		{
			get{
				return _chimpyClass;
			}
			set{
				_chimpyClass=value;
			}
		}

		public ChimpyObject GetInstanceVariables(string name)
		{
			ChimpyObject value;
			if(_instanceVariables.TryGetValue(name,out value))
			{
				return value;
			}

			return ChimpyRuntime.Nil;
		}

		public bool HasInstanceVariable(string name)
		{
			return _instanceVariables.ContainsKey(name);
		}

		public void SetInstanceVariable(string name, ChimpyObject value)
		{
			_instanceVariables.Add(name,value);

		}

		///<summary>
		/// Call a method on the object
		/// </summary>

		//TODO: throws ChimpyException
		public ChimpyObject Call(string method,ChimpyObject []arguments) 
		{
			return chimpyClass.Lookup(method).Call(this,arguments);
		}

		//TODO: throws ChimpyException
		public ChimpyObject Call(string method)
		{
			return Call (method,new ChimpyObject[0]);
		}

		public virtual bool IsTrue()
		{
			return !IsFalse();
		}

		public virtual bool IsFalse()
		{
			return false;
		}

		public virtual bool IsNil()
		{
			return false;
		}

		public virtual Object ToJavaObject()
		{
			return this;

		}

		public string AsString()
		{
			string value= this as string;
			if(value == null)
				throw new TypeError("string",this);

			return value;
		}

		public Int32? AsInteger()
		{
			Int32? value = this as Int32?;
			if(value == null)
				throw new TypeError("Int32",this);
			return value;
		}

		public float? AsFloat()
		{
			float? value = this as float?;
			if(value == null)
				throw new TypeError("float",this);
			return value;
		}

	}
}

