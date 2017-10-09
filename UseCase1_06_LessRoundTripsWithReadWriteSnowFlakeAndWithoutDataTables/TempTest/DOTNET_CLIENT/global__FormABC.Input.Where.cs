
namespace FormABC
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


	
	
	partial class Input
	{

	
	[DataContract(Namespace="")] public class Where : global::Revenj.DomainPatterns.ISpecification<global::FormABC.Input>
	{
		
		
		public Where(string submissionURI = default(string))
			
		{
			
			this.submissionURI = submissionURI;
			
		}

		
		private Where()
			
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

		
		
		[DataMember(Name="submissionURI")]
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

		
		public global::FormABC.Input[] Search(IServiceProvider locator = null, int? limit = null, int? offset = null, IDictionary<string, bool> order = null)
		{
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(this, limit, offset, order).Result;
		}
	}

	}

}
