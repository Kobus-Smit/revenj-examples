
namespace FormABC
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	[DataContract(Namespace="")] public partial class Output : global::System.IEquatable<Output>, global::System.ICloneable
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		[DataMember] public string URI { get; internal set; }
		
		public Output()
			
		{
			
			this._ID = global::System.Guid.NewGuid();
			this._SubmissionID = global::System.Guid.NewGuid();
			
			this.URI = _ID.ToString();
		}

		
		private bool __EqualEntity(Output other)
		{
			return other != null 
				
				&& other.ID == this.ID
			;
		}

		public override int GetHashCode()
		{
			return this.URI != null ? this.URI.GetHashCode() : base.GetHashCode();
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

		public Output Clone()
		{
			return new Output(this);
		}
		//TODO let's leave it out for now
		//public override bool Equals(object other) { return Equals(other as Output); }
		public bool Equals(Output other)
		{
			return other != null
				&& other.URI == this.URI
				
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

		
		
		internal global::UseCase1.Submission _Submission;

		public global::UseCase1.Submission Submission
		{
			
			get 
			{
				
				
				if (_SubmissionURI == null && _Submission != null)
					_Submission = null;
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

	}

}
