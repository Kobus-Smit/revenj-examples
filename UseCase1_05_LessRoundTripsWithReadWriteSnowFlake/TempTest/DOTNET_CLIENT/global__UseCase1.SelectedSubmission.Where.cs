
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


	
	
	partial class SelectedSubmission
	{

	
	[DataContract(Namespace="")] public class Where : global::Revenj.DomainPatterns.ISpecification<global::UseCase1.SelectedSubmission>
	{
		
		
		public Where(string uri = default(string))
			
		{
			
			this.uri = uri;
			
		}

		
		private Where()
			
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

		
		
		[DataMember(Name="uri")]
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

		
		public global::UseCase1.SelectedSubmission[] Search(IServiceProvider locator = null, int? limit = null, int? offset = null, IDictionary<string, bool> order = null)
		{
			return (locator ?? Static.Locator).Resolve<Revenj.IDomainProxy>().Search(this, limit, offset, order).Result;
		}
	}

	}

}
