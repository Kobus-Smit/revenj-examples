
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


	
	
	
	[DataContract(Namespace="")] public partial class Submission : global::System.IEquatable<Submission>, global::System.ICloneable, global::Revenj.DomainPatterns.IAggregateRoot
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		[DataMember] public string URI { get; internal set; }
		internal IServiceProvider __locator;
		
		public Submission()
			
		{
			
			this.URI = base.GetHashCode().ToString();
			this._ID = global::System.Guid.NewGuid();
			this._CustomerID = global::System.Guid.NewGuid();
			this._FormID = global::System.Guid.NewGuid();
			this._Date = DateTime.Now;
			
			this.URI = _ID.ToString();
		}

		
		public global::UseCase1.Submission Clone()
		{
			return new Submission(this);
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
		bool IEquatable<Submission>.Equals(Submission other)
		{
			return other.URI == this.URI
				
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

		
		public static event Action<Submission> Validating = a => { };
		public void Validate()
		{
			Validating(this);
		}
		
		public static global::UseCase1.Submission Find(string uri, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.Submission>(uri).Result; 
		}
		public static global::UseCase1.Submission[] Find(IEnumerable<string> uris, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.Submission>(uris).Result;
		}
		public static global::UseCase1.Submission[] FindAll(int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().FindAll<global::UseCase1.Submission>(limit, offset).Result;
		}
		public static global::UseCase1.Submission[] Search(ISpecification<global::UseCase1.Submission> specification, int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(specification, limit, offset, null).Result;
		}
		
		internal void UpdateWithAnother(global::UseCase1.Submission result)
		{
			this.URI = result.URI;
			
			this.Customer = result.Customer;
			this._CustomerURI = result._CustomerURI;
			this.CustomerID = result.CustomerID;
			this.Form = result.Form;
			this._FormURI = result._FormURI;
			this.FormID = result.FormID;
			this.Comments = result.Comments;
			this.Date = result.Date;
			this.InputsBytes = result.InputsBytes;
			this.OutputBytes = result.OutputBytes;
			this.ID = result.ID;
		}
		public global::UseCase1.Submission Create(IServiceProvider locator = null)
		{
			var proxy = (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>();
			var result = proxy.Create(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			this.Date = result.Date;
			this.__locator = locator ?? Static.Locator;
			return this;
		}
		public global::UseCase1.Submission Update()
		{
			if (__locator == null) throw new ArgumentException("Can't update new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			var result = proxy.Update(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			this.Date = result.Date;
			return this;
		}
		public global::UseCase1.Submission Delete()
		{
			if (__locator == null) throw new ArgumentException("Can't delete new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			return proxy.Delete(this).Result;
		}
		
		
	    //TODO Kobus added the DataMember attribute
        [DataMember]
        internal global::UseCase1.Customer _Customer;

		public global::UseCase1.Customer Customer
		{
			
			get 
			{
				
				
				if (_CustomerURI == null && _Customer != null)
					_Customer = null;
				
				//TODO Consider doing this only if the LazyLoad property is true (default)
                if (__locator != null && _Customer != null && _Customer.URI != _CustomerURI || _Customer == null && _CustomerURI != null)
					_Customer = __locator.Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.Customer>(_CustomerURI).Result;
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
		
		
		[DataMember(Name="CustomerID")]
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

		
		
		internal global::UseCase1.Form _Form;

		public global::UseCase1.Form Form
		{
			
			get 
			{
				
				
				if (_FormURI == null && _Form != null)
					_Form = null;
				
				if (__locator != null && _Form != null && _Form.URI != _FormURI || _Form == null && _FormURI != null)
					_Form = __locator.Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.Form>(_FormURI).Result;
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
		
		
		[DataMember(Name="FormID")]
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

		
		
		[DataMember(Name="Comments")]
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

		
		
		[DataMember(Name="Date")]
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

		
		
		[DataMember(Name="InputsBytes")]
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

		
		
		[DataMember(Name="OutputBytes")]
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

		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as IServiceProvider;
			if (locator == null) return;
			__locator = locator;
		}

	}

}
