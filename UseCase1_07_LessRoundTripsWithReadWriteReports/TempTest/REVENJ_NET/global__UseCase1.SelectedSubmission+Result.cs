
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


	
	
	partial class SelectedSubmission
	{

	
	[Serializable]
	[DataContract(Namespace="")] public class Result 
	{
		
		
		public Result()
			
		{
			
			
		}

		internal string uri;
		
		
		[DataMember(EmitDefaultValue=false,Name="Submission")]
		internal global::UseCase1.Submission _Submission;

		public global::UseCase1.Submission Submission
		{
			
			get 
			{
				
				return this._Submission; 
			}
			internal
			set 
			{
				
				this._Submission = value; 
				
			}
		}

		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
		}

		
		internal Result(IServiceProvider locator)
			
		{
			
			
		}

	}

	}

}
