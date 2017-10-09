
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
	[DataContract(Namespace="")] public partial class FormGroup : global::System.IEquatable<FormGroup>, global::System.ICloneable, global::Revenj.DomainPatterns.IEntity, global::Revenj.DomainPatterns.ICacheable, global::Revenj.DomainPatterns.IAggregateRoot, global::Revenj.DomainPatterns.IChangeTracking<FormGroup>
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
			long size = 15; 
			return size;
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
		
		bool IEquatable<global::Revenj.DomainPatterns.IEntity>.Equals(global::Revenj.DomainPatterns.IEntity obj) 
		{ 
			return __EqualEntity(obj as FormGroup); 
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
				from it_Forms in it.FormsURI
				where it_Forms != null
				select new KeyValuePair<System.Type, string>(typeof(global::UseCase1.Form), it_Forms));
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
		internal Lazy<IDataCache<global::UseCase1.Form>> __DataCacheForms;
		
		
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
				
				if (_FormsURI != null)
				{
					if(_FormsURI.Length == 0)
						{ _Forms = new global::UseCase1.Form[] { }; _FormsURI = null; }
					else if(__DataCacheForms != null)
						{ _Forms = __DataCacheForms.Value.Find(_FormsURI); _FormsURI = null; }
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

		
		private FormGroup __OriginalValue;
		internal static bool __ChangeTrackingEnabled = true;
		private bool __TrackChanges = __ChangeTrackingEnabled;
		bool IChangeTracking<FormGroup>.TrackChanges 
		{ 
			get { return __TrackChanges; } 
			set { __TrackChanges = value; } 
		}
		internal void __ResetChangeTracking()
		{
			if(__TrackChanges)
				this.__OriginalValue = this.Clone();
		}
		FormGroup IChangeTracking<FormGroup>.GetOriginalValue()
		{
			return __OriginalValue;
		}
		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
			__DataCacheForms = new Lazy<IDataCache<global::UseCase1.Form>>(() => locator.Resolve<IDataCache<global::UseCase1.Form>>());
		}

		
		internal FormGroup(IServiceProvider locator)
			
		{
			
			__DataCacheForms = new Lazy<IDataCache<global::UseCase1.Form>>(() => locator.Resolve<IDataCache<global::UseCase1.Form>>());
			
		}

	}

}
