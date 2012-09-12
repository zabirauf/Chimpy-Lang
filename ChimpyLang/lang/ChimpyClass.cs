using System;
using System.Collections.Generic;
namespace ChimpyLang
{
	/// <summary>
	///  Class in the runtime.
	///  Classes store methods and constants. Each object in the runtime has a class.
	/// </summary>
	public class ChimpyClass:ChimpyObject
	{
		private string name;
		private ChimpyClass superClass;
		private Dictionary<string,Method> methods;
		Dictionary<string,ChimpyObject> constants;

		/// <summary>
		/// Creates a class inheriting from superClass.
		/// </summary>
		public ChimpyClass (string name, ChimpyClass superClass) : base("Class")
		{
			this.name = name;
			this.superClass = superClass;
			methods = new Dictionary<string, Method>();
			constants = new Dictionary<string, ChimpyObject>();
		}

		/// <summary>
		/// Creates a class inheriting from Object.lass.
		/// </summary>
		/// <param name='name'>
		/// Name.
		/// </param>
        public ChimpyClass(string name)
            : this(name, ChimpyRuntime.ObjectClass)
		{
		    
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		public ChimpyClass SuperClass
		{
			get
			{
				return superClass;
			}
		}

		public void SetConstant(string name, ChimpyObject value)
		{
			constants.Add(name,value);
		}

		public ChimpyObject GetConstant(string name)
		{
			ChimpyObject value;
			if (constants.TryGetValue(name,out value)) return value;
			if (superClass != null) return superClass.GetConstant(name);
			return ChimpyRuntime.Nil;
		}

		public bool HasContant(string name)
		{
			if (constants.ContainsKey(name)) return true;
			if (superClass != null) return superClass.HasContant(name);
			return false;
		}

		public Method Lookup(string name)
		{
			Method value;
			if (methods.TryGetValue(name,out value)) return value;
			if (superClass != null) return superClass.Lookup(name);
			throw new MethodNotFound(name);
		}

		public bool HasMethod(string name)
		{
			if (methods.ContainsKey(name)) return true;
			if (superClass != null) return superClass.HasMethod(name);
			return false;
		}

		public void AddMethod(string name,Method method)
		{
			methods.Add(name,method);
		}

		/// <summary>
		/// Creates a new instance of the class.
		/// </summary>
		/// <returns>
		/// The instance.
		/// </returns>
		public ChimpyObject NewInstance()
		{
			return new ChimpyObject(this);
		}

		/// <summary>
		/// Creates a new instance of the class, storing the value inside a ValueObject.
		/// </summary>
		/// <returns>
		/// The instance.
		/// </returns>
		/// <param name='value'>
		/// Value.
		/// </param>
		public ChimpyObject NewInstance(Object value)
		{
			return new ValueObject(this,value);
		}

		/// <summary>
		/// Creates a new subclass of this class.
		/// </summary>
		/// <returns>
		/// The instance of subclass.
		/// </returns>
		/// <param name='name'>
		/// Name of subclass.
		/// </param>
		public ChimpyClass NewSubclass(string name)
		{
			ChimpyClass klass = new ChimpyClass(name,this);
			ChimpyRuntime.ObjectClass.SetConstant(name,klass);
			return klass;
		}

		/// <summary>
		/// Creates or returns a subclass if it already exists.
		/// </summary>
		/// <param name='name'>
		/// Name of the subclass
		/// </param>
		/// <returns>
		/// Returns the existing instance of subclass or a new sublcass
		/// </returns>
		public ChimpyClass Subclass(string name)
		{
			ChimpyClass objectClass = ChimpyRuntime.ObjectClass;
			if(objectClass.HasContant(name)) return (ChimpyClass)objectClass.GetConstant(name);
			return NewSubclass(name);
		}

		/// <summary>
		/// Determines whether this instance is subclass of the specified klass.
		/// </summary>
		/// <returns>
		/// <c>true</c> if this instance is subclass of the specified klass; otherwise, <c>false</c>.
		/// </returns>
		/// <param name='klass'>
		/// Class to check against
		/// </param>
		public bool IsSubclass(ChimpyClass klass)
		{
			if(klass == this) return true;
			if(klass.SuperClass == null) return false;
			if(klass.SuperClass == this) return true;
			return IsSubclass(klass.SuperClass);
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ChimpyLang.ChimpyClass"/>.
		/// </summary>
		/// <param name='other'>
		/// The <see cref="System.Object"/> to compare with the current <see cref="ChimpyLang.ChimpyClass"/>.
		/// </param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="ChimpyLang.ChimpyClass"/>; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object other)
		{
			if (other == this) return true;
			if ( !(other.GetType().IsAssignableFrom(this.GetType())) ) return false;
			return name == ((ChimpyClass)other).Name;
		}

	}
}

