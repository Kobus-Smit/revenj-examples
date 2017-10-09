
namespace FormABC
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
	[DataContract(Namespace="")] public partial class Input : global::System.IEquatable<Input>, global::System.ICloneable, global::Revenj.DomainPatterns.IEntity, global::Revenj.DomainPatterns.ICacheable, global::Revenj.DomainPatterns.IAggregateRoot, global::Revenj.DomainPatterns.IChangeTracking<Input>
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
		
		public Input()
			
		{
			
			this._ID = global::System.Guid.NewGuid();
			this._SubmissionID = global::System.Guid.NewGuid();
			
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
			this._BirthYear = other._BirthYear;
			this._NumberOfCars = other._NumberOfCars;
			
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
				&& other.BirthYear == this.BirthYear
				&& other.NumberOfCars == this.NumberOfCars
			;
		}
		
		internal void __ReapplyReferences()
		{
			if (_Submission != null && _Submission.URI != SubmissionURI) this.Submission = _Submission;
		}
		object ICloneable.Clone() { return Clone(); }
		
		bool IEquatable<global::Revenj.DomainPatterns.IEntity>.Equals(global::Revenj.DomainPatterns.IEntity obj) 
		{ 
			return __EqualEntity(obj as Input); 
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
				let it_Submission = it.SubmissionURI
				where it_Submission != null
				select new KeyValuePair<System.Type, string>(typeof(global::UseCase1.Submission), it_Submission));
			return result.GroupBy(it => it.Key).ToDictionary(it => it.Key, it => it.Select(e => e.Value));

		}

		internal Lazy<IDataCache<global::UseCase1.Submission>> __DataCacheSubmission;
		
		
		internal global::UseCase1.Submission _Submission;

		public global::UseCase1.Submission Submission
		{
			
			get 
			{
				
				
				if (_SubmissionURI == null && _Submission != null)
					_Submission = null;
				
				if (_Submission != null && _Submission.URI != _SubmissionURI || _Submission == null && _SubmissionURI != null)
					if(__DataCacheSubmission != null)
						_Submission = __DataCacheSubmission.Value.Find(_SubmissionURI);
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
		
		
		[DataMember(EmitDefaultValue=false,Name="SubmissionID")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="BirthYear")]
		internal int _BirthYear;

		public int BirthYear
		{
			
			get 
			{
				
				return this._BirthYear; 
			}
			
			set 
			{
				
				this._BirthYear = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="NumberOfCars")]
		internal int _NumberOfCars;

		public int NumberOfCars
		{
			
			get 
			{
				
				return this._NumberOfCars; 
			}
			
			set 
			{
				
				this._NumberOfCars = value; 
				
			}
		}

		
		private Input __OriginalValue;
		internal static bool __ChangeTrackingEnabled = true;
		private bool __TrackChanges = __ChangeTrackingEnabled;
		bool IChangeTracking<Input>.TrackChanges 
		{ 
			get { return __TrackChanges; } 
			set { __TrackChanges = value; } 
		}
		internal void __ResetChangeTracking()
		{
			if(__TrackChanges)
				this.__OriginalValue = this.Clone();
		}
		Input IChangeTracking<Input>.GetOriginalValue()
		{
			return __OriginalValue;
		}
		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
			if(SubmissionURI == null) throw new ArgumentException("In entity FormABC.Input, property Submission can't be null. SubmissionURI provided as null");
			__DataCacheSubmission = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
		}

		
		internal Input(IServiceProvider locator)
			
		{
			
			__DataCacheSubmission = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
			
		}

	}

}
