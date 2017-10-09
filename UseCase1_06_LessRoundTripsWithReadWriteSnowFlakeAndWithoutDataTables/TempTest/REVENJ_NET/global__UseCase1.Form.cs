
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
	[DataContract(Namespace="")] public partial class Form : global::System.IEquatable<Form>, global::System.ICloneable, global::Revenj.DomainPatterns.IEntity, global::Revenj.DomainPatterns.ICacheable, global::Revenj.DomainPatterns.IAggregateRoot, global::Revenj.DomainPatterns.IChangeTracking<Form>
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		internal void __InternalPrepareInsert()
		{
			
			ID = global::System.Guid.NewGuid();
			if(this._Inputs != null) 
				foreach(var __p in this._Inputs) 
					__p.__InternalPrepareInsert();
			if(this._Outputs != null) 
				foreach(var __p in this._Outputs) 
					__p.__InternalPrepareInsert();
		}
		internal void __InternalPrepareUpdate()
		{
			
			if(this._Inputs != null) 
				foreach(var __p in this._Inputs) 
					__p.__InternalPrepareUpdate();
			if(this._Outputs != null) 
				foreach(var __p in this._Outputs) 
					__p.__InternalPrepareUpdate();
		}
		internal void __InternalPrepareDelete()
		{
			
			if(this._Inputs != null) 
				foreach(var __p in this._Inputs) 
					__p.__InternalPrepareDelete();
			if(this._Outputs != null) 
				foreach(var __p in this._Outputs) 
					__p.__InternalPrepareDelete();
		}
		
		internal long _InternalGetSizeApproximation()
		{
			long size = 50; 
			size += this.Inputs != null ? this.Inputs.Sum(it => it != null ? it._InternalGetSizeApproximation() : 0) : 0;
			size += this.Outputs != null ? this.Outputs.Sum(it => it != null ? it._InternalGetSizeApproximation() : 0) : 0;
			return size;
		}
		[DataMember] public string URI { get; internal set; }
		
		public Form()
			
		{
			
			this._ID = global::System.Guid.NewGuid();
			this._GroupID = global::System.Guid.NewGuid();
			this._Status = global::UseCase1.FormStatus.New;
			this._Inputs = new System.Collections.Generic.List<global::UseCase1.Entry>();
			this._Outputs = new System.Collections.Generic.List<global::UseCase1.Entry>();
			
			this.URI = _ID.ToString();
		}

		
		private bool __EqualEntity(Form other)
		{
			return other != null 
				
				&& other.ID == this.ID
			;
		}

		public override int GetHashCode()
		{
			return this.URI != null ? this.URI.GetHashCode() : base.GetHashCode();
		}
		
		private Form(Form other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._Name = other._Name;
			this._Schema = other._Schema;
			this._GroupURI = other._GroupURI; this._Group = other._Group;
			this._GroupID = other._GroupID;
			this._Status = other._Status;
			this.Inputs = other.Inputs == null ? null : other._Inputs.Select(it => it.Clone()).ToList();
			this.Outputs = other.Outputs == null ? null : other._Outputs.Select(it => it.Clone()).ToList();
			this._SubmissionsURI = other.SubmissionsURI;
			
		}

		public Form Clone()
		{
			return new Form(this);
		}
		//TODO let's leave it out for now
		//public override bool Equals(object other) { return Equals(other as Form); }
		public bool Equals(Form other)
		{
			return other != null
				&& other.URI == this.URI
				
				&& other.ID == this.ID
				&& other.Name == this.Name
				&& other.Schema == this.Schema
				&& this._GroupURI == other._GroupURI
				&& other.GroupID == this.GroupID
				&& this._Status == other._Status
				&& (this.Inputs == other.Inputs || this.Inputs != null && other.Inputs != null && this.Inputs.SequenceEqual(other.Inputs))
				&& (this.Outputs == other.Outputs || this.Outputs != null && other.Outputs != null && this.Outputs.SequenceEqual(other.Outputs))
				&& (this.SubmissionsURI == other.SubmissionsURI || this.SubmissionsURI != null && this.SubmissionsURI.SequenceEqual(other.SubmissionsURI))
			;
		}
		
		internal void __ReapplyReferences()
		{
			if (_Group != null && _Group.URI != GroupURI) this.Group = _Group;
		}
		object ICloneable.Clone() { return Clone(); }
		
		bool IEquatable<global::Revenj.DomainPatterns.IEntity>.Equals(global::Revenj.DomainPatterns.IEntity obj) 
		{ 
			return __EqualEntity(obj as Form); 
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
				let it_Group = it.GroupURI
				where it_Group != null
				select new KeyValuePair<System.Type, string>(typeof(global::UseCase1.FormGroup), it_Group));
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Schema")]
		internal string _Schema = string.Empty;

		public string Schema
		{
			
			get 
			{
				
				return this._Schema; 
			}
			
			set 
			{
				
				this._Schema = value; 
				
			}
		}

		internal Lazy<IDataCache<global::UseCase1.FormGroup>> __DataCacheGroup;
		
		
		internal global::UseCase1.FormGroup _Group;

		public global::UseCase1.FormGroup Group
		{
			
			get 
			{
				
				
				if (_GroupURI == null && _Group != null)
					_Group = null;
				
				if (_Group != null && _Group.URI != _GroupURI || _Group == null && _GroupURI != null)
					if(__DataCacheGroup != null)
						_Group = __DataCacheGroup.Value.Find(_GroupURI);
				return this._Group; 
			}
			
			set 
			{
				
				
				if(value == null) 
					throw new ArgumentNullException("Property Group can't be null");
				this._Group = value; 
				
				_GroupURI = value != null ? value.URI : null;
				
				if(value == null)
					throw new ArgumentException("Property GroupID doesn't allow null values");
				else if(GroupID != value.ID)
					GroupID = value.ID;
			}
		}

		
		internal string _GroupURI;
		[DataMember]
		public string GroupURI 
		{ 
			get 
			{ 
				if (_Group != null) _GroupURI = _Group.URI;
				return _GroupURI; 
			} 
			private set { _GroupURI = value; } //TODO: serialization ;(
		}
		
		
		[DataMember(EmitDefaultValue=false,Name="GroupID")]
		internal global::System.Guid _GroupID;

		public global::System.Guid GroupID
		{
			
			get 
			{
				
				if (_Group != null) GroupID = _Group.ID;
				return this._GroupID; 
			}
			internal
			set 
			{
				
				this._GroupID = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="Status")]
		internal global::UseCase1.FormStatus _Status;

		public global::UseCase1.FormStatus Status
		{
			
			get 
			{
				
				return this._Status; 
			}
			
			set 
			{
				
				
				if(value == null) 
					throw new ArgumentNullException("Property Status can't be null");
				this._Status = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="Inputs")]
		internal System.Collections.Generic.List<global::UseCase1.Entry> _Inputs;

		public System.Collections.Generic.List<global::UseCase1.Entry> Inputs
		{
			
			get 
			{
				
				
				if(_Inputs == null)
					_Inputs = new System.Collections.Generic.List<global::UseCase1.Entry>();
				return this._Inputs; 
			}
			
			set 
			{
				
				
				if(value == null) 
					value = new System.Collections.Generic.List<global::UseCase1.Entry>();
				
				if(value != null)
				{
					var __elIndx = 0;
					foreach(var it in value)
					{
						if(it == null)
							throw new ArgumentException(string.Format("Null element found at index {0} in property \"Inputs\" in object \"UseCase1.Form\". Collection elements can't be null.", __elIndx));
						__elIndx++;
					}
				}
				this._Inputs = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="Outputs")]
		internal System.Collections.Generic.List<global::UseCase1.Entry> _Outputs;

		public System.Collections.Generic.List<global::UseCase1.Entry> Outputs
		{
			
			get 
			{
				
				
				if(_Outputs == null)
					_Outputs = new System.Collections.Generic.List<global::UseCase1.Entry>();
				return this._Outputs; 
			}
			
			set 
			{
				
				
				if(value == null) 
					value = new System.Collections.Generic.List<global::UseCase1.Entry>();
				
				if(value != null)
				{
					var __elIndx = 0;
					foreach(var it in value)
					{
						if(it == null)
							throw new ArgumentException(string.Format("Null element found at index {0} in property \"Outputs\" in object \"UseCase1.Form\". Collection elements can't be null.", __elIndx));
						__elIndx++;
					}
				}
				this._Outputs = value; 
				
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
							throw new ArgumentException(string.Format("Null element found at index {0} in property \"Submissions\" in object \"UseCase1.Form\". Collection elements can't be null.", __elIndx));
						__elIndx++;
					}
				}
				this._Submissions = value; 
				
				_SubmissionsURI = null;
			}
		}

		
		private static Expression<Func<global::UseCase1.Form, int>> _SubmissionsCountExpression = m => m.Submissions.Count();
		private static Func<global::UseCase1.Form, int> _SubmissionsCountFunc = m => m.Submissions.Count();

		[DataMember(EmitDefaultValue=false,Name="SubmissionsCount")]
		public int SubmissionsCount
		{
			get	
			{ 
				var value = _SubmissionsCountFunc(this); 
				return value;
			}
			private set { } //Oh my stupid .NET serialization
		}
		
		private Form __OriginalValue;
		internal static bool __ChangeTrackingEnabled = true;
		private bool __TrackChanges = __ChangeTrackingEnabled;
		bool IChangeTracking<Form>.TrackChanges 
		{ 
			get { return __TrackChanges; } 
			set { __TrackChanges = value; } 
		}
		internal void __ResetChangeTracking()
		{
			if(__TrackChanges)
				this.__OriginalValue = this.Clone();
		}
		Form IChangeTracking<Form>.GetOriginalValue()
		{
			return __OriginalValue;
		}
		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
			if(GroupURI == null) throw new ArgumentException("In entity UseCase1.Form, property Group can't be null. GroupURI provided as null");
			__DataCacheGroup = new Lazy<IDataCache<global::UseCase1.FormGroup>>(() => locator.Resolve<IDataCache<global::UseCase1.FormGroup>>());
			if(Status == null) throw new ArgumentException("In entity UseCase1.Form, property Status can't be null");
			__DataCacheSubmissions = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
		}

		
		internal Form(IServiceProvider locator)
			
		{
			
			__DataCacheGroup = new Lazy<IDataCache<global::UseCase1.FormGroup>>(() => locator.Resolve<IDataCache<global::UseCase1.FormGroup>>());
			__DataCacheSubmissions = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
			
		}

	}

}
