
namespace _DatabaseConfiguration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	internal partial class DatabaseConverters 
	{
		
		
		
		internal static void Initialize(System.Data.DataTable columnsInfo)
		{
			

			System.Data.DataRow row = null;
			_DatabaseCommon.FactoryTest_XYZ.XYZConverter.InitializeProperties(columnsInfo);
		}

	}

}
