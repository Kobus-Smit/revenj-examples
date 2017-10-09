
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


	
	
	
	[DataContract(Namespace="")] public partial class SelectedSubmission : global::Revenj.DomainPatterns.IIdentifiable
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		public static global::UseCase1.SelectedSubmission Find(string uri, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.ICrudProxy>().Read<global::UseCase1.SelectedSubmission>(uri).Result; 
		}
		public static global::UseCase1.SelectedSubmission[] Find(IEnumerable<string> uris, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Find<global::UseCase1.SelectedSubmission>(uris).Result;
		}
		public static global::UseCase1.SelectedSubmission[] FindAll(int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().FindAll<global::UseCase1.SelectedSubmission>(limit, offset).Result;
		}
		public static global::UseCase1.SelectedSubmission[] Search(ISpecification<global::UseCase1.SelectedSubmission> specification, int? limit = null, int? offset = null, IServiceProvider locator = null)
		{ 
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(specification, limit, offset, null).Result;
		}
		[DataMember] public string URI { get; internal set; }
		
		public SelectedSubmission()
			
		{
			
			this._FormInputs = new System.Collections.Generic.List<global::UseCase1.Entry>();
			
		}

		
		
		public void Update(global::UseCase1.Submission entity)
		{
			

			this.URI = entity.URI;
			this.Customer = entity.Customer != null  ? entity.Customer.Name : default(string);
			this.Form = entity.Form != null  ? entity.Form.Name : default(string);
			this.Schema = entity.Form != null  ? entity.Form.Schema : default(string);
			this.FormInputs = entity.Form != null  ? entity.Form.Inputs : null;
			this.Group = entity.Form != null  && entity.Form.Group != null  ? entity.Form.Group.Name : default(string);
			this.Comments = entity.Comments;
			this.Date = entity.Date;
		}

		
		public static SelectedSubmission CreateFrom(global::UseCase1.Submission entity)
		{
			var snowflake = new SelectedSubmission();
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
			
			set 
			{
				
				this._Form = value; 
				
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

		
		
		[DataMember(Name="FormInputs")]
		internal System.Collections.Generic.List<global::UseCase1.Entry> _FormInputs;

		public System.Collections.Generic.List<global::UseCase1.Entry> FormInputs
		{
			
			get 
			{
				
				
				if(_FormInputs == null)
					_FormInputs = new System.Collections.Generic.List<global::UseCase1.Entry>();
				return this._FormInputs; 
			}
			
			set 
			{
				
				
				if(value == null) 
					value = new System.Collections.Generic.List<global::UseCase1.Entry>();
				this._FormInputs = value; 
				
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
			
			set 
			{
				
				this._Group = value; 
				
			}
		}

		
		
		[DataMember(Name="Comments")]
		internal string _Comments = string.Empty;

		public string Comments
		{
			
			get 
			{
				
				return this._Comments; 
			}
			
			set 
			{
				
				this._Comments = value; 
				
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
