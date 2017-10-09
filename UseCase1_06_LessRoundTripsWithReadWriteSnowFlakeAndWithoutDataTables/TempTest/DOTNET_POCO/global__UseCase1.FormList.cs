
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	[DataContract(Namespace="")] public partial class FormList 
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
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

	}

}
