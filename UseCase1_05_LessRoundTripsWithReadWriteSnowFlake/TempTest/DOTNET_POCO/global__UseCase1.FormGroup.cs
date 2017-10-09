
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	[DataContract(Namespace="")] public partial class FormGroup : global::System.IEquatable<FormGroup>, global::System.ICloneable
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		[DataMember] public string URI { get; internal set; }
		
		public FormGroup()
			
		{
			
			this._ID = global::System.Guid.NewGuid();
			
			this.URI = _ID.ToString();
		}

		
		private bool __EqualEntity(FormGroup other)
		{
			return other != null 
				
				&& other.ID == this.ID
			;
		}

		public override int GetHashCode()
		{
			return this.URI != null ? this.URI.GetHashCode() : base.GetHashCode();
		}
		
		private FormGroup(FormGroup other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._Name = other._Name;
			this._FormsURI = other.FormsURI;
			
		}

		public FormGroup Clone()
		{
			return new FormGroup(this);
		}
		//TODO let's leave it out for now
		//public override bool Equals(object other) { return Equals(other as FormGroup); }
		public bool Equals(FormGroup other)
		{
			return other != null
				&& other.URI == this.URI
				
				&& other.ID == this.ID
				&& other.Name == this.Name
				&& (this.FormsURI == other.FormsURI || this.FormsURI != null && this.FormsURI.SequenceEqual(other.FormsURI))
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

		
		internal string[] _FormsURI;
		[DataMember]
		public string[] FormsURI 
		{ 
			get 
			{
				if(_Forms != null)
					return _Forms.Select(it => it.URI).ToArray();
				return (_FormsURI ?? new string[0]).ToArray();
			}
			private set {  _FormsURI = value ?? new string[0]; } //TODO: doesn't work on field correctly ;(
		}
		
		
		internal global::UseCase1.Form[] _Forms;

		public global::UseCase1.Form[] Forms
		{
			
			get 
			{
				
				
				if(_Forms == null)
					_Forms = new global::UseCase1.Form[] { };
				
				if(_FormsURI != null && _FormsURI.Length == 0)
				{
					_Forms = new global::UseCase1.Form[] { };
					_FormsURI = null;
				}
				return this._Forms; 
			}
			private
			set 
			{
				
				
				if(value == null) 
					value = new global::UseCase1.Form[] { };
				
				if(value != null)
				{
					var __elIndx = 0;
					foreach(var it in value)
					{
						if(it == null)
							throw new ArgumentException(string.Format("Null element found at index {0} in property \"Forms\" in object \"UseCase1.FormGroup\". Collection elements can't be null.", __elIndx));
						__elIndx++;
					}
				}
				this._Forms = value; 
				
				_FormsURI = null;
			}
		}

	}

}
