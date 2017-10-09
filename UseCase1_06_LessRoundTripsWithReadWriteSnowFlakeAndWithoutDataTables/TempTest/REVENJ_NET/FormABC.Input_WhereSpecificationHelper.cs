
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


	
	
	
	public static partial class Input_WhereSpecificationHelper 
	{
		
		
		public static IQueryable<global::FormABC.Input> Where(this IQueryableRepository<global::FormABC.Input> repository, string submissionURI)
		{
			return repository.Query(new global::FormABC.Input.Where(submissionURI: submissionURI));
		}
	
	}

}
