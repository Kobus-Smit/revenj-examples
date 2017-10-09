
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


	
	
	
	public static partial class SelectedSubmission_WhereSpecificationHelper 
	{
		
		
		public static IQueryable<global::UseCase1.SelectedSubmission> Where(this IQueryableRepository<global::UseCase1.SelectedSubmission> repository, string uri)
		{
			return repository.Query(new global::UseCase1.SelectedSubmission.Where(uri: uri));
		}
	
	}

}
