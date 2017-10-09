
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


	
	
	
	[Serializable]
	[DataContract(Namespace="")] public partial class SubmissionList : global::Revenj.DomainPatterns.IEntity, global::Revenj.DomainPatterns.IIdentifiable, global::Revenj.DomainPatterns.ISnowflake<global::UseCase1.Submission>
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		bool IEquatable<IEntity>.Equals(IEntity other)
		{
			var o = other as global::UseCase1.SubmissionList;
			return o != null && o.URI == this.URI;
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
		
		
		[DataMember(EmitDefaultValue=false,Name="Customer")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Form")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Group")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Date")]
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
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
		}

		
		internal SubmissionList(IServiceProvider locator)
			
		{
			
			
		}

	}

}
