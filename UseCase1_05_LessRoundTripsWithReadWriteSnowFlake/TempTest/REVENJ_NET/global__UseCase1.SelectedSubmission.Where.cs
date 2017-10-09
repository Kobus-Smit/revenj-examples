
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

	
	[DataContract(Namespace="")] public class Where : global::Revenj.DomainPatterns.ISpecification<global::UseCase1.SelectedSubmission>
	{
		
		
		public Where(string uri = default(string))
			
		{
			
			this.uri = uri;
			
		}

		
		public Where()
			
		{
			
			
		}

		
		public Expression<Func<global::UseCase1.SelectedSubmission, bool>> IsSatisfied 
		{ 
			get 
			{
				return it =>  it.URI == uri;
			}
		}

		internal Func<global::UseCase1.SelectedSubmission, bool> _HelperFunctionIsSatisfiedBy
		{ 
			get 
			{
				return it =>  it.URI == uri;
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="uri")]
		internal string _uri = string.Empty;

		public string uri
		{
			
			get 
			{
				
				return this._uri; 
			}
			
			set 
			{
				
				this._uri = value; 
				
			}
		}

		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
		}

		
		internal Where(IServiceProvider locator)
			
		{
			
			
		}

	}

	}

}
