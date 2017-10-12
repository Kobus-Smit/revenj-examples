
namespace FormXYZ
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


	
	
	
	[DataContract(Namespace="")] public partial class Input : global::System.IEquatable<Input>, global::System.ICloneable, global::Revenj.DomainPatterns.IAggregateRoot
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		[DataMember] public string URI { get; internal set; }
		internal IServiceProvider __locator;
		
		public Input()
			
		{
			
			this.URI = base.GetHashCode().ToString();
			this._ID = global::System.Guid.NewGuid();
			this._SubmissionID = global::System.Guid.NewGuid();
			this._LastPurchase = DateTime.Now;
			
			this.URI = _ID.ToString();
		}

		
		public global::FormXYZ.Input Clone()
		{
			return new Input(this);
		}
		private Input(Input other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._SubmissionURI = other._SubmissionURI; this._Submission = other._Submission;
			this._SubmissionID = other._SubmissionID;
			this._LastPurchase = other._LastPurchase;
			this._JKhdk = other._JKhdk;
			this._Qjfs = other._Qjfs;
		}
		bool IEquatable<Input>.Equals(Input other)
		{
			return other.URI == this.URI
				
				&& other.ID == this.ID
				&& this._SubmissionURI == other._SubmissionURI
				&& other.SubmissionID == this.SubmissionID
				&& other.LastPurchase == this.LastPurchase
				&& other.JKhdk == this.JKhdk
				&& other.Qjfs == this.Qjfs
			;
		}
		
		internal void __ReapplyReferences()
		{
			if (_Submission != null && _Submission.URI != SubmissionURI) this.Submission = _Submission;
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

		
		public static event Action<Input> Validating = a => { };
		public void Validate()
		{
			Validating(this);
		}
		
		public static global::FormXYZ.Input Find(string uri, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>().Read<global::FormXYZ.Input>(uri).Result; 
		}
		public static global::FormXYZ.Input[] Find(IEnumerable<string> uris, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Find<global::FormXYZ.Input>(uris).Result;
		}
		public static global::FormXYZ.Input[] FindAll(int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().FindAll<global::FormXYZ.Input>(limit, offset).Result;
		}
		public static global::FormXYZ.Input[] Search(ISpecification<global::FormXYZ.Input> specification, int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(specification, limit, offset, null).Result;
		}
		
		internal void UpdateWithAnother(global::FormXYZ.Input result)
		{
			this.URI = result.URI;
			
			this.Submission = result.Submission;
			this._SubmissionURI = result._SubmissionURI;
			this.SubmissionID = result.SubmissionID;
			this.LastPurchase = result.LastPurchase;
			this.JKhdk = result.JKhdk;
			this.Qjfs = result.Qjfs;
			this.ID = result.ID;
		}
		public global::FormXYZ.Input Create(IServiceProvider locator = null)
		{
			var proxy = (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>();
			var result = proxy.Create(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			this.__locator = locator ?? Static.Locator;
			return this;
		}
		public global::FormXYZ.Input Update()
		{
			if (__locator == null) throw new ArgumentException("Can't update new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			var result = proxy.Update(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			return this;
		}
		public global::FormXYZ.Input Delete()
		{
			if (__locator == null) throw new ArgumentException("Can't delete new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			return proxy.Delete(this).Result;
		}
		
		
		internal global::UseCase1.Submission _Submission;

		public global::UseCase1.Submission Submission
		{
			
			get 
			{
				
				
				if (_SubmissionURI == null && _Submission != null)
					_Submission = null;
				
				if (__locator != null && _Submission != null && _Submission.URI != _SubmissionURI || _Submission == null && _SubmissionURI != null)
					_Submission = __locator.Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.Submission>(_SubmissionURI).Result;
				return this._Submission; 
			}
			
			set 
			{
				
				
				if(value == null) 
					throw new ArgumentNullException("Property Submission can't be null");
				this._Submission = value; 
				
				_SubmissionURI = value != null ? value.URI : null;
				
				if(value == null)
					throw new ArgumentException("Property SubmissionID doesn't allow null values");
				else if(SubmissionID != value.ID)
					SubmissionID = value.ID;
			}
		}

		
		internal string _SubmissionURI;
		[DataMember]
		public string SubmissionURI 
		{ 
			get 
			{ 
				if (_Submission != null) _SubmissionURI = _Submission.URI;
				return _SubmissionURI; 
			} 
			private set { _SubmissionURI = value; } //TODO: serialization ;(
		}
		
		
		[DataMember(Name="SubmissionID")]
		internal global::System.Guid _SubmissionID;

		public global::System.Guid SubmissionID
		{
			
			get 
			{
				
				if (_Submission != null) SubmissionID = _Submission.ID;
				return this._SubmissionID; 
			}
			internal
			set 
			{
				
				this._SubmissionID = value; 
				
			}
		}

		
		
		[DataMember(Name="LastPurchase")]
		internal DateTime _LastPurchase;

		public DateTime LastPurchase
		{
			
			get 
			{
				
				return this._LastPurchase; 
			}
			
			set 
			{
				
				this._LastPurchase = value; 
				
			}
		}

		
		
		[DataMember(Name="JKhdk")]
		internal string _JKhdk = string.Empty;

		public string JKhdk
		{
			
			get 
			{
				
				return this._JKhdk; 
			}
			
			set 
			{
				
				this._JKhdk = value; 
				
			}
		}

		
		
		[DataMember(Name="Qjfs")]
		internal int _Qjfs;

		public int Qjfs
		{
			
			get 
			{
				
				return this._Qjfs; 
			}
			
			set 
			{
				
				this._Qjfs = value; 
				
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
