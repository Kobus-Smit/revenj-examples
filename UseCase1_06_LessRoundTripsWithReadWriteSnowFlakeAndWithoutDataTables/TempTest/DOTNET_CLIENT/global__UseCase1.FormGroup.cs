
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


	
	
	
	[DataContract(Namespace="")] public partial class FormGroup : global::System.IEquatable<FormGroup>, global::System.ICloneable, global::Revenj.DomainPatterns.IAggregateRoot
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		[DataMember] public string URI { get; internal set; }
		internal IServiceProvider __locator;
		
		public FormGroup()
			
		{
			
			this.URI = base.GetHashCode().ToString();
			this._ID = global::System.Guid.NewGuid();
			this._Forms = new global::UseCase1.Form[] { };
			
			this.URI = _ID.ToString();
		}

		
		public global::UseCase1.FormGroup Clone()
		{
			return new FormGroup(this);
		}
		private FormGroup(FormGroup other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._Name = other._Name;
			this._FormsURI = other.FormsURI;
		}
		bool IEquatable<FormGroup>.Equals(FormGroup other)
		{
			return other.URI == this.URI
				
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

		
		public static event Action<FormGroup> Validating = a => { };
		public void Validate()
		{
			Validating(this);
		}
		
		public static global::UseCase1.FormGroup Find(string uri, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.FormGroup>(uri).Result; 
		}
		public static global::UseCase1.FormGroup[] Find(IEnumerable<string> uris, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.FormGroup>(uris).Result;
		}
		public static global::UseCase1.FormGroup[] FindAll(int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().FindAll<global::UseCase1.FormGroup>(limit, offset).Result;
		}
		public static global::UseCase1.FormGroup[] Search(ISpecification<global::UseCase1.FormGroup> specification, int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(specification, limit, offset, null).Result;
		}
		
		internal void UpdateWithAnother(global::UseCase1.FormGroup result)
		{
			this.URI = result.URI;
			
			this.Name = result.Name;
			this.Forms = result.Forms;
			this._FormsURI = result._FormsURI;
			this.ID = result.ID;
		}
		public global::UseCase1.FormGroup Create(IServiceProvider locator = null)
		{
			var proxy = (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>();
			var result = proxy.Create(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			this.__locator = locator ?? Static.Locator;
			return this;
		}
		public global::UseCase1.FormGroup Update()
		{
			if (__locator == null) throw new ArgumentException("Can't update new aggregate");
			var proxy = __locator.Resolve<Revenj.ICrudProxy>();
			var result = proxy.Update(this).Result;
			this.URI = result.URI;
			this.ID = result.ID;
			return this;
		}
		public global::UseCase1.FormGroup Delete()
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
				
				if (__locator != null && _FormsURI != null)
				{
					_Forms = (__locator.Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.Form>(_FormsURI).Result);
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

		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as IServiceProvider;
			if (locator == null) return;
			__locator = locator;
		}

	}

}
