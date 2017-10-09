
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


	
	
	
	[DataContract(Namespace="")] public partial class FormList : global::Revenj.DomainPatterns.IIdentifiable
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		public static global::UseCase1.FormList Find(string uri, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.FormList>(uri).Result; 
		}
		public static global::UseCase1.FormList[] Find(IEnumerable<string> uris, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.FormList>(uris).Result;
		}
		public static global::UseCase1.FormList[] FindAll(int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().FindAll<global::UseCase1.FormList>(limit, offset).Result;
		}
		public static global::UseCase1.FormList[] Search(ISpecification<global::UseCase1.FormList> specification, int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(specification, limit, offset, null).Result;
		}
		[DataMember] public string URI { get; internal set; }
		
		public FormList()
			
		{
			
			
		}

		
		
		public void Update(global::UseCase1.Form entity)
		{
			

			this.URI = entity.URI;
			this.Name = entity.Name;
			this.Group = entity.Group != null  ? entity.Group.Name : default(string);
			this.Status = entity.Status;
			this.SubmissionsCount = entity.SubmissionsCount;
		}

		
		public static FormList CreateFrom(global::UseCase1.Form entity)
		{
			var snowflake = new FormList();
			snowflake.Update(entity);
			return snowflake;
		}
		
		
		[DataMember(Name="Name")]
		internal string _Name = string.Empty;

		public string Name
		{
			
			get 
			{
				
				return this._Name; 
			}
			internal
			set 
			{
				
				this._Name = value; 
				
			}
		}

		
		
		[DataMember(Name="Group")]
		internal string _Group = string.Empty;

		public string Group
		{
			
			get 
			{
				
				return this._Group; 
			}
			internal
			set 
			{
				
				this._Group = value; 
				
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
			internal
			set 
			{
				
				this._Status = value; 
				
			}
		}

		
		
		[DataMember(Name="SubmissionsCount")]
		internal int _SubmissionsCount;

		public int SubmissionsCount
		{
			
			get 
			{
				
				return this._SubmissionsCount; 
			}
			internal
			set 
			{
				
				this._SubmissionsCount = value; 
				
			}
		}

		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as IServiceProvider;
			if (locator == null) return;
		}

	}

}
