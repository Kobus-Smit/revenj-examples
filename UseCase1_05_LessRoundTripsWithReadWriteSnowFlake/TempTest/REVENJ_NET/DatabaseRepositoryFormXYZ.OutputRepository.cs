
namespace DatabaseRepositoryFormXYZ
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


	
	
	internal static class RegisterOutput
	{
		public static void Register(IObjectFactory factory)
		{
			factory.RegisterType(typeof(DatabaseRepositoryFormXYZ.OutputRepository), InstanceScope.Context, typeof(DatabaseRepositoryFormXYZ.OutputRepository), typeof(IQueryableRepository<global::FormXYZ.Output>));
			factory.RegisterFunc<IQueryable<global::FormXYZ.Output>>(f => f.Resolve<IQueryableRepository<global::FormXYZ.Output>>().Query<global::FormXYZ.Output>(null));
			
			
			factory.RegisterType(typeof(DatabaseRepositoryFormXYZ.OutputRepository), InstanceScope.Context, typeof(IRepository<global::FormXYZ.Output>));
			factory.RegisterFunc<Func<string, global::FormXYZ.Output>>(f => f.Resolve<IRepository<global::FormXYZ.Output>>().Find);
			factory.RegisterFunc<Func<IEnumerable<string>, global::FormXYZ.Output[]>>(f => f.Resolve<IRepository<global::FormXYZ.Output>>().Find);
			
			factory.RegisterType(typeof(DatabaseRepositoryFormXYZ.OutputRepository), InstanceScope.Context, typeof(Revenj.DatabasePersistence.Postgres.IBulkRepository<global::FormXYZ.Output>));
			factory.RegisterType(typeof(DatabaseRepositoryFormXYZ.OutputRepository), InstanceScope.Context, typeof(Revenj.DomainPatterns.IPersistableRepository<global::FormXYZ.Output>));
			factory.RegisterType(typeof(DatabaseRepositoryFormXYZ.OutputRepository), InstanceScope.Context, typeof(IPersistableRepository<global::FormXYZ.Output>));
			factory.RegisterType(typeof(DatabaseRepositoryFormXYZ.OutputRepository), InstanceScope.Context, typeof(IAggregateRootRepository<global::FormXYZ.Output>));
			
		}
	}

	
	
	internal partial class OutputRepository : global::Revenj.DomainPatterns.IQueryableRepository<global::FormXYZ.Output>, global::System.IDisposable, global::Revenj.DomainPatterns.IRepository<global::FormXYZ.Output>, global::Revenj.DatabasePersistence.Postgres.IBulkRepository<global::FormXYZ.Output>, global::Revenj.DomainPatterns.IPersistableRepository<global::FormXYZ.Output>, global::Revenj.DomainPatterns.IAggregateRootRepository<global::FormXYZ.Output>
	{
		
		private readonly IServiceProvider Locator;
		private readonly IDatabaseQuery DatabaseQuery;
		
		public OutputRepository(IServiceProvider locator, IDatabaseQuery query, IEagerNotification Notifications, IDataCache<global::FormXYZ.Output> DataCache)
			
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
			internal global::FormXYZ.Output one;
			internal readonly List<global::FormXYZ.Output> list = new List<global::FormXYZ.Output>();
			private System.IServiceProvider locator;
			internal readonly System.Data.IDbCommand NoTemplateCommand;
			
			internal readonly System.Data.IDbCommand RichFind;
			internal readonly System.Data.IDbCommand RichFindAll;
			internal _FindResult_()
			{
				cms = Common.Utility.UseThreadLocalStream();
				NoTemplateCommand = PostgresCommandFactory.NewCommand(cms);
				
				this.RichFind = PostgresCommandFactory.PreparedCommand(cms, "FS-FormXYZ-Output", @"SELECT _r FROM ""FormXYZ"".""Output_entity"" _r WHERE _r.""ID"" = $1", "uuid");
				this.RichFindAll = PostgresCommandFactory.PreparedCommand(cms, "FM-FormXYZ-Output", @"SELECT _r FROM ""FormXYZ"".""Output_entity"" _r WHERE _r.""ID"" = ANY($1)", "uuid[]");
			}

			public void Prepare(System.IServiceProvider locator)
			{
				this.cms.Reset();
				this.locator = locator;
				this.list.Clear();
				this.one = null;
			}

			public global::FormXYZ.Output ExecuteOne(IDatabaseQuery query, System.Data.IDbCommand command)
			{
				this.cms.Position = 0;
				query.Execute(command, CollectOne);
				return one;
			}

			public List<global::FormXYZ.Output> ExecuteAll(IDatabaseQuery query, System.Data.IDbCommand command)
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
					one = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator);
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { one = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator); }
					finally { _tr.Dispose(); }
				}
			}
			
			internal void CollectAll(System.Data.IDataReader dr)
			{
				var _pg = dr.GetValue(0);
				var _str = _pg as string;
				if (_str != null)
					list.Add(_DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, locator));
				else 
				{
					var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString());
					try { list.Add(_DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, locator)); }
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

		public IQueryable<global::FormXYZ.Output> Query<TCondition>(ISpecification<TCondition> specification)
		{
			if(specification != null && specification.IsSatisfied == null)
				throw new ArgumentException("Search predicate is not specified"); 
			if(specification != null && !typeof(TCondition).IsAssignableFrom(typeof(global::FormXYZ.Output)))
				throw new ArgumentException("Specification is not compatible");

			

			IQueryable<global::FormXYZ.Output> data = new Queryable<global::FormXYZ.Output>(new QueryExecutor(DatabaseQuery, Locator));
			bool rewritten = false;

			

			if(!rewritten && specification != null)
			{
				var specAsNative = specification as ISpecification<global::FormXYZ.Output>;
				if(specAsNative != null)
					data = data.Where(specAsNative.IsSatisfied);
				else
					data = data.Cast<TCondition>().Where(specification.IsSatisfied).Cast<global::FormXYZ.Output>();
			}
				
			return data;
		}

		public global::FormXYZ.Output[] Search<TCondition>(ISpecification<TCondition> specification, int? limit, int? offset)
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
				sw.Write(@"SELECT _r FROM ""FormXYZ"".""Output_entity"" _r");
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

		public Func<System.Data.IDataReader, int, global::FormXYZ.Output[]> Search(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::FormXYZ.Output> specification, int? limit, int? offset)
		{
			var selectType = "SELECT array_agg(_r) FROM (SELECT _it as _r";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT array_agg(_r) FROM (SELECT _r FROM ""FormXYZ"".""Output_entity"" _r");
			
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
				List<global::FormXYZ.Output> result;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord);
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
				sw.Write(@"SELECT count(*) FROM ""FormXYZ"".""Output_entity"" r");
			}
			
			else return Query(specification).LongCount();

			sw.Flush();
			cms.Position = 0;
			var com = PostgresCommandFactory.NewCommand(cms); //TODO: sql template
			long total = 0;
			DatabaseQuery.Execute(com, dr => { total = dr.GetInt64(0); });
			return total;
		}

		public Func<System.Data.IDataReader, int, long> Count(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::FormXYZ.Output> specification)
		{
			var selectType = "SELECT count(*)";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"SELECT count(*) FROM ""FormXYZ"".""Output_entity"" r");
			
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
				sw.Write(@"SELECT exists(SELECT * FROM ""FormXYZ"".""Output_entity"" r");
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

		public Func<System.Data.IDataReader, int, bool> Exists(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, ISpecification<global::FormXYZ.Output> specification)
		{
			var selectType = "exists(SELECT *";
			var sw = query.Writer;
			var cms = query.Stream;

			if (specification == null)
				sw.Write(@"exists(SELECT * FROM ""FormXYZ"".""Output_entity"" r");
			
			else 
			{
				sw.Write("SELECT 0");
				return (dr, ind) => Query(specification).Any();
			}
			sw.Write(')');
			return (dr, ind) => dr.GetBoolean(ind);
		}

		
		public global::FormXYZ.Output Find(string uri)
		{
			if (uri == null) return null;
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var sw = cms.GetWriter();
			sw.Write(@"EXECUTE ""FS-FormXYZ-Output""(");
				PostgresRecordConverter.WriteSimpleUri(sw, uri);
				sw.Write("::uuid)");
				sw.Flush();
				lookup.ExecuteOne(DatabaseQuery, lookup.RichFind);
			var result = lookup.one;
			if (!HasCustomSecurity) return result;
			var found = new [] { result };
			
			return found.Length == 1 ? result : null;
		}

		public Func<System.Data.IDataReader, int, global::FormXYZ.Output> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, string uri)
		{
			var sw = query.Writer;
			var cms = query.Stream;
			if (uri == null)
			{
				sw.Write("SELECT 0");
				return (dr, ind) => null;
			}
			sw.Write(@"SELECT _r FROM ""FormXYZ"".""Output_entity"" _r WHERE _r.""ID"" = ");
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
				global::FormXYZ.Output result = null;
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord(cms.UseBufferedReader(_str), 0, Locator);
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord(cms.UseBufferedReader(_tr), 0, Locator);
				}
				if (!HasCustomSecurity) return result;
				var found = new [] { result };
				
				return found.Length == 1 ? result : null;
			};
		}

		public global::FormXYZ.Output[] Find(IEnumerable<string> uris)
		{
			var count = uris != null ? uris.Count() : 0;
			var pks = new List<string>(count);
			foreach (var _u in uris ?? new string[0])
				if (_u != null)
					pks.Add(_u);
			if (pks.Count == 0)
				return new global::FormXYZ.Output[0];
			var lookup = PrepareLocalFind(Locator);
			var cms = lookup.cms;
			var result = lookup.list;
			var sw = cms.GetWriter();
			sw.Write(@"EXECUTE ""FM-FormXYZ-Output""(ARRAY[");
				PostgresRecordConverter.WriteSimpleUriList(sw, pks);
				sw.Write("]::uuid[])");
				sw.Flush();
				lookup.ExecuteAll(DatabaseQuery, lookup.RichFindAll);
			var found = result.ToArray();
			
			return found;
		}

		public Func<System.Data.IDataReader, int, global::FormXYZ.Output[]> Find(Revenj.DatabasePersistence.Postgres.IBulkReadQuery query, IEnumerable<string> uris)
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
				return (dr, ind) => new global::FormXYZ.Output[0];
			}
			
				if (query.UsePrepared)
				{
					sw.Write(@"SELECT array_agg(_r) FROM ""FormXYZ"".""Output_entity"" _r WHERE _r.""ID"" = ANY(");
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
					sw.Write(@"SELECT array_agg(_r) FROM ""FormXYZ"".""Output_entity"" _r WHERE _r.""ID"" IN (");
					PostgresRecordConverter.WriteSimpleUriList(sw, pks);
					sw.Write(')');
				}
			return (dr, ind) => 
			{
				var result = new List<global::FormXYZ.Output>(pks.Count);
				var _pg = dr.GetValue(ind);
				var _str = _pg as string;
				if (_str != null)
					result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_str), 0, Locator, _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord));
				else
				{
					using(var _tr = _pg as System.IO.TextReader ?? new System.IO.StringReader(_pg.ToString()))
						result.AddRange(PostgresTypedArray.ParseCollection(cms.UseBufferedReader(_tr), 0, Locator, _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateFromRecord));
				}
				var found = result.ToArray();
				
				return found;
			};
		}
		
		private readonly System.Collections.Concurrent.ConcurrentQueue<NotifyInfo> NotifyQueue = new System.Collections.Concurrent.ConcurrentQueue<NotifyInfo>();
		private readonly IEagerNotification Notifications;
		private readonly IDataCache<global::FormXYZ.Output> DataCache;
		
		public string[] Persist(IEnumerable<global::FormXYZ.Output> insert, IEnumerable<KeyValuePair<global::FormXYZ.Output, global::FormXYZ.Output>> update, IEnumerable<global::FormXYZ.Output> delete)
		{
			var insertedData = insert != null ? insert.ToArray() : new global::FormXYZ.Output[0];
			var updatedData = update != null ? update.ToList() : new List<KeyValuePair<global::FormXYZ.Output, global::FormXYZ.Output>>();
			var deletedData = delete != null ? delete.ToArray() : new global::FormXYZ.Output[0];

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
				global::FormXYZ.Output _val;
				for(int i = 0; i < updatedData.Count; i++)
				{
					_val = updatedData[i].Value;
					updatedData[i] = new KeyValuePair<global::FormXYZ.Output, global::FormXYZ.Output>(oldValues[_val.URI], _val);
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
				it.URI = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.BuildURI(cms.CharBuffer, it.ID);
				if(it.SubmissionID != null) it._SubmissionURI = _DatabaseCommon.FactoryUseCase1_Submission.SubmissionConverter.BuildURI(cms.CharBuffer, it.SubmissionID);
			}
			foreach(var kv in updatedData)
			{
				kv.Value.__ReapplyReferences();
				kv.Value.URI = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.BuildURI(cms.CharBuffer, kv.Value.ID);
				if(kv.Value.SubmissionID != null) kv.Value._SubmissionURI = _DatabaseCommon.FactoryUseCase1_Submission.SubmissionConverter.BuildURI(cms.CharBuffer, kv.Value.SubmissionID);
			}


			_InternalDoPersist(cms, insertedData, updatedData, deletedData);
			var resultURI = new string[insertedData.Length];
			for(int i = 0; i < resultURI.Length; i++)
				resultURI[i] = insertedData[i].URI;

			
			if (DatabaseQuery.InTransaction)
			{
				if (insertedData.Length > 0) NotifyQueue.Enqueue(new NotifyInfo("FormXYZ.Output", NotifyInfo.OperationEnum.Insert, resultURI));
				if (updatedData.Count > 0) 
				{
					NotifyQueue.Enqueue(new NotifyInfo("FormXYZ.Output", NotifyInfo.OperationEnum.Update, updatedData.Select(it => it.Key.URI).ToArray()));
					if (updatedData.Any(kv => kv.Key.URI != kv.Value.URI)) NotifyQueue.Enqueue(new NotifyInfo("FormXYZ.Output", NotifyInfo.OperationEnum.Change, updatedData.Where(kv => kv.Key.URI != kv.Value.URI).Select(it => it.Value.URI).ToArray()));
				}
				if (deletedData.Length > 0) NotifyQueue.Enqueue(new NotifyInfo("FormXYZ.Output", NotifyInfo.OperationEnum.Delete, deletedData.Select(it => it.URI).ToArray()));
			}
			else
			{
				if (insertedData.Length > 0) Notifications.Notify(new NotifyInfo("FormXYZ.Output", NotifyInfo.OperationEnum.Insert, resultURI));
				if (updatedData.Count > 0) 
				{
					Notifications.Notify(new NotifyInfo("FormXYZ.Output", NotifyInfo.OperationEnum.Update, updatedData.Select(it => it.Key.URI).ToArray()));
					if (updatedData.Any(kv => kv.Key.URI != kv.Value.URI)) Notifications.Notify(new NotifyInfo("FormXYZ.Output", NotifyInfo.OperationEnum.Change, updatedData.Where(kv => kv.Key.URI != kv.Value.URI).Select(it => it.Value.URI).ToArray()));
				}
				if (deletedData.Length > 0) Notifications.Notify(new NotifyInfo("FormXYZ.Output", NotifyInfo.OperationEnum.Delete, deletedData.Select(it => it.URI).ToArray()));
			}
			DataCache.Invalidate(updatedData.Select(it => it.Key.URI).Union(deletedData.Select(it => it.URI)));

			return resultURI;
		}

		
		private void _InternalDoPersist(Revenj.Utility.ChunkedMemoryStream cms, global::FormXYZ.Output[] insertedData, List<KeyValuePair<global::FormXYZ.Output, global::FormXYZ.Output>> updatedData, global::FormXYZ.Output[] deletedData)
		{
			var sw = cms.GetWriter();
			if (insertedData.Length == 1 && updatedData.Count == 0 && deletedData.Length == 0)
			{
				sw.Write("/*NO LOAD BALANCE*/SELECT \"FormXYZ\".\"insert_Output\"(ARRAY['");
				_DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateRecordTupleFrom(insertedData[0], _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.TableTuples).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""FormXYZ"".""Output_entity""])");

				

				sw.Flush();
				cms.Position = 0;
				var com = PostgresCommandFactory.NewCommand(cms, "SELECT \"FormXYZ\".\"insert_Output\"(:insert)");
				DatabaseQuery.Execute(com);
			}
			else if (insertedData.Length == 0 && updatedData.Count == 1 && deletedData.Length == 0)
			{
				sw.Write("/*NO LOAD BALANCE*/SELECT \"FormXYZ\".\"update_Output\"(ARRAY['");
				_DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateRecordTupleFrom(updatedData[0].Key, _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.PrimaryKeyUpdateTuples).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""FormXYZ"".""Output_entity""],ARRAY['");
				_DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateRecordTupleFrom(updatedData[0].Value, _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.TableTuples).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""FormXYZ"".""Output_entity""]");

				

				sw.Write(')');

				

				sw.Flush();
				cms.Position = 0;
				var com = PostgresCommandFactory.NewCommand(cms, "SELECT \"FormXYZ\".\"update_Output\"(:old_record,:new_record)");
				string _sqlError = null;
				DatabaseQuery.Execute(com, dr => _sqlError = dr.GetString(0));
				if (_sqlError != null)
					throw new PostgresException(_sqlError);
			}
			else
			{
				sw.Write("/*NO LOAD BALANCE*/SELECT \"FormXYZ\".\"persist_Output\"('");
				var arr = new IPostgresTuple[insertedData.Length];
				for (int i = 0; i < insertedData.Length; i++)
					arr[i] = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateRecordTupleFrom(insertedData[i], _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.TableTuples);
				ArrayTuple.From(arr).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""FormXYZ"".""Output_entity""[],'");
				arr = new IPostgresTuple[updatedData.Count];
				for (int i = 0; i < updatedData.Count; i++)
					arr[i] = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateRecordTupleFrom(updatedData[i].Key, _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.PrimaryKeyUpdateTuples);
				ArrayTuple.From(arr).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""FormXYZ"".""Output_entity""[],'");
				for (int i = 0; i < updatedData.Count; i++)
					arr[i] = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateRecordTupleFrom(updatedData[i].Value, _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.TableTuples);
				ArrayTuple.From(arr).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""FormXYZ"".""Output_entity""[],'");
				arr = new IPostgresTuple[deletedData.Length];
				for (int i = 0; i < deletedData.Length; i++)
					arr[i] = _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.CreateRecordTupleFrom(deletedData[i], _DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.PrimaryKeyDeleteTuples);
				ArrayTuple.From(arr).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
				sw.Write(@"'::""FormXYZ"".""Output_entity""[]");

				

				sw.Write(")");

				

				sw.Flush();
				cms.Position = 0;
				var com = PostgresCommandFactory.NewCommand(cms, "SELECT \"FormXYZ\".\"persist_Output\"(:insert,:update_pairs,:delete)");
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

		
		global::FormXYZ.Output[] IAggregateRootRepository<global::FormXYZ.Output>.Create(int count, Action<global::FormXYZ.Output[]> initialize)
		{
			if(count < 0)
				throw new ArgumentException("count must be positive: Provided value " + count);
			var roots = new global::FormXYZ.Output[count];
			for(int i = 0; i < count; i++)
				roots[i] = new global::FormXYZ.Output();
			if(initialize != null)
				initialize(roots);
			Persist(roots, null, null);
			return roots;
		}

		global::FormXYZ.Output[] IAggregateRootRepository<global::FormXYZ.Output>.Update(string[] uris, Action<global::FormXYZ.Output[]> change)
		{
			var roots = Find(uris);
			if(roots.Length != uris.Length)
				throw new ArgumentException("Can't find FormXYZ.Output with uri: ".With(string.Join(", ", uris)));
			if(change != null)
			{
				var originals = roots.Select(it => it.Clone()).ToDictionary(it => it.URI);
				change(roots);
				Persist(null, roots.Select(it => new KeyValuePair<global::FormXYZ.Output, global::FormXYZ.Output>(originals[it.URI], it)).ToList(), null);
			}
			return roots;
		}

		void IAggregateRootRepository<global::FormXYZ.Output>.Delete(string[] uris)
		{
			var roots = Find(uris);
			if(roots.Length != uris.Length)
				throw new ArgumentException("Can't find FormXYZ.Output with uri: ".With(string.Join(", ", uris)));
			Persist(null, null, roots);
		}

		IQueryable<global::FormXYZ.Output> IQueryableRepository<global::FormXYZ.Output>.Query<TCondition>(ISpecification<TCondition> specification)
		{
			return Query(specification);
		}

		global::FormXYZ.Output[] IQueryableRepository<global::FormXYZ.Output>.Search<TCondition>(ISpecification<TCondition> specification, int? limit, int? offset)
		{
			return Search(specification, limit, offset);
		}

		global::FormXYZ.Output[] IRepository<global::FormXYZ.Output>.Find(IEnumerable<string> uris) { return Find(uris); }

	}

}
