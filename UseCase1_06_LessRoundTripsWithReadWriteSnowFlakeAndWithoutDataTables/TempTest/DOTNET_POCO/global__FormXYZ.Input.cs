
namespace FormXYZ
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	[DataContract(Namespace="")] public partial class Input : global::System.IEquatable<Input>, global::System.ICloneable
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		[DataMember] public string URI { get; internal set; }
		
		public Input()
			
		{
			
			this._ID = global::System.Guid.NewGuid();
			this._SubmissionID = global::System.Guid.NewGuid();
			this._LastPurchase = DateTime.UtcNow;
			
			this.URI = _ID.ToString();
		}

		
		private bool __EqualEntity(Input other)
		{
			return other != null 
				
				&& other.ID == this.ID
			;
		}

		public override int GetHashCode()
		{
			return this.URI != null ? this.URI.GetHashCode() : base.GetHashCode();
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

		public Input Clone()
		{
			return new Input(this);
		}
		//TODO let's leave it out for now
		//public override bool Equals(object other) { return Equals(other as Input); }
		public bool Equals(Input other)
		{
			return other != null
				&& other.URI == this.URI
				
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

	}

}
