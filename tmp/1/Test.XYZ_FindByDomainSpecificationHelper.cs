
namespace Test
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	public static partial class XYZ_FindByDomainSpecificationHelper 
	{
		
		
		
		[Revenj.DatabasePersistence.Postgres.DatabaseFunction("\"Test\".\"XYZ.FindBy\"", typeof(Revenj.DatabasePersistence.Postgres.Plugins.ExpressionSupport.DatabaseSpecificationFunctions))]
		public static bool FindBy(this global::Test.XYZ domainObject, string from)
		{
			var specification = new global::Test.XYZ.FindBy(from: from);
			return specification._HelperFunctionIsSatisfiedBy(domainObject);
		}
	
	}

}
