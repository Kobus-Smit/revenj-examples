
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
	[DataContract(Namespace="")] public partial class FormList : global::Revenj.DomainPatterns.IEntity, global::Revenj.DomainPatterns.IIdentifiable, global::Revenj.DomainPatterns.ISnowflake<global::UseCase1.Form>
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		bool IEquatable<IEntity>.Equals(IEntity other)
		{
			var o = other as global::UseCase1.FormList;
			return o != null && o.URI == this.URI;
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
		
		
		[DataMember(EmitDefaultValue=false,Name="Name")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="Status")]
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

		
		
		[DataMember(EmitDefaultValue=false,Name="SubmissionsCount")]
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
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
		}

		
		internal FormList(IServiceProvider locator)
			
		{
			
			
		}

	}

}
