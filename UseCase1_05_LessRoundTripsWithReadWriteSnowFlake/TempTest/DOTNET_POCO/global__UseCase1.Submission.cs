
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	[DataContract(Namespace="")] public partial class Submission : global::System.IEquatable<Submission>, global::System.ICloneable
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		[DataMember] public string URI { get; internal set; }
		
		public Submission()
			
		{
			
			this._ID = global::System.Guid.NewGuid();
			this._CustomerID = global::System.Guid.NewGuid();
			this._FormID = global::System.Guid.NewGuid();
			this._Date = DateTime.UtcNow;
			
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

		
		
		internal global::UseCase1.Customer _Customer;

		public global::UseCase1.Customer Customer
		{
			
			get 
			{
				
				
				if (_CustomerURI == null && _Customer != null)
					_Customer = null;
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

	}

}
