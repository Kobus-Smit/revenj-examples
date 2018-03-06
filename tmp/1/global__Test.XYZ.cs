
namespace Test
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
	[DataContract(Namespace="")] public partial class XYZ : global::System.IEquatable<XYZ>, global::System.ICloneable, global::Revenj.DomainPatterns.IEntity, global::Revenj.DomainPatterns.ICacheable, global::Revenj.DomainPatterns.IAggregateRoot, global::Revenj.DomainPatterns.IChangeTracking<XYZ>
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		internal static void __InternalPrepareInsert(XYZ instance)
		{
			if (instance != null) instance.__InternalPrepareInsert();
		}
		internal void __InternalPrepareInsert()
		{
			
		}

		internal static void __InternalPrepareUpdate(XYZ instance)
		{
			if (instance != null) instance.__InternalPrepareUpdate();
		}
		internal void __InternalPrepareUpdate()
		{
			
		}

		internal static void __InternalPrepareDelete(XYZ instance)
		{
			if (instance != null) instance.__InternalPrepareDelete();
		}
		internal void __InternalPrepareDelete()
		{
			
		}
		
		internal static long _InternalGetSizeApproximation(XYZ instance)
		{
			return instance == null ? 0 : instance._InternalGetSizeApproximation();
		}

		internal long _InternalGetSizeApproximation()
		{
			long size = 10; 
			return size;
		}
		[DataMember] public string URI { get; internal set; }
		
		public XYZ()
			
		{
			
			this.ID = --__SequenceCounterID__;
			
			this.URI = _ID.ToString();
		}

		
		private bool __EqualEntity(XYZ other)
		{
			return other != null 
				
				&& other.ID == this.ID
			;
		}

		public override int GetHashCode()
		{
			return this.URI != null ? this.URI.GetHashCode() : base.GetHashCode();
		}
		
		private XYZ(XYZ other)
		{
			this.URI = other.URI;
			
			this._ID = other._ID;
			this._From = other._From;
			
		}

		internal static XYZ Clone(XYZ instance)
		{
			return instance == null ? null : instance.Clone();
		}

		public XYZ Clone()
		{
			return new XYZ(this);
		}
		//TODO let's leave it out for now
		//public override bool Equals(object other) { return Equals(other as XYZ); }
		public bool Equals(XYZ other)
		{
			return other != null
				&& other.URI == this.URI
				
				&& other.ID == this.ID
				&& other.From == this.From
			;
		}
		
		internal void __ReapplyReferences()
		{
			
		}
		object ICloneable.Clone() { return Clone(); }
		
		bool IEquatable<global::Revenj.DomainPatterns.IEntity>.Equals(global::Revenj.DomainPatterns.IEntity obj) 
		{ 
			return __EqualEntity(obj as XYZ); 
		}
		
		
		[DataMember(EmitDefaultValue=false,Name="ID")]
		internal int _ID;

		public int ID
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

		
	private static int __SequenceCounterID__;
		
		
		Dictionary<System.Type, IEnumerable<string>> ICacheable.GetRelationships()
		{
			

			
			var result = new List<KeyValuePair<System.Type, string>>();

			return result.GroupBy(it => it.Key).ToDictionary(it => it.Key, it => it.Select(e => e.Value));

		}

		
		
		[DataMember(EmitDefaultValue=false,Name="From")]
		internal string _From = string.Empty;

		public string From
		{
			
			
			get 
			{
				
				return this._From; 
			}
			
			set 
			{
				
				this._From = value; 
				
			}
		}

		
		private XYZ __OriginalValue;
		internal static bool __ChangeTrackingEnabled = true;
		private bool __TrackChanges = __ChangeTrackingEnabled;
		bool IChangeTracking<XYZ>.TrackChanges 
		{ 
			get { return __TrackChanges; } 
			set { __TrackChanges = value; } 
		}
		internal void __ResetChangeTracking()
		{
			if(__TrackChanges)
				this.__OriginalValue = this.Clone();
		}
		XYZ IChangeTracking<XYZ>.GetOriginalValue()
		{
			return __OriginalValue;
		}
		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
		}

		
		internal XYZ(IServiceProvider locator)
			
		{
			
			
		}

	}

}

namespace Test 
{
	public static class _XYZ_FindHelper_
	{
		public static global::Test.XYZ Find(this global::Revenj.DomainPatterns.IRepository<global::Test.XYZ> repository, int id)
		{
			var repo = repository as DatabaseRepositoryTest.XYZRepository;
			if (repo != null) return repo.Find(id);
			return repository.Find(id.ToString());
		}
	}
}