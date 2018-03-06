
namespace Test
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


	
	
	
	public static partial class XYZ_FindBySpecificationHelper 
	{
		
		
		public static IQueryable<global::Test.XYZ> FindBy(this IQueryableRepository<global::Test.XYZ> repository, string from)
		{
			return repository.Query(new global::Test.XYZ.FindBy(from: from));
		}
	
	}

}
