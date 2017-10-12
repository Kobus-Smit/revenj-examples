
namespace DatabaseRepositoryUseCase1
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


	
	
	internal static class RegisterForm
	{
		public static void Register(IObjectFactory factory)
		{
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.FormRepository), InstanceScope.Context, typeof(DatabaseRepositoryUseCase1.FormRepository), typeof(IQueryableRepository<global::UseCase1.Form>));
			factory.RegisterFunc<IQueryable<global::UseCase1.Form>>(f => f.Resolve<IQueryableRepository<global::UseCase1.Form>>().Query<global::UseCase1.Form>(null));
			
			
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.FormRepository), InstanceScope.Context, typeof(IRepository<global::UseCase1.Form>));
			factory.RegisterFunc<Func<string, global::UseCase1.Form>>(f => f.Resolve<IRepository<global::UseCase1.Form>>().Find);
			factory.RegisterFunc<Func<IEnumerable<string>, global::UseCase1.Form[]>>(f => f.Resolve<IRepository<global::UseCase1.Form>>().Find);
			
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.FormRepository), InstanceScope.Context, typeof(Revenj.DatabasePersistence.Postgres.IBulkRepository<global::UseCase1.Form>));
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.FormRepository), InstanceScope.Context, typeof(Revenj.DomainPatterns.IPersistableRepository<global::UseCase1.Form>));
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.FormRepository), InstanceScope.Context, typeof(IPersistableRepository<global::UseCase1.Form>));
			factory.RegisterType(typeof(DatabaseRepositoryUseCase1.FormRepository), InstanceScope.Context, typeof(IAggregateRootRepository<global::UseCase1.Form>));
			
		}
	}

	
	
	internal partial class FormRepository : global::Revenj.DomainPatterns.IQueryableRepository<global::UseCase1.Form>, global::System.IDisposable, global::Revenj.DomainPatterns.IRepository<global::UseCase1.Form>, global::Revenj.DatabasePersistence.Postgres.IBulkRepository<global::UseCase1.Form>, global::Revenj.DomainPatterns.IPersistableRepository<global::UseCase1.Form>, global::Revenj.DomainPatterns.IAggregateRootRepository<global::UseCase1.Form>
	{
		
		private readonly IServiceProvider Locator;
		private readonly IDatabaseQuery DatabaseQuery;
		
		public FormRepository(IServiceProvider locator, IDatabaseQuery query, IEagerNotification Notifications, IDataCache<global::UseCase1.Form> DataCache)
			
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
			internal global::UseCase1.Form one;
			internal readonly List<global::UseCase1.Form> list = new List<global::UseCase1.Form>();
			private System.IServiceProvider locator;
			internal readonly System.Data.IDbCommand NoTemplateCommand;
			
			internal readonly System.Data.IDbCommand RichFind;
			internal readonly System.Data.IDbCommand RichFindAll;
			internal _FindResult_()
			{
				cms = Common.Utility.UseThreadLocalStream();
				NoTemplateCommand = PostgresCommandFactory.NewCommand(cms);
				
				this.RichFind = PostgresCommandFactory.PreparedCommand(cms, "FS-UseCase1-Form", @"SELECT _r FROM ""UseCase1"".""Form_entity"" _r WHERE _r.""ID"" = $1", "uuid");
				this.RichFindAll = PostgresCommandFactory.PreparedCommand(cms, "FM-UseCase1-Form", @"SELECT _r FROM ""UseCase1"".""Form_entity"" _r WHERE _r.""ID"" = ANY($1)", "uuid[]");
			}

			public void Prepare(System.IServiceProvider locator)
			{
				this.cms.Reset();
				this.locator = locator;
				this.list.Clear();
				this.one = null;
			}

			public global::UseCase1.Form ExecuteOne(IDatabaseQuery query, System.Data.IDbCommand command)
			{
				this.cms.Position = 0;
				query.Execute(command, CollectOne);
				return one;
			}

			public List<global::UseCase1.Form> ExecuteAll(IDatabaseQuery query, System.Data.IDbCommand command)
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
					one = _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator);
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { one = _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator); }
					finally { _tr.Dispose(); }
				}
			}
			
			internal void CollectAll(System.Data.IDataReader dr)
			{
				var _pg = dr.GetValue(0);
				var _str = _pg as string;
				if (_str != null)
					list.Add(_DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator));
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { list.Add(_DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator)); }
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

		public IQueryable<global::UseCase1.Form> Query<TCondition>(ISpecification<TCondition> specification)
		{
			if(specification != null && specification.IsSatisfied == null)
				throw new ArgumentException("Search predicate is not specified"); 
			if(specification != null && !typeof(TCondition).IsAssignableFrom(typeof(global::UseCase1.Form)))
				throw new ArgumentException("Specification is not compatible");

			

			IQueryable<global::UseCase1.Form> data = new Queryable<global::UseCase1.Form>(new QueryExecutor(DatabaseQuery, Locator));
			bool rewritten = false;

			

			if(!rewritten && specification != null)
			{
				var specAsNative = specification as ISpecification<global::UseCase1.Form>;
				if(specAsNative != null)
					data = data.Where(specAsNative.IsSatisfied);
				else
					data = data.Cast<TCondition>().Where(specification.IsSatisfied).Cast<global::UseCase1.Form>();
			}
				
			return data;
		}

		public global::UseCase1.Form[] Search<TCondition>(ISpecification<TCondition> specification, int? limit, int? offset)
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
				sw.Write(@"SELECT _r FROM ""UseCase1"".""Form_entity"" _r");
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

		public Func<System.Data.IDataReader, int, global::UseCase1.Form[]> Search(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::UseCase1.Form> specification, int? limit, int? offset)
		{
			var selectType = "SELECT array_agg(_r) FROM (SELECT _it as _r";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT array_agg(_r) FROM (SELECT _r FROM ""UseCase1"".""Form_entity"" _r");
			
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
				List<global::UseCase1.Form> result;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord);
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
				sw.Write(@"SELECT count(*) FROM ""UseCase1"".""Form_entity"" r");
			}
			
			else return Query(specification).LongCount();

			sw.Flush();
			cms.Position = 0;
			var com = PostgresCommandFactory.NewCommand(cms); //TODO: sql template
			long total = 0;
			DatabaseQuery.Execute(com, dr => { total = dr.GetInt64(0); });
			return total;
		}

		public Func<System.Data.IDataReader, int, long> Count(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::UseCase1.Form> specification)
		{
			var selectType = "SELECT count(*)";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT count(*) FROM ""UseCase1"".""Form_entity"" r");
			
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
				sw.Write(@"SELECT exists(SELECT * FROM ""UseCase1"".""Form_entity"" r");
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

		public Func<System.Data.IDataReader, int, bool> Exists(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::UseCase1.Form> specification)
		{
			var selectType = "exists(SELECT *";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"exists(SELECT * FROM ""UseCase1"".""Form_entity"" r");
			
			else 
			{
				sw.Write("SELECT 0");
				return (dr, ind) => Query(specification).Any();
			}
			sw.Write(')');
			return (dr, ind) => dr.GetBoolean(ind);
		}

		
		public global::UseCase1.Form Find(string uri)
		{
			if (uri == null) return null;
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var sw = cms.GetWriter();
			sw.Write(@"EXECUTE ""FS-UseCase1-Form""(");
				PostgresRecordConverter.WriteSimpleUri(sw, uri);
				sw.Write("::uuid)");
				sw.Flush();
				lookup.ExecuteOne(DatabaseQuery, lookup.RichFind);
			var result = lookup.one;
			if (!HasCustomSecurity) return result;
			var found = new [] { result };
			
			return found.Length == 1 ? result : null;
		}

		public Func<System.Data.IDataReader, int, global::UseCase1.Form> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, string uri)
		{
			var sw = query.Writer;
			var cms = query.Stream;
			if (uri == null)
			{
				sw.Write("SELECT 0");
				return (dr, ind) => null;
			}
			sw.Write(@"SELECT _r FROM ""UseCase1"".""Form_entity"" _r WHERE _r.""ID"" = ");
				if (query.UsePrepared)
				{
					var nextArg = query.GetNextArgument(wr => 
						{
							PostgresRecordConverter.WriteSimpleUri(wr, uri);
							wr.Write("::uuid");
						},
						"uuid");
					sw.Write(nextArg);
				}
				else PostgresRecordConverter.WriteSimpleUri(sw, uri);
			return (dr, ind) => 
			{
				global::UseCase1.Form result = null;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, Locator);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, Locator);
				}
				if (!HasCustomSecurity) return result;
				var found = new [] { result };
				
				return found.Length == 1 ? result : null;
			};
		}

		public global::UseCase1.Form[] Find(IEnumerable<string> uris)
		{
			var count = uris != null ? uris.Count() : 0;
			var pks = new List<string>(count);
			foreach (var _u in uris ?? new string[0])
				if (_u != null)
					pks.Add(_u);
			if (pks.Count == 0)
				return new global::UseCase1.Form[0];
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var result = lookup.list;
			var sw = cms.GetWriter();
			sw.Write(@"EXECUTE ""FM-UseCase1-Form""(ARRAY[");
				PostgresRecordConverter.WriteSimpleUriList(sw, pks);
				sw.Write("]::uuid[])");
				sw.Flush();
				lookup.ExecuteAll(DatabaseQuery, lookup.RichFindAll);
			var found = result.ToArray();
			
			return found;
		}

		public Func<System.Data.IDataReader, int, global::UseCase1.Form[]> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, IEnumerable<string> uris)
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
				return (dr, ind) => new global::UseCase1.Form[0];
			}
			
				if (query.UsePrepared)
				{
					sw.Write(@"SELECT array_agg(_r) FROM ""UseCase1"".""Form_entity"" _r WHERE _r.""ID"" = ANY(");
					var nextArg = query.GetNextArgument(wr => 
						{
							wr.Write("ARRAY[");
							PostgresRecordConverter.WriteSimpleUriList(wr, pks);
							wr.Write("]::uuid[]");
						}, 
						"uuid[]");
					sw.Write(nextArg);
					sw.Write(')');
				}
				else
				{
					sw.Write(@"SELECT array_agg(_r) FROM ""UseCase1"".""Form_entity"" _r WHERE _r.""ID"" IN (");
					PostgresRecordConverter.WriteSimpleUriList(sw, pks);
					sw.Write(')');
				}
			return (dr, ind) => 
			{
				var result = new List<global::UseCase1.Form>(pks.Count);
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord));
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateFromRecord));
				}
				var found = result.ToArray();
				
				return found;
			};
		}
		
		private readonly System.Collections.Concurrent.ConcurrentQueue<NotifyInfo> NotifyQueue = new System.Collections.Concurrent.ConcurrentQueue<NotifyInfo>();
		private readonly IEagerNotification Notifications;
		private readonly IDataCache<global::UseCase1.Form> DataCache;
		
		public string[] Persist(IEnumerable<global::UseCase1.Form> insert, IEnumerable<KeyValuePair<global::UseCase1.Form, global::UseCase1.Form>> update, IEnumerable<global::UseCase1.Form> delete)
		{
			var insertedData = insert != null ? insert.ToArray() : new global::UseCase1.Form[0];
			var updatedData = update != null ? update.ToList() : new List<KeyValuePair<global::UseCase1.Form, global::UseCase1.Form>>();
			var deletedData = delete != null ? delete.ToArray() : new global::UseCase1.Form[0];

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
				global::UseCase1.Form _val;
				for(int i = 0; i < updatedData.Count; i++)
				{
					_val = updatedData[i].Value;
					updatedData[i] = new KeyValuePair<global::UseCase1.Form, global::UseCase1.Form>(oldValues[_val.URI], _val);
				}
			}

			updatedData.RemoveAll(kv => kv.Key.Equals(kv.Value));

			var cms = Common.Utility.UseThreadLocalStream();

			
			for(int i = 0; i < insertedData.Length; i++)
				insertedData[i].__InternalPrepareInsert();
			foreach(var it in updatedData)
				it.Value.__InternalPrepareUpdate();
			for(int i = 0; i < deletedData.Length; i++)
				deletedData[i].__InternalPrepareDelete();

			for(int i = 0; i < insertedData.Length; i++)
			{
				var it = insertedData[i];
				it.__ReapplyReferences();
				it.URI = _DatabaseCommon.FactoryUseCase1_Form.FormConverter.BuildURI(cms.CharBuffer, it.ID);
				if(it.GroupID != null) it._GroupURI = _DatabaseCommon.FactoryUseCase1_FormGroup.FormGroupConverter.BuildURI(cms.CharBuffer, it.GroupID);
			}
			foreach(var kv in updatedData)
			{
				kv.Value.__ReapplyReferences();
				kv.Value.URI = _DatabaseCommon.FactoryUseCase1_Form.FormConverter.BuildURI(cms.CharBuffer, kv.Value.ID);
				if(kv.Value.GroupID != null) kv.Value._GroupURI = _DatabaseCommon.FactoryUseCase1_FormGroup.FormGroupConverter.BuildURI(cms.CharBuffer, kv.Value.GroupID);
			}


			var totalCount = insertedData.Length + updatedData.Count + deletedData.Length;
			var totalSize = 
				insertedData.Sum(i => i._InternalGetSizeApproximation()) 
				+ updatedData.Sum(i => i.Key._InternalGetSizeApproximation())
				+ updatedData.Sum(i => i.Value._InternalGetSizeApproximation())
				+ deletedData.Sum(i => i._InternalGetSizeApproximation());

			if (DatabaseQuery.InTransaction && (totalCount >= MinBatchSize || totalSize >= MaxObjectSize) && DatabaseQuery is IPostgresDatabaseQuery)
				_InternalDoPersistLarge(cms, insertedData, updatedData, deletedData);
			else
				_InternalDoPersistStandard(cms, insertedData, updatedData, deletedData);
			var resultURI = new string[insertedData.Length];
			for(int i = 0; i < resultURI.Length; i++)
				resultURI[i] = insertedData[i].URI;

			
			if (DatabaseQuery.InTransaction)
			{
				if (insertedData.Length > 0) NotifyQueue.Enqueue(new NotifyInfo("UseCase1.Form", NotifyInfo.OperationEnum.Insert, resultURI));
				if (updatedData.Count > 0) 
				{
					NotifyQueue.Enqueue(new NotifyInfo("UseCase1.Form", NotifyInfo.OperationEnum.Update, updatedData.Select(it => it.Key.URI).ToArray()));
					if (updatedData.Any(kv => kv.Key.URI != kv.Value.URI)) NotifyQueue.Enqueue(new NotifyInfo("UseCase1.Form", NotifyInfo.OperationEnum.Change, updatedData.Where(kv => kv.Key.URI != kv.Value.URI).Select(it => it.Value.URI).ToArray()));
				}
				if (deletedData.Length > 0) NotifyQueue.Enqueue(new NotifyInfo("UseCase1.Form", NotifyInfo.OperationEnum.Delete, deletedData.Select(it => it.URI).ToArray()));
			}
			else
			{
				if (insertedData.Length > 0) Notifications.Notify(new NotifyInfo("UseCase1.Form", NotifyInfo.OperationEnum.Insert, resultURI));
				if (updatedData.Count > 0) 
				{
					Notifications.Notify(new NotifyInfo("UseCase1.Form", NotifyInfo.OperationEnum.Update, updatedData.Select(it => it.Key.URI).ToArray()));
					if (updatedData.Any(kv => kv.Key.URI != kv.Value.URI)) Notifications.Notify(new NotifyInfo("UseCase1.Form", NotifyInfo.OperationEnum.Change, updatedData.Where(kv => kv.Key.URI != kv.Value.URI).Select(it => it.Value.URI).ToArray()));
				}
				if (deletedData.Length > 0) Notifications.Notify(new NotifyInfo("UseCase1.Form", NotifyInfo.OperationEnum.Delete, deletedData.Select(it => it.URI).ToArray()));
			}
			DataCache.Invalidate(updatedData.Select(it => it.Key.URI).Union(deletedData.Select(it => it.URI)));

			return resultURI;
		}

		
		private static int? aggregateMinBatchSize;
		private static int MinBatchSize
		{
			get
			{
				if(aggregateMinBatchSize == null)
				{
					var cmr = System.Configuration.ConfigurationManager.AppSettings["Database.MinBatchSize.UseCase1.Form"];
					int cmrInt = 0;
					if(!string.IsNullOrEmpty(cmr) && int.TryParse(cmr, out cmrInt))
						aggregateMinBatchSize = cmrInt;
					else 
						aggregateMinBatchSize = Revenj.DatabasePersistence.Postgres.Setup.MinBatchSize;
				}
				return aggregateMinBatchSize.Value;
			}
		}

		private static long? aggregateMaxObjectSize;
		private static long MaxObjectSize
		{
			get
			{
				if(aggregateMaxObjectSize == null)
				{
					var cmr = System.Configuration.ConfigurationManager.AppSettings["Database.MaxObjectSize.UseCase1.Form"];
					long cmrLong = 0;
					if(!string.IsNullOrEmpty(cmr) && long.TryParse(cmr, out cmrLong))
						aggregateMaxObjectSize = cmrLong;
					else 
						aggregateMaxObjectSize = Revenj.DatabasePersistence.Postgres.Setup.MaxObjectSize;
				}
				return aggregateMaxObjectSize.Value;
			}
		}

		private void _InternalDoPersistStandard(Revenj.Utility.ChunkedMemoryStream cms, global::UseCase1.Form[] insertedData, List<KeyValuePair<global::UseCase1.Form, global::UseCase1.Form>> updatedData, global::UseCase1.Form[] deletedData)
		{
			var sw = cms.GetWriter();
			sw.Write("/*NO LOAD BALANCE*/SELECT \"UseCase1\".\"persist_Form\"(");
			PostgresTypedArray.ToArray(sw, cms.SmallBuffer, insertedData, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateTupleFrom);
			sw.Write(@"::""UseCase1"".""Form_entity""[],");
			PostgresTypedArray.ToArray(sw, cms.SmallBuffer, updatedData.Select(it => it.Key), _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateTupleFrom);
			sw.Write(@"::""UseCase1"".""Form_entity""[],");
			PostgresTypedArray.ToArray(sw, cms.SmallBuffer, updatedData.Select(it => it.Value), _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateTupleFrom);
			sw.Write(@"::""UseCase1"".""Form_entity""[],");
			PostgresTypedArray.ToArray(sw, cms.SmallBuffer, deletedData, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateTupleFrom);
			sw.Write(@"::""UseCase1"".""Form_entity""[]");

			

			sw.Write(")");

			

			sw.Flush();
			cms.Position = 0;
			var com = PostgresCommandFactory.NewCommand(cms, "SELECT \"UseCase1\".\"persist_Form\"(:insert,:update_old,:update_new,:delete)");
			string _sqlError = null;
			DatabaseQuery.Execute(com, dr => _sqlError = dr.GetString(0));
			if (_sqlError != null)
				throw new PostgresException(_sqlError);

			
			foreach(var item in insertedData)
				item.__ResetChangeTracking();
			foreach(var item in updatedData)
				item.Value.__ResetChangeTracking();
		}

		private void _InternalDoPersistLarge(Revenj.Utility.ChunkedMemoryStream cms, global::UseCase1.Form[] insertedData, List<KeyValuePair<global::UseCase1.Form, global::UseCase1.Form>> updatedData, global::UseCase1.Form[] deletedData)
		{
			var dbq = DatabaseQuery as IPostgresDatabaseQuery;

			

			

			if(insertedData.Length > 0)
				dbq.BulkInsert(
					"\"UseCase1\".\">tmp-Form-insert<\"", 
					insertedData.Select((item, ind) => new IPostgresTuple[] { IntConverter.ToTuple(ind), _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateRecordTupleFrom(item, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.TableTuples) } ));
			if(updatedData.Count > 0)
				dbq.BulkInsert(
					"\"UseCase1\".\">tmp-Form-update<\"", 
					updatedData.Select((kv, ind) => new IPostgresTuple[] { IntConverter.ToTuple(ind), _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateRecordTupleFrom(kv.Key, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.PrimaryKeyUpdateTuples), _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateRecordTupleFrom(kv.Value, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.TableTuples) } ));
			if(deletedData.Length > 0)
				dbq.BulkInsert(
					"\"UseCase1\".\">tmp-Form-delete<\"", 
					deletedData.Select((item, ind) => new IPostgresTuple[] { IntConverter.ToTuple(ind), _DatabaseCommon.FactoryUseCase1_Form.FormConverter.CreateRecordTupleFrom(item, _DatabaseCommon.FactoryUseCase1_Form.FormConverter.PrimaryKeyDeleteTuples) } ));
			
			var sw = cms.GetWriter();
			sw.Write("/*NO LOAD BALANCE*/SELECT \"UseCase1\".\"persist_Form_internal\"(");
			sw.Write(updatedData.Count);
			sw.Write(", ");
			sw.Write(deletedData.Length);

			

			sw.Write(")");

			

			sw.Flush();
			cms.Position = 0;
			var com = PostgresCommandFactory.NewCommand(cms, "SELECT \"UseCase1\".\"persist_Form_internal\"(:updated_count,:deleted_count)");
			string _sqlError = null;
			DatabaseQuery.Execute(com, dr => _sqlError = dr.GetString(0));
			if (_sqlError != null)
				throw new PostgresException(_sqlError);

			
			foreach(var item in insertedData)
				item.__ResetChangeTracking();
			foreach(var item in updatedData)
				item.Value.__ResetChangeTracking();
		}

		
		global::UseCase1.Form[] IAggregateRootRepository<global::UseCase1.Form>.Create(int count, Action<global::UseCase1.Form[]> initialize)
		{
			if(count < 0)
				throw new ArgumentException("count must be positive: Provided value " + count);
			var roots = new global::UseCase1.Form[count];
			for(int i = 0; i < count; i++)
				roots[i] = new global::UseCase1.Form();
			if(initialize != null)
				initialize(roots);
			Persist(roots, null, null);
			return roots;
		}

		global::UseCase1.Form[] IAggregateRootRepository<global::UseCase1.Form>.Update(string[] uris, Action<global::UseCase1.Form[]> change)
		{
			var roots = Find(uris);
			if(roots.Length != uris.Length)
				throw new ArgumentException("Can't find UseCase1.Form with uri: ".With(string.Join(", ", uris)));
			if(change != null)
			{
				var originals = roots.Select(it => it.Clone()).ToDictionary(it => it.URI);
				change(roots);
				Persist(null, roots.Select(it => new KeyValuePair<global::UseCase1.Form, global::UseCase1.Form>(originals[it.URI], it)).ToList(), null);
			}
			return roots;
		}

		void IAggregateRootRepository<global::UseCase1.Form>.Delete(string[] uris)
		{
			var roots = Find(uris);
			if(roots.Length != uris.Length)
				throw new ArgumentException("Can't find UseCase1.Form with uri: ".With(string.Join(", ", uris)));
			Persist(null, null, roots);
		}

		IQueryable<global::UseCase1.Form> IQueryableRepository<global::UseCase1.Form>.Query<TCondition>(ISpecification<TCondition> specification)
		{
			return Query(specification);
		}

		global::UseCase1.Form[] IQueryableRepository<global::UseCase1.Form>.Search<TCondition>(ISpecification<TCondition> specification, int? limit, int? offset)
		{
			return Search(specification, limit, offset);
		}

		global::UseCase1.Form[] IRepository<global::UseCase1.Form>.Find(IEnumerable<string> uris) { return Find(uris); }

	}

}
