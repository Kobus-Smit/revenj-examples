
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
	[DataContract(Namespace="")] public partial class SelectedSubmission : global::Revenj.DomainPatterns.IEntity, global::Revenj.DomainPatterns.IIdentifiable, global::Revenj.DomainPatterns.ISnowflake<global::UseCase1.Submission>
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		bool IEquatable<IEntity>.Equals(IEntity other)
		{
			var o = other as global::UseCase1.SelectedSubmission;
			return o != null && o.URI == this.URI;
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
		
		
		[DataMember(EmitDefaultValue=false,Name="Customer")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Form")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Schema")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="FormInputs")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Group")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Comments")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Date")]
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
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
		}

		
		internal SelectedSubmission(IServiceProvider locator)
			
		{
			
			
		}

	}

}
