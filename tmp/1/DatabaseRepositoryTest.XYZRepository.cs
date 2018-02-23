
namespace DatabaseRepositoryTest
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	
	
	using global::Revenj.Utility;
	using global::System.IO;

	
using global::Revenj;
using global::Revenj.DomainPatterns;
using global::Revenj.Extensibility;

	
	using global::Revenj.DatabasePersistence;
	using global::Revenj.DatabasePersistence.Postgres;
	using global::Revenj.DatabasePersistence.Postgres.Converters;
	using global::Revenj.DatabasePersistence.Postgres.QueryGeneration;


	
	
	internal static class RegisterXYZ
	{
		public static void Register(IObjectFactory factory)
		{
			factory.RegisterType(typeof(DatabaseRepositoryTest.XYZRepository), InstanceScope.Context, typeof(DatabaseRepositoryTest.XYZRepository), typeof(IQueryableRepository<global::Test.XYZ>));
			factory.RegisterFunc<IQueryable<global::Test.XYZ>>(f => f.Resolve<IQueryableRepository<global::Test.XYZ>>().Query<global::Test.XYZ>(null));
			
			
			factory.RegisterType(typeof(DatabaseRepositoryTest.XYZRepository), InstanceScope.Context, typeof(IRepository<global::Test.XYZ>));
			factory.RegisterFunc<Func<string, global::Test.XYZ>>(f => f.Resolve<IRepository<global::Test.XYZ>>().Find);
			factory.RegisterFunc<Func<IEnumerable<string>, global::Test.XYZ[]>>(f => f.Resolve<IRepository<global::Test.XYZ>>().Find);
			
			factory.RegisterType(typeof(DatabaseRepositoryTest.XYZRepository), InstanceScope.Context, typeof(Revenj.DatabasePersistence.Postgres.IBulkRepository<global::Test.XYZ>));
			factory.RegisterType(typeof(DatabaseRepositoryTest.XYZRepository), InstanceScope.Context, typeof(Revenj.DomainPatterns.IPersistableRepository<global::Test.XYZ>));
			factory.RegisterType(typeof(DatabaseRepositoryTest.XYZRepository), InstanceScope.Context, typeof(IPersistableRepository<global::Test.XYZ>));
			factory.RegisterType(typeof(DatabaseRepositoryTest.XYZRepository), InstanceScope.Context, typeof(IAggregateRootRepository<global::Test.XYZ>));
			
		}
	}

	
	
	internal partial class XYZRepository : global::Revenj.DomainPatterns.IQueryableRepository<global::Test.XYZ>, global::System.IDisposable, global::Revenj.DomainPatterns.IRepository<global::Test.XYZ>, global::Revenj.DatabasePersistence.Postgres.IBulkRepository<global::Test.XYZ>, global::Revenj.DomainPatterns.IPersistableRepository<global::Test.XYZ>, global::Revenj.DomainPatterns.IAggregateRootRepository<global::Test.XYZ>
	{
		
		private readonly IServiceProvider Locator;
		private readonly IDatabaseQuery DatabaseQuery;
		
		public XYZRepository(IServiceProvider locator, IDatabaseQuery query, IEagerNotification Notifications, IDataCache<global::Test.XYZ> DataCache)
			
		{
			
			
			this.Locator = locator;
			this.DatabaseQuery = query;
			
			this.Notifications = Notifications;
			
			this.DataCache = DataCache;
			
		}

		
		
		public void Dispose()
		{
			

			
			
			if (!DatabaseQuery.InTransaction)
			{
				NotifyInfo ni;
				while (NotifyQueue.TryDequeue(out ni))
					Notifications.Notify(ni);
			}
		}

		
		class _FindResult_
		{
			internal readonly Revenj.Utility.ChunkedMemoryStream cms = Common.Utility.UseThreadLocalStream();
			internal global::Test.XYZ one;
			internal readonly List<global::Test.XYZ> list = new List<global::Test.XYZ>();
			private System.IServiceProvider locator;
			internal readonly System.Data.IDbCommand NoTemplateCommand;
			
			internal readonly System.Data.IDbCommand RichFind;
			internal readonly System.Data.IDbCommand RichFindAll;
			internal _FindResult_()
			{
				cms = Common.Utility.UseThreadLocalStream();
				NoTemplateCommand = PostgresCommandFactory.NewCommand(cms);
				
				this.RichFind = PostgresCommandFactory.PreparedCommand(cms, "FS-Test-XYZ", @"SELECT _r FROM ""Test"".""XYZ_entity"" _r WHERE _r.""ID"" = $1", "int4");
				this.RichFindAll = PostgresCommandFactory.PreparedCommand(cms, "FM-Test-XYZ", @"SELECT _r FROM ""Test"".""XYZ_entity"" _r WHERE _r.""ID"" = ANY($1)", "int4[]");
			}

			public void Prepare(System.IServiceProvider locator)
			{
				this.cms.Reset();
				this.locator = locator;
				this.list.Clear();
				this.one = null;
			}

			public global::Test.XYZ ExecuteOne(IDatabaseQuery query, System.Data.IDbCommand command)
			{
				this.cms.Position = 0;
				query.Execute(command, CollectOne);
				return one;
			}

			public List<global::Test.XYZ> ExecuteAll(IDatabaseQuery query, System.Data.IDbCommand command)
			{
				this.cms.Position = 0;
				query.Execute(command, CollectAll);
				return list;
			}
			
			internal void CollectOne(System.Data.IDataReader dr)
			{
				var _pg = dr.GetValue(0);
				var _str = _pg as string;
				if (_str != null)
					one = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator);
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { one = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator); }
					finally { _tr.Dispose(); }
				}
			}
			
			internal void CollectAll(System.Data.IDataReader dr)
			{
				var _pg = dr.GetValue(0);
				var _str = _pg as string;
				if (_str != null)
					list.Add(_DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator));
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { list.Add(_DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator)); }
					finally { _tr.Dispose(); }
				}
			}
		}
		private static readonly System.Threading.ThreadLocal<_FindResult_> ThreadLocalFind = new System.Threading.ThreadLocal<_FindResult_>(() => new _FindResult_());
		private static _FindResult_ PrepareLocalFind(System.IServiceProvider locator) 
		{
			var tlf = ThreadLocalFind.Value;
			tlf.Prepare(locator);
			return tlf;
		}

		private static readonly bool HasCustomSecurity = false;

		public IQueryable<global::Test.XYZ> Query<TCondition>(ISpecification<TCondition> specification)
		{
			if(specification != null && specification.IsSatisfied == null)
				throw new ArgumentException("Search predicate is not specified"); 
			if(specification != null && !typeof(TCondition).IsAssignableFrom(typeof(global::Test.XYZ)))
				throw new ArgumentException("Specification is not compatible");

			

			IQueryable<global::Test.XYZ> data = new Queryable<global::Test.XYZ>(new QueryExecutor(DatabaseQuery, Locator));
			bool rewritten = false;

			

			if(!rewritten && specification != null)
			{
				var specAsNative = specification as ISpecification<global::Test.XYZ>;
				if(specAsNative != null)
					data = data.Where(specAsNative.IsSatisfied);
				else
					data = data.Cast<TCondition>().Where(specification.IsSatisfied).Cast<global::Test.XYZ>();
			}
				
			return data;
		}

		public global::Test.XYZ[] Search<TCondition>(ISpecification<TCondition> specification, int? limit, int? offset)
		{
			

			Revenj.Utility.ChunkedMemoryStream cms = null;
			System.IO.TextWriter sw = null;
			var selectType = "SELECT _it";
			var lookup = PrepareLocalFind(Locator);
			var result = lookup.list;

			if (specification == null)
			{
				cms = lookup.cms;
				sw = cms.GetWriter();
				sw.Write(@"SELECT _r FROM ""Test"".""XYZ_entity"" _r");
			}
			
			
			else if (specification is global::Test.XYZ.FindBy)
			{
				var spec = specification as global::Test.XYZ.FindBy;
				cms = Common.Utility.UseThreadLocalStream();
				sw = cms.GetWriter();
				sw.Write(selectType);
				sw.Write(@" FROM ""Test"".""XYZ.FindBy""(");
				
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.from).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					sw.Write('\'');
				sw.Write(") _it");
			}
			
			if(cms == null)
			{
				var query = Query(specification);
				if (limit != null && limit.Value >= 0)
					query = query.Take(limit.Value);
				if (offset != null && offset.Value >= 0)
					query = query.Skip(offset.Value);
				result.AddRange(query);
			}
			else
			{
				//TODO: dynamic security
				if (limit != null && limit.Value >= 0)
				{
					sw.Write(" LIMIT ");
					sw.Write(limit.Value);
				}
				if (offset != null && offset.Value >= 0)
				{
					sw.Write(" OFFSET ");
					sw.Write(offset.Value);
				}
				sw.Flush();
				lookup.ExecuteAll(DatabaseQuery, lookup.NoTemplateCommand);
			}

			var found = result.ToArray();
			
			return found;
		}

		public Func<System.Data.IDataReader, int, global::Test.XYZ[]> Search(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::Test.XYZ> specification, int? limit, int? offset)
		{
			var selectType = "SELECT array_agg(_r) FROM (SELECT _it as _r";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT array_agg(_r) FROM (SELECT _r FROM ""Test"".""XYZ_entity"" _r");
			
			
			else if (specification is global::Test.XYZ.FindBy)
			{
				var spec = specification as global::Test.XYZ.FindBy;
				sw.Write(selectType);
				sw.Write(@" FROM ""Test"".""XYZ.FindBy""(");
				if (query.UsePrepared)
				{
					sw.Write(query.GetNextArgument(tw => 
					{
						
					tw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.from).InsertRecord(tw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					tw.Write('\'');
						tw.Write("::varchar");
					}, 
					"varchar"));
				}
				else 
				{
					
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.from).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					sw.Write('\'');
				}
				sw.Write(") _it");
			}
			else 
			{
				sw.Write("SELECT 0");
				return (dr, ind) => Search(specification, limit, offset);
			}
			if (limit != null && limit.Value >= 0)
			{
				sw.Write(" LIMIT ");
				sw.Write(limit.Value);
			}
			if (offset != null && offset.Value >= 0)
			{
				sw.Write(" OFFSET ");
				sw.Write(offset.Value);
			}
			sw.Write(@") _sq");
			return (dr, ind) => 
			{
				List<global::Test.XYZ> result;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord);
				}
				var found = result.ToArray();
				
				return found;
			};
		}

		public long Count<TCondition>(ISpecification<TCondition> specification)
		{
			

			Revenj.Utility.ChunkedMemoryStream cms = null;
			System.IO.TextWriter sw = null;
			var selectType = "SELECT count(*)";

			if (specification == null)
			{
				cms = Common.Utility.UseThreadLocalStream();
				sw = cms.GetWriter();
				sw.Write(@"SELECT count(*) FROM ""Test"".""XYZ_entity"" r");
			}
			
			
			else if (specification is global::Test.XYZ.FindBy)
			{
				var spec = specification as global::Test.XYZ.FindBy;
				cms = Common.Utility.UseThreadLocalStream();
				sw = cms.GetWriter();
				sw.Write(selectType);
				sw.Write(@" FROM ""Test"".""XYZ.FindBy""(");
				
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.from).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					sw.Write('\'');
				sw.Write(") _it");
			}
			else return Query(specification).LongCount();

			sw.Flush();
			cms.Position = 0;
			var com = PostgresCommandFactory.NewCommand(cms); //TODO: sql template
			long total = 0;
			DatabaseQuery.Execute(com, dr => { total = dr.GetInt64(0); });
			return total;
		}

		public Func<System.Data.IDataReader, int, long> Count(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::Test.XYZ> specification)
		{
			var selectType = "SELECT count(*)";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT count(*) FROM ""Test"".""XYZ_entity"" r");
			
			
			else if (specification is global::Test.XYZ.FindBy)
			{
				var spec = specification as global::Test.XYZ.FindBy;
				sw.Write(selectType);
				sw.Write(@" FROM ""Test"".""XYZ.FindBy""(");
				if (query.UsePrepared)
				{
					sw.Write(query.GetNextArgument(tw => 
					{
						
					tw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.from).InsertRecord(tw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					tw.Write('\'');
						tw.Write("::varchar");
					}, 
					"varchar"));
				}
				else 
				{
					
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.from).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					sw.Write('\'');
				}
				sw.Write(") _it");
			}
			else 
			{
				sw.Write("SELECT 0");
				return (dr, ind) => Query(specification).LongCount();
			}
			return (dr, ind) => dr.GetInt64(ind);
		}

		public bool Exists<TCondition>(ISpecification<TCondition> specification)
		{
			

			Revenj.Utility.ChunkedMemoryStream cms = null;
			System.IO.TextWriter sw = null;
			var selectType = "SELECT exists(SELECT *";

			if (specification == null)
			{
				cms = Common.Utility.UseThreadLocalStream();
				sw = cms.GetWriter();
				sw.Write(@"SELECT exists(SELECT * FROM ""Test"".""XYZ_entity"" r");
			}
			
			
			else if (specification is global::Test.XYZ.FindBy)
			{
				var spec = specification as global::Test.XYZ.FindBy;
				cms = Common.Utility.UseThreadLocalStream();
				sw = cms.GetWriter();
				sw.Write(selectType);
				sw.Write(@" FROM ""Test"".""XYZ.FindBy""(");
				
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.from).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					sw.Write('\'');
				sw.Write(") _it");
			}
			else return Query(specification).Any();

			sw.Write(')');
			sw.Flush();
			cms.Position = 0;
			var com = PostgresCommandFactory.NewCommand(cms); //TODO: sql template
			bool found = false;
			DatabaseQuery.Execute(com, dr => { found = dr.GetBoolean(0); });
			return found;
		}

		public Func<System.Data.IDataReader, int, bool> Exists(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::Test.XYZ> specification)
		{
			var selectType = "exists(SELECT *";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"exists(SELECT * FROM ""Test"".""XYZ_entity"" r");
			
			
			else if (specification is global::Test.XYZ.FindBy)
			{
				var spec = specification as global::Test.XYZ.FindBy;
				sw.Write(selectType);
				sw.Write(@" FROM ""Test"".""XYZ.FindBy""(");
				if (query.UsePrepared)
				{
					sw.Write(query.GetNextArgument(tw => 
					{
						
					tw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.from).InsertRecord(tw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					tw.Write('\'');
						tw.Write("::varchar");
					}, 
					"varchar"));
				}
				else 
				{
					
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.from).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					sw.Write('\'');
				}
				sw.Write(") _it");
			}
			else 
			{
				sw.Write("SELECT 0");
				return (dr, ind) => Query(specification).Any();
			}
			sw.Write(')');
			return (dr, ind) => dr.GetBoolean(ind);
		}

		
		public global::Test.XYZ Find(string uri)
		{
			if (uri == null) return null;
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var sw = cms.GetWriter();
			sw.Write(@"EXECUTE ""FS-Test-XYZ""(");
				PostgresRecordConverter.WriteSimpleUri(sw, uri);
				sw.Write("::int4)");
				sw.Flush();
				lookup.ExecuteOne(DatabaseQuery, lookup.RichFind);
			var result = lookup.one;
			if (!HasCustomSecurity) return result;
			var found = new [] { result };
			
			return found.Length == 1 ? result : null;
		}

		public Func<System.Data.IDataReader, int, global::Test.XYZ> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, string uri)
		{
			var sw = query.Writer;
			var cms = query.Stream;
			if (uri == null)
			{
				sw.Write("SELECT 0");
				return (dr, ind) => null;
			}
			sw.Write(@"SELECT _r FROM ""Test"".""XYZ_entity"" _r WHERE _r.""ID"" = ");
				if (query.UsePrepared)
				{
					var nextArg = query.GetNextArgument(wr => 
						{
							PostgresRecordConverter.WriteSimpleUri(wr, uri);
							wr.Write("::int4");
						},
						"int4");
					sw.Write(nextArg);
				}
				else PostgresRecordConverter.WriteSimpleUri(sw, uri);
			return (dr, ind) => 
			{
				global::Test.XYZ result = null;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, Locator);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, Locator);
				}
				if (!HasCustomSecurity) return result;
				var found = new [] { result };
				
				return found.Length == 1 ? result : null;
			};
		}

		public global::Test.XYZ[] Find(IEnumerable<string> uris)
		{
			var count = uris != null ? uris.Count() : 0;
			var pks = new List<string>(count);
			foreach (var _u in uris ?? new string[0])
				if (_u != null)
					pks.Add(_u);
			if (pks.Count == 0)
				return new global::Test.XYZ[0];
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var result = lookup.list;
			var sw = cms.GetWriter();
			sw.Write(@"EXECUTE ""FM-Test-XYZ""(ARRAY[");
				PostgresRecordConverter.WriteSimpleUriList(sw, pks);
				sw.Write("]::int4[])");
				sw.Flush();
				lookup.ExecuteAll(DatabaseQuery, lookup.RichFindAll);
			var found = result.ToArray();
			
			return found;
		}

		public Func<System.Data.IDataReader, int, global::Test.XYZ[]> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, IEnumerable<string> uris)
		{
			var sw = query.Writer;
			var cms = query.Stream;
			var count = uris != null ? uris.Count() : 0;
			var pks = new List<string>(count);
			foreach (var _u in uris ?? new string[0])
				if (_u != null)
					pks.Add(_u);
			if (pks.Count == 0)
			{
				sw.Write("SELECT 0");
				return (dr, ind) => new global::Test.XYZ[0];
			}
			
				if (query.UsePrepared)
				{
					sw.Write(@"SELECT array_agg(_r) FROM ""Test"".""XYZ_entity"" _r WHERE _r.""ID"" = ANY(");
					var nextArg = query.GetNextArgument(wr => 
						{
							wr.Write("ARRAY[");
							PostgresRecordConverter.WriteSimpleUriList(wr, pks);
							wr.Write("]::int4[]");
						}, 
						"int4[]");
					sw.Write(nextArg);
					sw.Write(')');
				}
				else
				{
					sw.Write(@"SELECT array_agg(_r) FROM ""Test"".""XYZ_entity"" _r WHERE _r.""ID"" IN (");
					PostgresRecordConverter.WriteSimpleUriList(sw, pks);
					sw.Write(')');
				}
			return (dr, ind) => 
			{
				var result = new List<global::Test.XYZ>(pks.Count);
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord));
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateFromRecord));
				}
				var found = result.ToArray();
				
				return found;
			};
		}
		
		private readonly System.Collections.Concurrent.ConcurrentQueue<NotifyInfo> NotifyQueue = new System.Collections.Concurrent.ConcurrentQueue<NotifyInfo>();
		private readonly IEagerNotification Notifications;
		private readonly IDataCache<global::Test.XYZ> DataCache;
		
		public string[] Persist(IEnumerable<global::Test.XYZ> insert, IEnumerable<KeyValuePair<global::Test.XYZ, global::Test.XYZ>> update, IEnumerable<global::Test.XYZ> delete)
		{
			var insertedData = insert != null ? insert.ToArray() : new global::Test.XYZ[0];
			var updatedData = update != null ? update.ToList() : new List<KeyValuePair<global::Test.XYZ, global::Test.XYZ>>();
			var deletedData = delete != null ? delete.ToArray() : new global::Test.XYZ[0];

			if(insertedData.Length == 0 && updatedData.Count == 0 && deletedData.Length == 0)
				return new string[0];

			if (updatedData.Count > 0 && updatedData.Any(it => it.Key == null))
			{
				//TODO fetch only null values
				var oldValues = Find(updatedData.Select(it => it.Value.URI)).ToDictionary(it => it.URI);
				if (oldValues.Count != updatedData.Count)
					throw new ArgumentException("Can't find update value. Requested: {0}, found: {1}. Missing URI: {2}".With(
						updatedData.Count,
						oldValues.Count,
						string.Join(", ", updatedData.Select(it => it.Value.URI).Except(oldValues.Keys))));
				global::Test.XYZ _val;
				for(int i = 0; i < updatedData.Count; i++)
				{
					_val = updatedData[i].Value;
					updatedData[i] = new KeyValuePair<global::Test.XYZ, global::Test.XYZ>(oldValues[_val.URI], _val);
				}
			}

			updatedData.RemoveAll(kv => kv.Key.Equals(kv.Value));

			var cms = Common.Utility.UseThreadLocalStream();

			
			DatabaseQuery.Fill<global::Test.XYZ, int>(insertedData, @"nextval('""Test"".""XYZ_ID_seq""'::regclass)::int", (it, seq) => it.ID = seq);

			for(int i = 0; i < insertedData.Length; i++)
				insertedData[i].__InternalPrepareInsert();
			foreach(var it in updatedData)
				it.Value.__InternalPrepareUpdate();
			for(int i = 0; i < deletedData.Length; i++)
				deletedData[i].__InternalPrepareDelete();

			for(int i = 0; i < insertedData.Length; i++)
			{
				var it = insertedData[i];
				
				it.URI = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.BuildURI(cms.CharBuffer, it.ID);
			}
			foreach(var kv in updatedData)
			{
				
				kv.Value.URI = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.BuildURI(cms.CharBuffer, kv.Value.ID);
			}


			_InternalDoPersist(cms, insertedData, updatedData, deletedData);
			var resultURI = new string[insertedData.Length];
			for(int i = 0; i < resultURI.Length; i++)
				resultURI[i] = insertedData[i].URI;

			
			if (DatabaseQuery.InTransaction)
			{
				if (insertedData.Length > 0) NotifyQueue.Enqueue(new NotifyInfo("Test.XYZ", NotifyInfo.OperationEnum.Insert, resultURI));
				if (updatedData.Count > 0) 
				{
					NotifyQueue.Enqueue(new NotifyInfo("Test.XYZ", NotifyInfo.OperationEnum.Update, updatedData.Select(it => it.Key.URI).ToArray()));
					if (updatedData.Any(kv => kv.Key.URI != kv.Value.URI)) NotifyQueue.Enqueue(new NotifyInfo("Test.XYZ", NotifyInfo.OperationEnum.Change, updatedData.Where(kv => kv.Key.URI != kv.Value.URI).Select(it => it.Value.URI).ToArray()));
				}
				if (deletedData.Length > 0) NotifyQueue.Enqueue(new NotifyInfo("Test.XYZ", NotifyInfo.OperationEnum.Delete, deletedData.Select(it => it.URI).ToArray()));
			}
			else
			{
				if (insertedData.Length > 0) Notifications.Notify(new NotifyInfo("Test.XYZ", NotifyInfo.OperationEnum.Insert, resultURI));
				if (updatedData.Count > 0) 
				{
					Notifications.Notify(new NotifyInfo("Test.XYZ", NotifyInfo.OperationEnum.Update, updatedData.Select(it => it.Key.URI).ToArray()));
					if (updatedData.Any(kv => kv.Key.URI != kv.Value.URI)) Notifications.Notify(new NotifyInfo("Test.XYZ", NotifyInfo.OperationEnum.Change, updatedData.Where(kv => kv.Key.URI != kv.Value.URI).Select(it => it.Value.URI).ToArray()));
				}
				if (deletedData.Length > 0) Notifications.Notify(new NotifyInfo("Test.XYZ", NotifyInfo.OperationEnum.Delete, deletedData.Select(it => it.URI).ToArray()));
			}
			DataCache.Invalidate(updatedData.Select(it => it.Key.URI).Union(deletedData.Select(it => it.URI)));

			return resultURI;
		}

		
		private void _InternalDoPersist(Revenj.Utility.ChunkedMemoryStream cms, global::Test.XYZ[] insertedData, List<KeyValuePair<global::Test.XYZ, global::Test.XYZ>> updatedData, global::Test.XYZ[] deletedData)
		{
			var sw = cms.GetWriter();
			if (insertedData.Length == 1 && updatedData.Count == 0 && deletedData.Length == 0)
			{
				sw.Write("/*NO LOAD BALANCE*/SELECT \"Test\".\"insert_XYZ\"(ARRAY['");
				_DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateTupleFrom(insertedData[0]).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""Test"".""XYZ_entity""])");

				

				sw.Flush();
				cms.Position = 0;
				var com = PostgresCommandFactory.NewCommand(cms, "SELECT \"Test\".\"insert_XYZ\"(:insert)");
				DatabaseQuery.Execute(com);
			}
			else if (insertedData.Length == 0 && updatedData.Count == 1 && deletedData.Length == 0)
			{
				sw.Write("/*NO LOAD BALANCE*/SELECT \"Test\".\"update_XYZ\"(ARRAY['");
				_DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateRecordTupleFrom(updatedData[0].Key, _DatabaseCommon.FactoryTest_XYZ.XYZConverter.PrimaryKeyUpdateTuples).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""Test"".""XYZ_entity""],ARRAY['");
				_DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateTupleFrom(updatedData[0].Value).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""Test"".""XYZ_entity""]");

				

				sw.Write(')');

				

				sw.Flush();
				cms.Position = 0;
				var com = PostgresCommandFactory.NewCommand(cms, "SELECT \"Test\".\"update_XYZ\"(:old_record,:new_record)");
				string _sqlError = null;
				DatabaseQuery.Execute(com, dr => _sqlError = dr.GetString(0));
				if (_sqlError != null)
					throw new PostgresException(_sqlError);
			}
			else
			{
				sw.Write("/*NO LOAD BALANCE*/SELECT \"Test\".\"persist_XYZ\"('");
				var arr = new IPostgresTuple[insertedData.Length];
				for (int i = 0; i < insertedData.Length; i++)
					arr[i] = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateTupleFrom(insertedData[i]);
				ArrayTuple.From(arr).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""Test"".""XYZ_entity""[],'");
				arr = new IPostgresTuple[updatedData.Count];
				for (int i = 0; i < updatedData.Count; i++)
					arr[i] = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateRecordTupleFrom(updatedData[i].Key, _DatabaseCommon.FactoryTest_XYZ.XYZConverter.PrimaryKeyUpdateTuples);
				ArrayTuple.From(arr).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""Test"".""XYZ_entity""[],'");
				for (int i = 0; i < updatedData.Count; i++)
					arr[i] = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateTupleFrom(updatedData[i].Value);
				ArrayTuple.From(arr).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""Test"".""XYZ_entity""[],'");
				arr = new IPostgresTuple[deletedData.Length];
				for (int i = 0; i < deletedData.Length; i++)
					arr[i] = _DatabaseCommon.FactoryTest_XYZ.XYZConverter.CreateRecordTupleFrom(deletedData[i], _DatabaseCommon.FactoryTest_XYZ.XYZConverter.PrimaryKeyDeleteTuples);
				ArrayTuple.From(arr).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""Test"".""XYZ_entity""[]");

				

				sw.Write(")");

				

				sw.Flush();
				cms.Position = 0;
				var com = PostgresCommandFactory.NewCommand(cms, "SELECT \"Test\".\"persist_XYZ\"(:insert,:update_pairs,:delete)");
				string _sqlError = null;
				DatabaseQuery.Execute(com, dr => _sqlError = dr.GetString(0));
				if (_sqlError != null)
					throw new PostgresException(_sqlError);
			}
			
			foreach(var item in insertedData)
				item.__ResetChangeTracking();
			foreach(var item in updatedData)
				item.Value.__ResetChangeTracking();
		}

		
		global::Test.XYZ[] IAggregateRootRepository<global::Test.XYZ>.Create(int count, Action<global::Test.XYZ[]> initialize)
		{
			if(count < 0)
				throw new ArgumentException("count must be positive: Provided value " + count);
			var roots = new global::Test.XYZ[count];
			for(int i = 0; i < count; i++)
				roots[i] = new global::Test.XYZ();
			if(initialize != null)
				initialize(roots);
			Persist(roots, null, null);
			return roots;
		}

		global::Test.XYZ[] IAggregateRootRepository<global::Test.XYZ>.Update(string[] uris, Action<global::Test.XYZ[]> change)
		{
			var roots = Find(uris);
			if(roots.Length != uris.Length)
				throw new ArgumentException("Can't find Test.XYZ with uri: ".With(string.Join(", ", uris)));
			if(change != null)
			{
				var originals = roots.Select(it => it.Clone()).ToDictionary(it => it.URI);
				change(roots);
				Persist(null, roots.Select(it => new KeyValuePair<global::Test.XYZ, global::Test.XYZ>(originals[it.URI], it)).ToList(), null);
			}
			return roots;
		}

		void IAggregateRootRepository<global::Test.XYZ>.Delete(string[] uris)
		{
			var roots = Find(uris);
			if(roots.Length != uris.Length)
				throw new ArgumentException("Can't find Test.XYZ with uri: ".With(string.Join(", ", uris)));
			Persist(null, null, roots);
		}

		IQueryable<global::Test.XYZ> IQueryableRepository<global::Test.XYZ>.Query<TCondition>(ISpecification<TCondition> specification)
		{
			return Query(specification);
		}

		global::Test.XYZ[] IQueryableRepository<global::Test.XYZ>.Search<TCondition>(ISpecification<TCondition> specification, int? limit, int? offset)
		{
			return Search(specification, limit, offset);
		}

		global::Test.XYZ[] IRepository<global::Test.XYZ>.Find(IEnumerable<string> uris) { return Find(uris); }

		
		public global::Test.XYZ Find(int id)
		{
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var sw = cms.GetWriter();
			sw.Write(@"EXECUTE ""FS-Test-XYZ""(");
			sw.Write(id);
			sw.Write("::int4)");
			sw.Flush();
			var result = lookup.ExecuteOne(DatabaseQuery, lookup.RichFind);
			if (!HasCustomSecurity) return result;
			var found = new [] { result };
			
			return found.Length == 1 ? result : null;
		}
	}

}
