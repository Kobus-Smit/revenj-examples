
namespace SystemBoot
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	
	using global::Revenj.DatabasePersistence.Postgres.Converters;

	using global::Revenj.DatabasePersistence.Postgres;

	using global::Revenj.DatabasePersistence;

	using global::System.Data;

	
using global::Revenj;
using global::Revenj.DomainPatterns;
using global::Revenj.Extensibility;


	
	
	public class Configuration : ISystemAspect
	{
		public void Initialize(IObjectFactory factory)
		{
			
			
			{
				var dbTranConf = factory.Resolve<IDatabaseQueryManager>();
				var dbQuery = dbTranConf.CreateQuery();
				DataTable columnsInfo;
				try { columnsInfo = dbQuery.Fill(@"SELECT * FROM ""-DSL-"".Load_Type_Info()"); } 
				catch { columnsInfo = dbQuery.Fill(@"SELECT 
	ns.nspname::varchar as type_schema, 
	cl.relname::varchar as type_name, 
	atr.attname::varchar as column_name, 
	ns_ref.nspname::varchar as column_schema,
	typ.typname::varchar as column_type, 
	(SELECT COUNT(*) + 1
	FROM pg_attribute atr_ord
	WHERE 
		atr.attrelid = atr_ord.attrelid
		AND atr_ord.attisdropped = false
		AND atr_ord.attnum > 0
		AND atr_ord.attnum < atr.attnum)::smallint as column_index, 
	atr.attnotnull as is_not_null,
	coalesce(d.description LIKE 'NGS generated%', false) as is_ngs_generated
FROM 
	pg_attribute atr
	INNER JOIN pg_class cl ON atr.attrelid = cl.oid
	INNER JOIN pg_namespace ns ON cl.relnamespace = ns.oid
	INNER JOIN pg_type typ ON atr.atttypid = typ.oid
	INNER JOIN pg_namespace ns_ref ON typ.typnamespace = ns_ref.oid
	LEFT JOIN pg_description d ON d.objoid = cl.oid
								AND d.objsubid = atr.attnum
WHERE
	(cl.relkind = 'r' OR cl.relkind = 'v' OR cl.relkind = 'c')
	AND ns.nspname NOT LIKE 'pg_%'
	AND ns.nspname != 'information_schema'
	AND atr.attnum > 0
	AND atr.attisdropped = FALSE
ORDER BY 1, 2, 6"); }
				columnsInfo.CaseSensitive = true;
				columnsInfo.PrimaryKey = new[] { columnsInfo.Columns[0], columnsInfo.Columns[1], columnsInfo.Columns[2] };
				_DatabaseConfiguration.DatabaseConverters.Initialize(columnsInfo);
				dbTranConf.EndQuery(dbQuery, false);
			}
			var postgresConverter = factory.Resolve<IPostgresConverterRepository>();
			postgresConverter.RegisterConverter(typeof(global::Test.XYZ), new _DatabaseCommon.FactoryTest_XYZ.XYZConverter());
			DatabaseRepositoryTest.RegisterXYZ.Register(factory);
		}
	}

}
