
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


	
	
	
	[DataContract(Namespace="")] public partial class Form : global::System.IEquatable<Form>, global::System.ICloneable, global::Revenj.DomainPatterns.IAggregateRoot
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		[DataMember] public string URI { get; internal set; }
		internal IServiceProvider __locator;
		
		public Form()
			
		{
			
			this.URI = base.GetHashCode().ToString();
			this._ID = global::System.Guid.NewGuid();
			this._GroupID = global::System.Guid.NewGuid();
			this._Inputs = new System.Collections.Generic.List<global::UseCase1.Entry>();
			this._Outputs = new System.Collections.Generic.List<global::UseCase1.Entry>();
			this._Submissions = new global::UseCase1.Submission[] { };
			
			this.URI = _ID.ToString();
		}

		
		public global::UseCase1.Form Clone()
		{
			return new Form(this);
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
		bool IEquatable<Form>.Equals(Form other)
		{
			return other.URI == this.URI
				
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

		
		public static event Action<Form> Validating = a => { };
		public void Validate()
		{
			Validating(this);
		}
		
		public static global::UseCase1.Form Find(string uri, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.Form>(uri).Result; 
		}
		public static global::UseCase1.Form[] Find(IEnumerable<string> uris, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.Form>(uris).Result;
		}
		public static global::UseCase1.Form[] FindAll(int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().FindAll<global::UseCase1.Form>(limit, offset).Result;
		}
		public static global::UseCase1.Form[] Search(ISpecification<global::UseCase1.Form> specification, int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(specification, limit, offset, null).Result;
		}
		
		internal void UpdateWithAnother(global::UseCase1.Form result)
		{
			this.URI = result.URI;
			
			this.Name = result.Name;
			this.Schema = result.Schema;
			this.Group = result.Group;
			this._GroupURI = result._GroupURI;
			this.GroupID = result.GroupID;
			this.Status = result.Status;
			this.Inputs = result.Inputs;
			this.Outputs = result.Outputs;
			this.Submissions = result.Submissions;
			this._SubmissionsURI = result._SubmissionsURI;
			this.ID = result.ID;
		}
		public global::UseCase1.Form Create(IServiceProvider locator = null)
		{
			var proxy = (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>();
			var result = proxy.Create(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			this.__locator = locator ?? Static.Locator;
			return this;
		}
		public global::UseCase1.Form Update()
		{
			if (__locator == null) throw new ArgumentException("Can't update new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			var result = proxy.Update(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			return this;
		}
		public global::UseCase1.Form Delete()
		{
			if (__locator == null) throw new ArgumentException("Can't delete new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			return proxy.Delete(this).Result;
		}
		
		
		[DataMember(Name="Name")]
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

		
		
		[DataMember(Name="Schema")]
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

		
		
		internal global::UseCase1.FormGroup _Group;

		public global::UseCase1.FormGroup Group
		{
			
			get 
			{
				
				
				if (_GroupURI == null && _Group != null)
					_Group = null;
				
				if (__locator != null && _Group != null && _Group.URI != _GroupURI || _Group == null && _GroupURI != null)
					_Group = __locator.Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.FormGroup>(_GroupURI).Result;
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
		
		
		[DataMember(Name="GroupID")]
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

		
		
		[DataMember(Name="Status")]
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

		
		
		[DataMember(Name="Inputs")]
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

		
		
		[DataMember(Name="Outputs")]
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
		
		
		internal global::UseCase1.Submission[] _Submissions;

		public global::UseCase1.Submission[] Submissions
		{
			
			get 
			{
				
				
				if(_Submissions == null)
					_Submissions = new global::UseCase1.Submission[] { };
				
				if (__locator != null && _SubmissionsURI != null)
				{
					_Submissions = (__locator.Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.Submission>(_SubmissionsURI).Result);
					_SubmissionsURI = null;
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

		[DataMember(Name="SubmissionsCount")]
		public int SubmissionsCount
		{
			get	
			{ 
				var value = _SubmissionsCountFunc(this); 
				return value;
			}
			private set { } //Oh my stupid .NET serialization
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
