
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


	
	
	internal static class RegisterSelectedSubmission
	{
		public static void Register(IObjectFactory factory)
		{
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.SelectedSubmissionRepository), InstanceScope.Context, typeof(DatabaseRepositoryUseCase1.SelectedSubmissionRepository), typeof(IQueryableRepository<global::UseCase1.SelectedSubmission>));
			factory.RegisterFunc<IQueryable<global::UseCase1.SelectedSubmission>>(f => f.Resolve<IQueryableRepository<global::UseCase1.SelectedSubmission>>().Query<global::UseCase1.SelectedSubmission>(null));
			
			
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.SelectedSubmissionRepository), InstanceScope.Context, typeof(IRepository<global::UseCase1.SelectedSubmission>));
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.SelectedSubmissionRepository), InstanceScope.Context, typeof(Revenj.DatabasePersistence.Postgres.IBulkRepository<global::UseCase1.SelectedSubmission>));
			factory.RegisterFunc<Func<string, global::UseCase1.SelectedSubmission>>(f => f.Resolve<IRepository<global::UseCase1.SelectedSubmission>>().Find);
			factory.RegisterFunc<Func<IEnumerable<string>, global::UseCase1.SelectedSubmission[]>>(f => f.Resolve<IRepository<global::UseCase1.SelectedSubmission>>().Find);
			
		}
	}

	
	
	internal partial class SelectedSubmissionRepository : global::Revenj.DomainPatterns.IQueryableRepository<global::UseCase1.SelectedSubmission>, global::System.IDisposable, global::Revenj.DomainPatterns.IRepository<global::UseCase1.SelectedSubmission>, global::Revenj.DatabasePersistence.Postgres.IBulkRepository<global::UseCase1.SelectedSubmission>
	{
		
		private readonly IServiceProvider Locator;
		private readonly IDatabaseQuery DatabaseQuery;
		
		public SelectedSubmissionRepository(IServiceProvider locator, IDatabaseQuery query)
			
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
			internal global::UseCase1.SelectedSubmission one;
			internal readonly List<global::UseCase1.SelectedSubmission> list = new List<global::UseCase1.SelectedSubmission>();
			private System.IServiceProvider locator;
			internal readonly System.Data.IDbCommand NoTemplateCommand;
			
			internal readonly System.Data.IDbCommand OnePkCommand;
			internal readonly System.Data.IDbCommand InPkCommand;
			internal _FindResult_()
			{
				cms = Common.Utility.UseThreadLocalStream();
				NoTemplateCommand = PostgresCommandFactory.NewCommand(cms);
				
				this.OnePkCommand = PostgresCommandFactory.NewCommand(cms, @"SELECT _r FROM ""UseCase1"".""SelectedSubmission"" _r WHERE _r.""URI"" = :pk");
				this.InPkCommand = PostgresCommandFactory.NewCommand(cms, @"SELECT _r FROM ""UseCase1"".""SelectedSubmission"" _r WHERE _r.""URI"" IN (:pks)");
			}

			public void Prepare(System.IServiceProvider locator)
			{
				this.cms.Reset();
				this.locator = locator;
				this.list.Clear();
				this.one = null;
			}

			public global::UseCase1.SelectedSubmission ExecuteOne(IDatabaseQuery query, System.Data.IDbCommand command)
			{
				this.cms.Position = 0;
				query.Execute(command, CollectOne);
				return one;
			}

			public List<global::UseCase1.SelectedSubmission> ExecuteAll(IDatabaseQuery query, System.Data.IDbCommand command)
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
					one = _DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator);
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { one = _DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator); }
					finally { _tr.Dispose(); }
				}
			}
			
			internal void CollectAll(System.Data.IDataReader dr)
			{
				var _pg = dr.GetValue(0);
				var _str = _pg as string;
				if (_str != null)
					list.Add(_DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator));
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { list.Add(_DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator)); }
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

		public IQueryable<global::UseCase1.SelectedSubmission> Query<TCondition>(ISpecification<TCondition> specification)
		{
			if(specification != null && specification.IsSatisfied == null)
				throw new ArgumentException("Search predicate is not specified"); 

			
			
			if(specification != null 
				&& (!typeof(TCondition).IsAssignableFrom(typeof(global::UseCase1.SelectedSubmission)) && !typeof(TCondition).IsAssignableFrom(typeof(global::UseCase1.Submission))))
				throw new ArgumentException("Specification is not compatible");

			IQueryable<global::UseCase1.SelectedSubmission> data = new Queryable<global::UseCase1.SelectedSubmission>(new QueryExecutor(DatabaseQuery, Locator));
			bool rewritten = false;

			
			
			if(specification != null && typeof(TCondition).IsAssignableFrom(typeof(global::UseCase1.Submission)))
			{
				rewritten = true;
				var entitySpec = specification as ISpecification<global::UseCase1.Submission>;
				IQueryable<global::UseCase1.Submission> entities = new Queryable<global::UseCase1.Submission>(new QueryExecutor(DatabaseQuery, Locator));
				var uris = entitySpec != null
					? entities.Where(entitySpec.IsSatisfied).Select(it => it.URI).Skip(0)
					: entities.Cast<TCondition>().Where(specification.IsSatisfied).Cast<global::UseCase1.Submission>().Select(it => it.URI).Skip(0);
				data = data.Where(it => uris.Contains(it.URI));
			}

			if(!rewritten && specification != null)
			{
				var specAsNative = specification as ISpecification<global::UseCase1.SelectedSubmission>;
				if(specAsNative != null)
					data = data.Where(specAsNative.IsSatisfied);
				else
					data = data.Cast<TCondition>().Where(specification.IsSatisfied).Cast<global::UseCase1.SelectedSubmission>();
			}
				
			return data;
		}

		public global::UseCase1.SelectedSubmission[] Search<TCondition>(ISpecification<TCondition> specification, int? limit, int? offset)
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
				sw.Write(@"SELECT _r FROM ""UseCase1"".""SelectedSubmission"" _r");
			}
			
			
			else if (specification is global::UseCase1.SelectedSubmission.Where)
			{
				var spec = specification as global::UseCase1.SelectedSubmission.Where;
				cms = Common.Utility.UseThreadLocalStream();
				sw = cms.GetWriter();
				sw.Write(selectType);
				sw.Write(@" FROM ""UseCase1"".""SelectedSubmission.Where""(");
				
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.uri).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
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

		public Func<System.Data.IDataReader, int, global::UseCase1.SelectedSubmission[]> Search(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::UseCase1.SelectedSubmission> specification, int? limit, int? offset)
		{
			var selectType = "SELECT array_agg(_r) FROM (SELECT _it as _r";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT array_agg(_r) FROM (SELECT _r FROM ""UseCase1"".""SelectedSubmission"" _r");
			
			
			else if (specification is global::UseCase1.SelectedSubmission.Where)
			{
				var spec = specification as global::UseCase1.SelectedSubmission.Where;
				sw.Write(selectType);
				sw.Write(@" FROM ""UseCase1"".""SelectedSubmission.Where""(");
				if (query.UsePrepared)
				{
					sw.Write(query.GetNextArgument(tw => 
					{
						
					tw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.uri).InsertRecord(tw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					tw.Write('\'');
						tw.Write("::varchar");
					}, 
					"varchar"));
				}
				else 
				{
					
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.uri).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
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
				List<global::UseCase1.SelectedSubmission> result;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord);
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
				sw.Write(@"SELECT count(*) FROM ""UseCase1"".""SelectedSubmission"" r");
			}
			
			
			else if (specification is global::UseCase1.SelectedSubmission.Where)
			{
				var spec = specification as global::UseCase1.SelectedSubmission.Where;
				cms = Common.Utility.UseThreadLocalStream();
				sw = cms.GetWriter();
				sw.Write(selectType);
				sw.Write(@" FROM ""UseCase1"".""SelectedSubmission.Where""(");
				
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.uri).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
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

		public Func<System.Data.IDataReader, int, long> Count(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::UseCase1.SelectedSubmission> specification)
		{
			var selectType = "SELECT count(*)";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT count(*) FROM ""UseCase1"".""SelectedSubmission"" r");
			
			
			else if (specification is global::UseCase1.SelectedSubmission.Where)
			{
				var spec = specification as global::UseCase1.SelectedSubmission.Where;
				sw.Write(selectType);
				sw.Write(@" FROM ""UseCase1"".""SelectedSubmission.Where""(");
				if (query.UsePrepared)
				{
					sw.Write(query.GetNextArgument(tw => 
					{
						
					tw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.uri).InsertRecord(tw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					tw.Write('\'');
						tw.Write("::varchar");
					}, 
					"varchar"));
				}
				else 
				{
					
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.uri).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
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
				sw.Write(@"SELECT exists(SELECT * FROM ""UseCase1"".""SelectedSubmission"" r");
			}
			
			
			else if (specification is global::UseCase1.SelectedSubmission.Where)
			{
				var spec = specification as global::UseCase1.SelectedSubmission.Where;
				cms = Common.Utility.UseThreadLocalStream();
				sw = cms.GetWriter();
				sw.Write(selectType);
				sw.Write(@" FROM ""UseCase1"".""SelectedSubmission.Where""(");
				
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.uri).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
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

		public Func<System.Data.IDataReader, int, bool> Exists(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::UseCase1.SelectedSubmission> specification)
		{
			var selectType = "exists(SELECT *";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"exists(SELECT * FROM ""UseCase1"".""SelectedSubmission"" r");
			
			
			else if (specification is global::UseCase1.SelectedSubmission.Where)
			{
				var spec = specification as global::UseCase1.SelectedSubmission.Where;
				sw.Write(selectType);
				sw.Write(@" FROM ""UseCase1"".""SelectedSubmission.Where""(");
				if (query.UsePrepared)
				{
					sw.Write(query.GetNextArgument(tw => 
					{
						
					tw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.uri).InsertRecord(tw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
					tw.Write('\'');
						tw.Write("::varchar");
					}, 
					"varchar"));
				}
				else 
				{
					
					sw.Write('\'');
					_DatabaseCommon.Utility.StringToTuple(spec.uri).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
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

		
		public global::UseCase1.SelectedSubmission Find(string uri)
		{
			if (uri == null) return null;
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var sw = cms.GetWriter();
			sw.Write(@"SELECT _r FROM ""UseCase1"".""SelectedSubmission"" _r WHERE _r.""URI"" = ");
			PostgresRecordConverter.WriteSimpleUri(sw, uri);
			sw.Flush();
			var result = lookup.ExecuteOne(DatabaseQuery, lookup.OnePkCommand);
			if (!HasCustomSecurity) return result;
			var found = new [] { result };
			
			return found.Length == 1 ? result : null;
		}

		public Func<System.Data.IDataReader, int, global::UseCase1.SelectedSubmission> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, string uri)
		{
			var sw = query.Writer;
			var cms = query.Stream;
			if (uri == null)
			{
				sw.Write("SELECT 0");
				return (dr, ind) => null;
			}
			sw.Write(@"SELECT _r FROM ""UseCase1"".""SelectedSubmission"" _r WHERE _r.""URI"" = ");
			if (query.UsePrepared)
			{
				var nextArg = query.GetNextArgument(wr => PostgresRecordConverter.WriteSimpleUri(wr, uri), "text");
				sw.Write(nextArg);
				sw.Write("::text");
			}
			else PostgresRecordConverter.WriteSimpleUri(sw, uri);
			return (dr, ind) => 
			{
				global::UseCase1.SelectedSubmission result = null;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = _DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, Locator);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = _DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, Locator);
				}
				if (!HasCustomSecurity) return result;
				var found = new [] { result };
				
				return found.Length == 1 ? result : null;
			};
		}

		public global::UseCase1.SelectedSubmission[] Find(IEnumerable<string> uris)
		{
			var count = uris != null ? uris.Count() : 0;
			var pks = new List<string>(count);
			foreach (var _u in uris ?? new string[0])
				if (_u != null)
					pks.Add(_u);
			if (pks.Count == 0)
				return new global::UseCase1.SelectedSubmission[0];
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var sw = cms.GetWriter();
			sw.Write(@"SELECT _r FROM ""UseCase1"".""SelectedSubmission"" _r WHERE _r.""URI"" IN (");
			PostgresRecordConverter.WriteSimpleUriList(sw, pks);
			sw.Write(')');
			sw.Flush();
			var found = lookup.ExecuteAll(DatabaseQuery, lookup.InPkCommand).ToArray();
			
			return found;
		}

		public Func<System.Data.IDataReader, int, global::UseCase1.SelectedSubmission[]> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, IEnumerable<string> uris)
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
				return (dr, ind) => new global::UseCase1.SelectedSubmission[0];
			}
			if (query.UsePrepared)
			{
				sw.Write(@"SELECT array_agg(_r) FROM ""UseCase1"".""SelectedSubmission"" _r WHERE _r.""URI"" = ANY (");
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
				sw.Write(@"SELECT array_agg(_r) FROM ""UseCase1"".""SelectedSubmission"" _r WHERE _r.""URI"" IN (");
				PostgresRecordConverter.WriteSimpleUriList(sw, pks);
				sw.Write(')');
			}
			return (dr, ind) => 
			{
				var result = new List<global::UseCase1.SelectedSubmission>(pks.Count);
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord));
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryUseCase1_SelectedSubmission.SelectedSubmissionConverter.CreateFromRecord));
				}
				var found = result.ToArray();
				
				return found;
			};
		}
	}

}
