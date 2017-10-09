
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	public static partial class SelectedSubmission_WhereDomainSpecificationHelper 
	{
		
		
		
		[Revenj.DatabasePersistence.Postgres.DatabaseFunction("\"UseCase1\".\"SelectedSubmission.Where\"", typeof(Revenj.DatabasePersistence.Postgres.Plugins.ExpressionSupport.DatabaseSpecificationFunctions))]
		public static bool Where(this global::UseCase1.SelectedSubmission domainObject, string uri)
		{
			var specification = new global::UseCase1.SelectedSubmission.Where(uri: uri);
			return specification._HelperFunctionIsSatisfiedBy(domainObject);
		}
	
	}

}
