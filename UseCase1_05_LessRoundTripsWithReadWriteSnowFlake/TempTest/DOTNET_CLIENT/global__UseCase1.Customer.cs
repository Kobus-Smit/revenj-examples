
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	
	
	using Revenj.DomainPatterns;
	using Revenj;


	
	
	
	[DataContract(Namespace="")] public partial class Customer : global::System.IEquatable<Customer>, global::System.ICloneable, global::Revenj.DomainPatterns.IAggregateRoot
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		[DataMember] public string URI { get; internal set; }
		internal IServiceProvider __locator;
		
		public Customer()
			
		{
			
			this.URI = base.GetHashCode().ToString();
			this._ID = global::System.Guid.NewGuid();
			this._Submissions = new global::UseCase1.Submission[] { };
			
			this.URI = _ID.ToString();
		}

		
		public global::UseCase1.Customer Clone()
		{
			return new Customer(this);
		}
		private Customer(Customer other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._Name = other._Name;
			this._RegistrationNumber = other._RegistrationNumber;
			this._SubmissionsURI = other.SubmissionsURI;
		}
		bool IEquatable<Customer>.Equals(Customer other)
		{
			return other.URI == this.URI
				
				&& other.ID == this.ID
				&& other.Name == this.Name
				&& other.RegistrationNumber == this.RegistrationNumber
				&& (this.SubmissionsURI == other.SubmissionsURI || this.SubmissionsURI != null && this.SubmissionsURI.SequenceEqual(other.SubmissionsURI))
			;
		}
		
		internal void __ReapplyReferences()
		{
			
		}
		object ICloneable.Clone() { return Clone(); }
		
		
		[DataMember(Name="ID")]
		internal global::System.Guid _ID;

		public global::System.Guid ID
		{
			
			get 
			{
				
				return this._ID; 
			}
			internal
			set 
			{
				
				this._ID = value; 
				
			}
		}

		
		public static event Action<Customer> Validating = a => { };
		public void Validate()
		{
			Validating(this);
		}
		
		public static global::UseCase1.Customer Find(string uri, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.Customer>(uri).Result; 
		}
		public static global::UseCase1.Customer[] Find(IEnumerable<string> uris, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.Customer>(uris).Result;
		}
		public static global::UseCase1.Customer[] FindAll(int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().FindAll<global::UseCase1.Customer>(limit, offset).Result;
		}
		public static global::UseCase1.Customer[] Search(ISpecification<global::UseCase1.Customer> specification, int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(specification, limit, offset, null).Result;
		}
		
		internal void UpdateWithAnother(global::UseCase1.Customer result)
		{
			this.URI = result.URI;
			
			this.Name = result.Name;
			this.RegistrationNumber = result.RegistrationNumber;
			this.Submissions = result.Submissions;
			this._SubmissionsURI = result._SubmissionsURI;
			this.ID = result.ID;
		}
		public global::UseCase1.Customer Create(IServiceProvider locator = null)
		{
			var proxy = (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>();
			var result = proxy.Create(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			this.__locator = locator ?? Static.Locator;
			return this;
		}
		public global::UseCase1.Customer Update()
		{
			if (__locator == null) throw new ArgumentException("Can't update new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			var result = proxy.Update(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			return this;
		}
		public global::UseCase1.Customer Delete()
		{
			if (__locator == null) throw new ArgumentException("Can't delete new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			return proxy.Delete(this).Result;
		}
		
		
		[DataMember(Name="Name")]
		internal string _Name = string.Empty;

		public string Name
		{
			
			get 
			{
				
				return this._Name; 
			}
			
			set 
			{
				
				this._Name = value; 
				
			}
		}

		
		
		[DataMember(Name="RegistrationNumber")]
		internal int _RegistrationNumber;

		public int RegistrationNumber
		{
			
			get 
			{
				
				return this._RegistrationNumber; 
			}
			
			set 
			{
				
				this._RegistrationNumber = value; 
				
			}
		}

		
		internal string[] _SubmissionsURI;
		[DataMember]
		public string[] SubmissionsURI 
		{ 
			get 
			{
				if(_Submissions != null)
					return _Submissions.Select(it => it.URI).ToArray();
				return (_SubmissionsURI ?? new string[0]).ToArray();
			}
			private set {  _SubmissionsURI = value ?? new string[0]; } //TODO: doesn't work on field correctly ;(
		}
		
		
		internal global::UseCase1.Submission[] _Submissions;

		public global::UseCase1.Submission[] Submissions
		{
			
			get 
			{
				
				
				if(_Submissions == null)
					_Submissions = new global::UseCase1.Submission[] { };
				
				if (__locator != null && _SubmissionsURI != null)
				{
					_Submissions = (__locator.Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.Submission>(_SubmissionsURI).Result);
					_SubmissionsURI = null;
				}
				return this._Submissions; 
			}
			private
			set 
			{
				
				
				if(value == null) 
					value = new global::UseCase1.Submission[] { };
				
				if(value != null)
				{
					var __elIndx = 0;
					foreach(var it in value)
					{
						if(it == null)
							throw new ArgumentException(string.Format("Null element found at index {0} in property \"Submissions\" in object \"UseCase1.Customer\". Collection elements can't be null.", __elIndx));
						__elIndx++;
					}
				}
				this._Submissions = value; 
				
				_SubmissionsURI = null;
			}
		}

		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as IServiceProvider;
			if (locator == null) return;
			__locator = locator;
		}

	}

}
