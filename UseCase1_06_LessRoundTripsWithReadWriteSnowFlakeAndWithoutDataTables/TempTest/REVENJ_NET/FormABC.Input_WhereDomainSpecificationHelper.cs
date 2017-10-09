
namespace FormABC
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	public static partial class Input_WhereDomainSpecificationHelper 
	{
		
		
		
		[Revenj.DatabasePersistence.Postgres.DatabaseFunction("\"FormABC\".\"Input.Where\"", typeof(Revenj.DatabasePersistence.Postgres.Plugins.ExpressionSupport.DatabaseSpecificationFunctions))]
		public static bool Where(this global::FormABC.Input domainObject, string submissionURI)
		{
			var specification = new global::FormABC.Input.Where(submissionURI: submissionURI);
			return specification._HelperFunctionIsSatisfiedBy(domainObject);
		}
	
	}

}
