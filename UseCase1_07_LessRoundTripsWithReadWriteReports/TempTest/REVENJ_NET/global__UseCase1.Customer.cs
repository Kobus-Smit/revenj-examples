
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	
	
	using global::Revenj;
	using global::Revenj.DomainPatterns;
	using global::Revenj.Extensibility;

	
	using global::Revenj;
	using global::Revenj.DomainPatterns;
	using global::Revenj.Extensibility;


	
	
	
	[Serializable]
	[DataContract(Namespace="")] public partial class Customer : global::System.IEquatable<Customer>, global::System.ICloneable, global::Revenj.DomainPatterns.IEntity, global::Revenj.DomainPatterns.ICacheable, global::Revenj.DomainPatterns.IAggregateRoot, global::Revenj.DomainPatterns.IChangeTracking<Customer>
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		internal void __InternalPrepareInsert()
		{
			
			ID = global::System.Guid.NewGuid();
		}
		internal void __InternalPrepareUpdate()
		{
			
		}
		internal void __InternalPrepareDelete()
		{
			
		}
		
		internal long _InternalGetSizeApproximation()
		{
			long size = 25; 
			return size;
		}
		[DataMember] public string URI { get; internal set; }
		
		public Customer()
			
		{
			
			this._ID = global::System.Guid.NewGuid();
			
			this.URI = _ID.ToString();
		}

		
		private bool __EqualEntity(Customer other)
		{
			return other != null 
				
				&& other.ID == this.ID
			;
		}

		public override int GetHashCode()
		{
			return this.URI != null ? this.URI.GetHashCode() : base.GetHashCode();
		}
		
		private Customer(Customer other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._Name = other._Name;
			this._Email = other._Email;
			this._RegistrationNumber = other._RegistrationNumber;
			this._SubmissionsURI = other.SubmissionsURI;
			
		}

		public Customer Clone()
		{
			return new Customer(this);
		}
		//TODO let's leave it out for now
		//public override bool Equals(object other) { return Equals(other as Customer); }
		public bool Equals(Customer other)
		{
			return other != null
				&& other.URI == this.URI
				
				&& other.ID == this.ID
				&& other.Name == this.Name
				&& other.Email == this.Email
				&& other.RegistrationNumber == this.RegistrationNumber
				&& (this.SubmissionsURI == other.SubmissionsURI || this.SubmissionsURI != null && this.SubmissionsURI.SequenceEqual(other.SubmissionsURI))
			;
		}
		
		internal void __ReapplyReferences()
		{
			
		}
		object ICloneable.Clone() { return Clone(); }
		
		bool IEquatable<global::Revenj.DomainPatterns.IEntity>.Equals(global::Revenj.DomainPatterns.IEntity obj) 
		{ 
			return __EqualEntity(obj as Customer); 
		}
		
		
		[DataMember(EmitDefaultValue=false,Name="ID")]
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

		
		
		Dictionary<System.Type, IEnumerable<string>> ICacheable.GetRelationships()
		{
			

			
			var result = new List<KeyValuePair<System.Type, string>>();

			result.AddRange(
				from it in new [] { this }
				from it_Submissions in it.SubmissionsURI
				where it_Submissions != null
				select new KeyValuePair<System.Type, string>(typeof(global::UseCase1.Submission), it_Submissions));
			return result.GroupBy(it => it.Key).ToDictionary(it => it.Key, it => it.Select(e => e.Value));

		}

		
		
		[DataMember(EmitDefaultValue=false,Name="Name")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Email")]
		internal string _Email = string.Empty;

		public string Email
		{
			
			get 
			{
				
				return this._Email; 
			}
			
			set 
			{
				
				this._Email = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="RegistrationNumber")]
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
		internal Lazy<IDataCache<global::UseCase1.Submission>> __DataCacheSubmissions;
		
		
		internal global::UseCase1.Submission[] _Submissions;

		public global::UseCase1.Submission[] Submissions
		{
			
			get 
			{
				
				
				if(_Submissions == null)
					_Submissions = new global::UseCase1.Submission[] { };
				
				if(_SubmissionsURI != null && _SubmissionsURI.Length == 0)
				{
					_Submissions = new global::UseCase1.Submission[] { };
					_SubmissionsURI = null;
				}
				
				if (_SubmissionsURI != null)
				{
					if(_SubmissionsURI.Length == 0)
						{ _Submissions = new global::UseCase1.Submission[] { }; _SubmissionsURI = null; }
					else if(__DataCacheSubmissions != null)
						{ _Submissions = __DataCacheSubmissions.Value.Find(_SubmissionsURI); _SubmissionsURI = null; }
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

		
		private Customer __OriginalValue;
		internal static bool __ChangeTrackingEnabled = true;
		private bool __TrackChanges = __ChangeTrackingEnabled;
		bool IChangeTracking<Customer>.TrackChanges 
		{ 
			get { return __TrackChanges; } 
			set { __TrackChanges = value; } 
		}
		internal void __ResetChangeTracking()
		{
			if(__TrackChanges)
				this.__OriginalValue = this.Clone();
		}
		Customer IChangeTracking<Customer>.GetOriginalValue()
		{
			return __OriginalValue;
		}
		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
			__DataCacheSubmissions = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
		}

		
		internal Customer(IServiceProvider locator)
			
		{
			
			__DataCacheSubmissions = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
			
		}

	}

}
