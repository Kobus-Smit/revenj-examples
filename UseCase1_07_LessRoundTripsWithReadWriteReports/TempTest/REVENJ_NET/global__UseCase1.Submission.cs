
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
	[DataContract(Namespace="")] public partial class Submission : global::System.IEquatable<Submission>, global::System.ICloneable, global::Revenj.DomainPatterns.IEntity, global::Revenj.DomainPatterns.ICacheable, global::Revenj.DomainPatterns.IAggregateRoot, global::Revenj.DomainPatterns.IChangeTracking<Submission>
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		internal void __InternalPrepareInsert()
		{
			
			ID = global::System.Guid.NewGuid();
			_Date = new DateTime((_Date.Ticks / 10) * 10, _Date.Kind != DateTimeKind.Utc ? DateTimeKind.Local : DateTimeKind.Utc).ToLocalTime();
			_Date = DateTime.Now;
		}
		internal void __InternalPrepareUpdate()
		{
			
			_Date = new DateTime((_Date.Ticks / 10) * 10, _Date.Kind != DateTimeKind.Utc ? DateTimeKind.Local : DateTimeKind.Utc).ToLocalTime();
			_Date = DateTime.Now;
		}
		internal void __InternalPrepareDelete()
		{
			
		}
		
		internal long _InternalGetSizeApproximation()
		{
			long size = 45; 
			size += this.InputsBytes != null ? this.InputsBytes.Length : 0;
			size += this.OutputBytes != null ? this.OutputBytes.Length : 0;
			return size;
		}
		[DataMember] public string URI { get; internal set; }
		
		public Submission()
			
		{
			
			this._ID = global::System.Guid.NewGuid();
			this._CustomerID = global::System.Guid.NewGuid();
			this._FormID = global::System.Guid.NewGuid();
			this._Date = DateTime.Now;
			
			this.URI = _ID.ToString();
		}

		
		private bool __EqualEntity(Submission other)
		{
			return other != null 
				
				&& other.ID == this.ID
			;
		}

		public override int GetHashCode()
		{
			return this.URI != null ? this.URI.GetHashCode() : base.GetHashCode();
		}
		
		private Submission(Submission other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._CustomerURI = other._CustomerURI; this._Customer = other._Customer;
			this._CustomerID = other._CustomerID;
			this._FormURI = other._FormURI; this._Form = other._Form;
			this._FormID = other._FormID;
			this._Comments = other._Comments;
			this._Date = other._Date;
			this._InputsBytes = other._InputsBytes != null ? other._InputsBytes.ToArray() : null;
			this._OutputBytes = other._OutputBytes != null ? other._OutputBytes.ToArray() : null;
			
		}

		public Submission Clone()
		{
			return new Submission(this);
		}
		//TODO let's leave it out for now
		//public override bool Equals(object other) { return Equals(other as Submission); }
		public bool Equals(Submission other)
		{
			return other != null
				&& other.URI == this.URI
				
				&& other.ID == this.ID
				&& this._CustomerURI == other._CustomerURI
				&& other.CustomerID == this.CustomerID
				&& this._FormURI == other._FormURI
				&& other.FormID == this.FormID
				&& other.Comments == this.Comments
				&& other.Date == this.Date
				&& __NGSHelpers.CompareBinary(other.InputsBytes, this.InputsBytes)
				&& __NGSHelpers.CompareBinary(other.OutputBytes, this.OutputBytes)
			;
		}
		
		internal void __ReapplyReferences()
		{
			if (_Customer != null && _Customer.URI != CustomerURI) this.Customer = _Customer;if (_Form != null && _Form.URI != FormURI) this.Form = _Form;
		}
		object ICloneable.Clone() { return Clone(); }
		
		bool IEquatable<global::Revenj.DomainPatterns.IEntity>.Equals(global::Revenj.DomainPatterns.IEntity obj) 
		{ 
			return __EqualEntity(obj as Submission); 
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
				let it_Customer = it.CustomerURI
				where it_Customer != null
				select new KeyValuePair<System.Type, string>(typeof(global::UseCase1.Customer), it_Customer));
			result.AddRange(
				from it in new [] { this }
				let it_Form = it.FormURI
				where it_Form != null
				select new KeyValuePair<System.Type, string>(typeof(global::UseCase1.Form), it_Form));
			return result.GroupBy(it => it.Key).ToDictionary(it => it.Key, it => it.Select(e => e.Value));

		}

		internal Lazy<IDataCache<global::UseCase1.Customer>> __DataCacheCustomer;
		
		
	    //TODO Kobus added the DataMember attribute
        [DataMember]
        internal global::UseCase1.Customer _Customer;

		public global::UseCase1.Customer Customer
		{
			
			get 
			{
				
				
				if (_CustomerURI == null && _Customer != null)
					_Customer = null;
				
				if (_Customer != null && _Customer.URI != _CustomerURI || _Customer == null && _CustomerURI != null)
					if(__DataCacheCustomer != null)
						_Customer = __DataCacheCustomer.Value.Find(_CustomerURI);
				return this._Customer; 
			}
			
			set 
			{
				
				
				if(value == null) 
					throw new ArgumentNullException("Property Customer can't be null");
				this._Customer = value; 
				
				_CustomerURI = value != null ? value.URI : null;
				
				if(value == null)
					throw new ArgumentException("Property CustomerID doesn't allow null values");
				else if(CustomerID != value.ID)
					CustomerID = value.ID;
			}
		}

		
		internal string _CustomerURI;
		[DataMember]
		public string CustomerURI 
		{ 
			get 
			{ 
				if (_Customer != null) _CustomerURI = _Customer.URI;
				return _CustomerURI; 
			} 
			private set { _CustomerURI = value; } //TODO: serialization ;(
		}
		
		
		[DataMember(EmitDefaultValue=false,Name="CustomerID")]
		internal global::System.Guid _CustomerID;

		public global::System.Guid CustomerID
		{
			
			get 
			{
				
				if (_Customer != null) CustomerID = _Customer.ID;
				return this._CustomerID; 
			}
			internal
			set 
			{
				
				this._CustomerID = value; 
				
			}
		}

		internal Lazy<IDataCache<global::UseCase1.Form>> __DataCacheForm;
		
		
		internal global::UseCase1.Form _Form;

		public global::UseCase1.Form Form
		{
			
			get 
			{
				
				
				if (_FormURI == null && _Form != null)
					_Form = null;
				
				if (_Form != null && _Form.URI != _FormURI || _Form == null && _FormURI != null)
					if(__DataCacheForm != null)
						_Form = __DataCacheForm.Value.Find(_FormURI);
				return this._Form; 
			}
			
			set 
			{
				
				
				if(value == null) 
					throw new ArgumentNullException("Property Form can't be null");
				this._Form = value; 
				
				_FormURI = value != null ? value.URI : null;
				
				if(value == null)
					throw new ArgumentException("Property FormID doesn't allow null values");
				else if(FormID != value.ID)
					FormID = value.ID;
			}
		}

		
		internal string _FormURI;
		[DataMember]
		public string FormURI 
		{ 
			get 
			{ 
				if (_Form != null) _FormURI = _Form.URI;
				return _FormURI; 
			} 
			private set { _FormURI = value; } //TODO: serialization ;(
		}
		
		
		[DataMember(EmitDefaultValue=false,Name="FormID")]
		internal global::System.Guid _FormID;

		public global::System.Guid FormID
		{
			
			get 
			{
				
				if (_Form != null) FormID = _Form.ID;
				return this._FormID; 
			}
			internal
			set 
			{
				
				this._FormID = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="Comments")]
		internal string _Comments = string.Empty;

		public string Comments
		{
			
			get 
			{
				
				return this._Comments; 
			}
			
			set 
			{
				
				this._Comments = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="Date")]
		internal DateTime _Date;

		public DateTime Date
		{
			
			get 
			{
				
				return this._Date; 
			}
			internal
			set 
			{
				
				this._Date = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="InputsBytes")]
		internal byte[] _InputsBytes = __NGSHelpers.EmptyBinary;

		public byte[] InputsBytes
		{
			
			get 
			{
				
				return this._InputsBytes; 
			}
			
			set 
			{
				
				this._InputsBytes = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="OutputBytes")]
		internal byte[] _OutputBytes = __NGSHelpers.EmptyBinary;

		public byte[] OutputBytes
		{
			
			get 
			{
				
				return this._OutputBytes; 
			}
			
			set 
			{
				
				this._OutputBytes = value; 
				
			}
		}

		
		private Submission __OriginalValue;
		internal static bool __ChangeTrackingEnabled = true;
		private bool __TrackChanges = __ChangeTrackingEnabled;
		bool IChangeTracking<Submission>.TrackChanges 
		{ 
			get { return __TrackChanges; } 
			set { __TrackChanges = value; } 
		}
		internal void __ResetChangeTracking()
		{
			if(__TrackChanges)
				this.__OriginalValue = this.Clone();
		}
		Submission IChangeTracking<Submission>.GetOriginalValue()
		{
			return __OriginalValue;
		}
		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
			if(CustomerURI == null) throw new ArgumentException("In entity UseCase1.Submission, property Customer can't be null. CustomerURI provided as null");
			__DataCacheCustomer = new Lazy<IDataCache<global::UseCase1.Customer>>(() => locator.Resolve<IDataCache<global::UseCase1.Customer>>());
			if(FormURI == null) throw new ArgumentException("In entity UseCase1.Submission, property Form can't be null. FormURI provided as null");
			__DataCacheForm = new Lazy<IDataCache<global::UseCase1.Form>>(() => locator.Resolve<IDataCache<global::UseCase1.Form>>());
		}

		
		internal Submission(IServiceProvider locator)
			
		{
			
			__DataCacheCustomer = new Lazy<IDataCache<global::UseCase1.Customer>>(() => locator.Resolve<IDataCache<global::UseCase1.Customer>>());
			__DataCacheForm = new Lazy<IDataCache<global::UseCase1.Form>>(() => locator.Resolve<IDataCache<global::UseCase1.Form>>());
			
		}

	}

}
