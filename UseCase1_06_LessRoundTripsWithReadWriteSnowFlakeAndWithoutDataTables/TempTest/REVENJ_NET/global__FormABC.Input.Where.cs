
namespace FormABC
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


	
	
	partial class Input
	{

	
	[DataContract(Namespace="")] public class Where : global::Revenj.DomainPatterns.ISpecification<global::FormABC.Input>
	{
		
		
		public Where(string submissionURI = default(string))
			
		{
			
			this.submissionURI = submissionURI;
			
		}

		
		public Where()
			
		{
			
			
		}

		
		public Expression<Func<global::FormABC.Input, bool>> IsSatisfied 
		{ 
			get 
			{
				return it =>  it.SubmissionURI == submissionURI;
			}
		}

		internal Func<global::FormABC.Input, bool> _HelperFunctionIsSatisfiedBy
		{ 
			get 
			{
				return it =>  it.SubmissionURI == submissionURI;
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="submissionURI")]
		internal string _submissionURI = string.Empty;

		public string submissionURI
		{
			
			get 
			{
				
				return this._submissionURI; 
			}
			
			set 
			{
				
				this._submissionURI = value; 
				
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
