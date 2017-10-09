
namespace FormABC
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


	
	
	
	[DataContract(Namespace="")] public partial class Output : global::System.IEquatable<Output>, global::System.ICloneable, global::Revenj.DomainPatterns.IAggregateRoot
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		[DataMember] public string URI { get; internal set; }
		internal IServiceProvider __locator;
		
		public Output()
			
		{
			
			this.URI = base.GetHashCode().ToString();
			this._ID = global::System.Guid.NewGuid();
			this._SubmissionID = global::System.Guid.NewGuid();
			
			this.URI = _ID.ToString();
		}

		
		public global::FormABC.Output Clone()
		{
			return new Output(this);
		}
		private Output(Output other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._SubmissionURI = other._SubmissionURI; this._Submission = other._Submission;
			this._SubmissionID = other._SubmissionID;
			this._ABC = other._ABC;
			this._XYZ = other._XYZ;
			this._HasQQQ = other._HasQQQ;
		}
		bool IEquatable<Output>.Equals(Output other)
		{
			return other.URI == this.URI
				
				&& other.ID == this.ID
				&& this._SubmissionURI == other._SubmissionURI
				&& other.SubmissionID == this.SubmissionID
				&& other.ABC == this.ABC
				&& other.XYZ == this.XYZ
				&& other.HasQQQ == this.HasQQQ
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

		
		public static event Action<Output> Validating = a => { };
		public void Validate()
		{
			Validating(this);
		}
		
		public static global::FormABC.Output Find(string uri, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>().Read<global::FormABC.Output>(uri).Result; 
		}
		public static global::FormABC.Output[] Find(IEnumerable<string> uris, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Find<global::FormABC.Output>(uris).Result;
		}
		public static global::FormABC.Output[] FindAll(int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().FindAll<global::FormABC.Output>(limit, offset).Result;
		}
		public static global::FormABC.Output[] Search(ISpecification<global::FormABC.Output> specification, int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(specification, limit, offset, null).Result;
		}
		
		internal void UpdateWithAnother(global::FormABC.Output result)
		{
			this.URI = result.URI;
			
			this.Submission = result.Submission;
			this._SubmissionURI = result._SubmissionURI;
			this.SubmissionID = result.SubmissionID;
			this.ABC = result.ABC;
			this.XYZ = result.XYZ;
			this.HasQQQ = result.HasQQQ;
			this.ID = result.ID;
		}
		public global::FormABC.Output Create(IServiceProvider locator = null)
		{
			var proxy = (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>();
			var result = proxy.Create(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			this.__locator = locator ?? Static.Locator;
			return this;
		}
		public global::FormABC.Output Update()
		{
			if (__locator == null) throw new ArgumentException("Can't update new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			var result = proxy.Update(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			return this;
		}
		public global::FormABC.Output Delete()
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

		
		
		[DataMember(Name="ABC")]
		internal decimal _ABC;

		public decimal ABC
		{
			
			get 
			{
				
				return this._ABC; 
			}
			
			set 
			{
				
				this._ABC = value; 
				
			}
		}

		
		
		[DataMember(Name="XYZ")]
		internal decimal _XYZ;

		public decimal XYZ
		{
			
			get 
			{
				
				return this._XYZ; 
			}
			
			set 
			{
				
				this._XYZ = value; 
				
			}
		}

		
		
		[DataMember(Name="HasQQQ")]
		internal bool _HasQQQ;

		public bool HasQQQ
		{
			
			get 
			{
				
				return this._HasQQQ; 
			}
			
			set 
			{
				
				this._HasQQQ = value; 
				
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
