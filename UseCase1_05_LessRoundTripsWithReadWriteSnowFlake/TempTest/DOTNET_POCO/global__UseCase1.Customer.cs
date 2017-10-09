
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	[DataContract(Namespace="")] public partial class Customer : global::System.IEquatable<Customer>, global::System.ICloneable
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		[DataMember] public string URI { get; internal set; }
		
		public Customer()
			
		{
			
			this._ID = global::System.Guid.NewGuid();
			
			this.URI = _ID.ToString();
		}

		
		private bool __EqualEntity(Customer other)
		{
			return other != null 
				
				&& other.ID == this.ID
			;
		}

		public override int GetHashCode()
		{
			return this.URI != null ? this.URI.GetHashCode() : base.GetHashCode();
		}
		
		private Customer(Customer other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._Name = other._Name;
			this._RegistrationNumber = other._RegistrationNumber;
			this._SubmissionsURI = other.SubmissionsURI;
			
		}

		public Customer Clone()
		{
			return new Customer(this);
		}
		//TODO let's leave it out for now
		//public override bool Equals(object other) { return Equals(other as Customer); }
		public bool Equals(Customer other)
		{
			return other != null
				&& other.URI == this.URI
				
				&& other.ID == this.ID
				&& other.Name == this.Name
				&& other.RegistrationNumber == this.RegistrationNumber
				&& (this.SubmissionsURI == other.SubmissionsURI || this.SubmissionsURI != null && this.SubmissionsURI.SequenceEqual(other.SubmissionsURI))
			;
		}
		
		internal void __ReapplyReferences()
		{
			
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

		
		
		[DataMember(Name="RegistrationNumber")]
		internal int _RegistrationNumber;

		public int RegistrationNumber
		{
			
			get 
			{
				
				return this._RegistrationNumber; 
			}
			
			set 
			{
				
				this._RegistrationNumber = value; 
				
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
							throw new ArgumentException(string.Format("Null element found at index {0} in property \"Submissions\" in object \"UseCase1.Customer\". Collection elements can't be null.", __elIndx));
						__elIndx++;
					}
				}
				this._Submissions = value; 
				
				_SubmissionsURI = null;
			}
		}

	}

}
