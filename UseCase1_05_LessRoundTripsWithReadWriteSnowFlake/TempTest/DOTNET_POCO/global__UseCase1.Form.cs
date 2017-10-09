
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	[DataContract(Namespace="")] public partial class Form : global::System.IEquatable<Form>, global::System.ICloneable
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
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
				
				if(_SubmissionsURI != null && _SubmissionsURI.Length == 0)
				{
					_Submissions = new global::UseCase1.Submission[] { };
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
	}

}
