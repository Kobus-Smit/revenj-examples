
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


	
	
	
	[DataContract(Namespace="")] public partial class SubmissionList : global::Revenj.DomainPatterns.IIdentifiable
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		public static global::UseCase1.SubmissionList Find(string uri, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.SubmissionList>(uri).Result; 
		}
		public static global::UseCase1.SubmissionList[] Find(IEnumerable<string> uris, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.SubmissionList>(uris).Result;
		}
		public static global::UseCase1.SubmissionList[] FindAll(int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().FindAll<global::UseCase1.SubmissionList>(limit, offset).Result;
		}
		public static global::UseCase1.SubmissionList[] Search(ISpecification<global::UseCase1.SubmissionList> specification, int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(specification, limit, offset, null).Result;
		}
		[DataMember] public string URI { get; internal set; }
		
		public SubmissionList()
			
		{
			
			
		}

		
		
		public void Update(global::UseCase1.Submission entity)
		{
			

			this.URI = entity.URI;
			this.Customer = entity.Customer != null  ? entity.Customer.Name : default(string);
			this.Form = entity.Form != null  ? entity.Form.Name : default(string);
			this.Group = entity.Form != null  && entity.Form.Group != null  ? entity.Form.Group.Name : default(string);
			this.Date = entity.Date;
		}

		
		public static SubmissionList CreateFrom(global::UseCase1.Submission entity)
		{
			var snowflake = new SubmissionList();
			snowflake.Update(entity);
			return snowflake;
		}
		
		
		[DataMember(Name="Customer")]
		internal string _Customer = string.Empty;

		public string Customer
		{
			
			get 
			{
				
				return this._Customer; 
			}
			internal
			set 
			{
				
				this._Customer = value; 
				
			}
		}

		
		
		[DataMember(Name="Form")]
		internal string _Form = string.Empty;

		public string Form
		{
			
			get 
			{
				
				return this._Form; 
			}
			internal
			set 
			{
				
				this._Form = value; 
				
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

		
		
		[DataMember(Name="Date")]
		internal DateTime _Date;

		public DateTime Date
		{
			
			get 
			{
				
				return this._Date; 
			}
			internal
			set 
			{
				
				this._Date = value; 
				
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
