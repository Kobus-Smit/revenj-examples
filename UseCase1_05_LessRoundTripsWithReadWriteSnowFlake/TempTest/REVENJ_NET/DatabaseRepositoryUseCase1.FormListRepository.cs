
namespace DatabaseRepositoryUseCase1
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

	
	using global::Revenj.DatabasePersistence;
	using global::Revenj.DatabasePersistence.Postgres;
	using global::Revenj.DatabasePersistence.Postgres.Converters;
	using global::Revenj.DatabasePersistence.Postgres.QueryGeneration;


	
	
	internal static class RegisterFormList
	{
		public static void Register(IObjectFactory factory)
		{
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.FormListRepository), InstanceScope.Context, typeof(DatabaseRepositoryUseCase1.FormListRepository), typeof(IQueryableRepository<global::UseCase1.FormList>));
			factory.RegisterFunc<IQueryable<global::UseCase1.FormList>>(f => f.Resolve<IQueryableRepository<global::UseCase1.FormList>>().Query<global::UseCase1.FormList>(null));
			
			
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.FormListRepository), InstanceScope.Context, typeof(IRepository<global::UseCase1.FormList>));
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.FormListRepository), InstanceScope.Context, typeof(Revenj.DatabasePersistence.Postgres.IBulkRepository<global::UseCase1.FormList>));
			factory.RegisterFunc<Func<string, global::UseCase1.FormList>>(f => f.Resolve<IRepository<global::UseCase1.FormList>>().Find);
			factory.RegisterFunc<Func<IEnumerable<string>, global::UseCase1.FormList[]>>(f => f.Resolve<IRepository<global::UseCase1.FormList>>().Find);
			
		}
	}

	
	
	internal partial class FormListRepository : global::Revenj.DomainPatterns.IQueryableRepository<global::UseCase1.FormList>, global::System.IDisposable, global::Revenj.DomainPatterns.IRepository<global::UseCase1.FormList>, global::Revenj.DatabasePersistence.Postgres.IBulkRepository<global::UseCase1.FormList>
	{
		
		private readonly IServiceProvider Locator;
		private readonly IDatabaseQuery DatabaseQuery;
		
		public FormListRepository(IServiceProvider locator, IDatabaseQuery query)
			
		{
			
			
			this.Locator = locator;
			this.DatabaseQuery = query;
			
		}

		
		
		public void Dispose()
		{
			

			
		}

		
		class _FindResult_
		{
			internal readonly Revenj.Utility.ChunkedMemoryStream cms = Common.Utility.UseThreadLocalStream();
			internal global::UseCase1.FormList one;
			internal readonly List<global::UseCase1.FormList> list = new List<global::UseCase1.FormList>();
			private System.IServiceProvider locator;
			internal readonly System.Data.IDbCommand NoTemplateCommand;
			
			internal readonly System.Data.IDbCommand OnePkCommand;
			internal readonly System.Data.IDbCommand InPkCommand;
			internal _FindResult_()
			{
				cms = Common.Utility.UseThreadLocalStream();
				NoTemplateCommand = PostgresCommandFactory.NewCommand(cms);
				
				this.OnePkCommand = PostgresCommandFactory.NewCommand(cms, @"SELECT _r FROM ""UseCase1"".""FormList"" _r WHERE _r.""URI"" = :pk");
				this.InPkCommand = PostgresCommandFactory.NewCommand(cms, @"SELECT _r FROM ""UseCase1"".""FormList"" _r WHERE _r.""URI"" IN (:pks)");
			}

			public void Prepare(System.IServiceProvider locator)
			{
				this.cms.Reset();
				this.locator = locator;
				this.list.Clear();
				this.one = null;
			}

			public global::UseCase1.FormList ExecuteOne(IDatabaseQuery query, System.Data.IDbCommand command)
			{
				this.cms.Position = 0;
				query.Execute(command, CollectOne);
				return one;
			}

			public List<global::UseCase1.FormList> ExecuteAll(IDatabaseQuery query, System.Data.IDbCommand command)
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
					one = _DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator);
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { one = _DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator); }
					finally { _tr.Dispose(); }
				}
			}
			
			internal void CollectAll(System.Data.IDataReader dr)
			{
				var _pg = dr.GetValue(0);
				var _str = _pg as string;
				if (_str != null)
					list.Add(_DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator));
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { list.Add(_DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator)); }
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

		public IQueryable<global::UseCase1.FormList> Query<TCondition>(ISpecification<TCondition> specification)
		{
			if(specification != null && specification.IsSatisfied == null)
				throw new ArgumentException("Search predicate is not specified"); 

			
			
			if(specification != null 
				&& (!typeof(TCondition).IsAssignableFrom(typeof(global::UseCase1.FormList)) && !typeof(TCondition).IsAssignableFrom(typeof(global::UseCase1.Form))))
				throw new ArgumentException("Specification is not compatible");

			IQueryable<global::UseCase1.FormList> data = new Queryable<global::UseCase1.FormList>(new QueryExecutor(DatabaseQuery, Locator));
			bool rewritten = false;

			
			
			if(specification != null && typeof(TCondition).IsAssignableFrom(typeof(global::UseCase1.Form)))
			{
				rewritten = true;
				var entitySpec = specification as ISpecification<global::UseCase1.Form>;
				IQueryable<global::UseCase1.Form> entities = new Queryable<global::UseCase1.Form>(new QueryExecutor(DatabaseQuery, Locator));
				var uris = entitySpec != null
					? entities.Where(entitySpec.IsSatisfied).Select(it => it.URI).Skip(0)
					: entities.Cast<TCondition>().Where(specification.IsSatisfied).Cast<global::UseCase1.Form>().Select(it => it.URI).Skip(0);
				data = data.Where(it => uris.Contains(it.URI));
			}

			if(!rewritten && specification != null)
			{
				var specAsNative = specification as ISpecification<global::UseCase1.FormList>;
				if(specAsNative != null)
					data = data.Where(specAsNative.IsSatisfied);
				else
					data = data.Cast<TCondition>().Where(specification.IsSatisfied).Cast<global::UseCase1.FormList>();
			}
				
			return data.OrderBy(it => it.Name);
		}

		public global::UseCase1.FormList[] Search<TCondition>(ISpecification<TCondition> specification, int? limit, int? offset)
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
				sw.Write(@"SELECT _r FROM ""UseCase1"".""FormList"" _r");
			}
			
			sw.Write(" ORDER BY \"Name\" ASC");
			
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

		public Func<System.Data.IDataReader, int, global::UseCase1.FormList[]> Search(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::UseCase1.FormList> specification, int? limit, int? offset)
		{
			var selectType = "SELECT array_agg(_r) FROM (SELECT _it as _r";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT array_agg(_r) FROM (SELECT _r FROM ""UseCase1"".""FormList"" _r");
			
			else 
			{
				sw.Write("SELECT 0");
				return (dr, ind) => Search(specification, limit, offset);
			}
			sw.Write(" ORDER BY \"Name\" ASC");
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
				List<global::UseCase1.FormList> result;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord);
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
				sw.Write(@"SELECT count(*) FROM ""UseCase1"".""FormList"" r");
			}
			
			else return Query(specification).LongCount();

			sw.Flush();
			cms.Position = 0;
			var com = PostgresCommandFactory.NewCommand(cms); //TODO: sql template
			long total = 0;
			DatabaseQuery.Execute(com, dr => { total = dr.GetInt64(0); });
			return total;
		}

		public Func<System.Data.IDataReader, int, long> Count(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::UseCase1.FormList> specification)
		{
			var selectType = "SELECT count(*)";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT count(*) FROM ""UseCase1"".""FormList"" r");
			
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
				sw.Write(@"SELECT exists(SELECT * FROM ""UseCase1"".""FormList"" r");
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

		public Func<System.Data.IDataReader, int, bool> Exists(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::UseCase1.FormList> specification)
		{
			var selectType = "exists(SELECT *";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"exists(SELECT * FROM ""UseCase1"".""FormList"" r");
			
			else 
			{
				sw.Write("SELECT 0");
				return (dr, ind) => Query(specification).Any();
			}
			sw.Write(')');
			return (dr, ind) => dr.GetBoolean(ind);
		}

		
		public global::UseCase1.FormList Find(string uri)
		{
			if (uri == null) return null;
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var sw = cms.GetWriter();
			sw.Write(@"SELECT _r FROM ""UseCase1"".""FormList"" _r WHERE _r.""URI"" = ");
			PostgresRecordConverter.WriteSimpleUri(sw, uri);
			sw.Flush();
			var result = lookup.ExecuteOne(DatabaseQuery, lookup.OnePkCommand);
			if (!HasCustomSecurity) return result;
			var found = new [] { result };
			
			return found.Length == 1 ? result : null;
		}

		public Func<System.Data.IDataReader, int, global::UseCase1.FormList> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, string uri)
		{
			var sw = query.Writer;
			var cms = query.Stream;
			if (uri == null)
			{
				sw.Write("SELECT 0");
				return (dr, ind) => null;
			}
			sw.Write(@"SELECT _r FROM ""UseCase1"".""FormList"" _r WHERE _r.""URI"" = ");
			if (query.UsePrepared)
			{
				var nextArg = query.GetNextArgument(wr => PostgresRecordConverter.WriteSimpleUri(wr, uri), "text");
				sw.Write(nextArg);
				sw.Write("::text");
			}
			else PostgresRecordConverter.WriteSimpleUri(sw, uri);
			return (dr, ind) => 
			{
				global::UseCase1.FormList result = null;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = _DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, Locator);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = _DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, Locator);
				}
				if (!HasCustomSecurity) return result;
				var found = new [] { result };
				
				return found.Length == 1 ? result : null;
			};
		}

		public global::UseCase1.FormList[] Find(IEnumerable<string> uris)
		{
			var count = uris != null ? uris.Count() : 0;
			var pks = new List<string>(count);
			foreach (var _u in uris ?? new string[0])
				if (_u != null)
					pks.Add(_u);
			if (pks.Count == 0)
				return new global::UseCase1.FormList[0];
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var sw = cms.GetWriter();
			sw.Write(@"SELECT _r FROM ""UseCase1"".""FormList"" _r WHERE _r.""URI"" IN (");
			PostgresRecordConverter.WriteSimpleUriList(sw, pks);
			sw.Write(')');
			sw.Flush();
			var found = lookup.ExecuteAll(DatabaseQuery, lookup.InPkCommand).ToArray();
			
			return found;
		}

		public Func<System.Data.IDataReader, int, global::UseCase1.FormList[]> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, IEnumerable<string> uris)
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
				return (dr, ind) => new global::UseCase1.FormList[0];
			}
			if (query.UsePrepared)
			{
				sw.Write(@"SELECT array_agg(_r) FROM ""UseCase1"".""FormList"" _r WHERE _r.""URI"" = ANY (");
				var nextArg = query.GetNextArgument(wr => 
					{
						wr.Write("ARRAY[");
						PostgresRecordConverter.WriteSimpleUriList(wr, pks);
						wr.Write("]::text[]");
					}, 
					"text[]");
				sw.Write(nextArg);
			}
			else
			{
				sw.Write(@"SELECT array_agg(_r) FROM ""UseCase1"".""FormList"" _r WHERE _r.""URI"" IN (");
				PostgresRecordConverter.WriteSimpleUriList(sw, pks);
				sw.Write(')');
			}
			return (dr, ind) => 
			{
				var result = new List<global::UseCase1.FormList>(pks.Count);
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord));
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.CreateFromRecord));
				}
				var found = result.ToArray();
				
				return found;
			};
		}
	}

}
