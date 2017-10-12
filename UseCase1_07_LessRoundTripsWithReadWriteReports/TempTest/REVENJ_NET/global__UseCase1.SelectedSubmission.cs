
namespace UseCase1
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

	
	using global::Revenj;
	using global::Revenj.DomainPatterns;
	using global::Revenj.Extensibility;

	
using global::System.Data;
using global::Revenj;
using global::Revenj.DomainPatterns;
using global::Revenj.Extensibility;
using global::Revenj.DatabasePersistence;
using global::Revenj.DatabasePersistence.Postgres;
using global::Revenj.DatabasePersistence.Postgres.Converters;


	
	
	
	[Serializable]
	[DataContract(Namespace="")] public partial class SelectedSubmission : global::Revenj.DomainPatterns.IReport<SelectedSubmission.Result>
	{
		
		
		public SelectedSubmission()
			
		{
			
			
		}

		
	internal void PopulateDatabase(IServiceProvider locator, SelectedSubmission.Result result, HashSet<string> processed)
	{
		
		var query = locator.Resolve<IDatabaseQuery>();
		var cms = Common.Utility.UseThreadLocalStream();
		var sw = cms.GetWriter();
		sw.Write("SELECT \"UseCase1\".\"SelectedSubmission\"(");
		
		
			sw.Write("'");
			_DatabaseCommon.Utility.StringToTuple(this.uri).InsertRecord(sw, cms.SmallBuffer, string.Empty, PostgresTuple.EscapeQuote);
			sw.Write("'");
		sw.Write(")");
		sw.Flush();
		cms.Position = 0;
		var com = PostgresCommandFactory.NewCommand(cms, "SELECT \"UseCase1\".\"SelectedSubmission\"(:args)");
		query.Execute(com, dr => PopulateFromReader(dr.GetValue(0), locator, result, processed, cms));
	}

	internal void PopulateFromReader(object obj, IServiceProvider locator, SelectedSubmission.Result result, HashSet<string> processed, Revenj.Utility.ChunkedMemoryStream cms)
	{
		var str = obj as string;
		Revenj.Utility.BufferedTextReader reader;
		System.IO.TextReader _tr = null;
		if (str != null)
			reader = cms.UseBufferedReader(str);
		else
		{
			_tr = obj as System.IO.TextReader ?? new System.IO.StringReader(obj.ToString());
			reader = cms.UseBufferedReader(_tr);
		}
		reader.Read(2);
		
		result.uri = this.uri;
		result.Submission = this.Submission = _DatabaseCommon.FactoryUseCase1_Submission.SubmissionConverter.CreateFromRecord(reader, 1, locator);
		processed.Add("Submission");
		if (_tr != null) _tr.Dispose();
	}
		
		
		[DataMember(EmitDefaultValue=false,Name="uri")]
		internal string _uri;

		public string uri
		{
			
			get 
			{
				
				return this._uri; 
			}
			
			set 
			{
				
				this._uri = value; 
				
			}
		}

		private Expression<Func<global::UseCase1.Submission, bool>> _filterSubmission { get { return it => it.URI == uri; } }
		private global::UseCase1.Submission Submission;
		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
		}

		
		internal SelectedSubmission(IServiceProvider locator)
			
		{
			
			
		}

		
		public Result Populate(IServiceProvider locator)
		{
			var __processed = new HashSet<string>();
			var __result = new Result();
			
			PopulateDatabase(locator, __result, __processed);
			if(!__processed.Contains("Submission"))
			{
				
			var __SubmissionRepository = locator.Resolve<IQueryableRepository<global::UseCase1.Submission>>();
			var __querySubmission = __SubmissionRepository.Query(new _SubmissionSpecification_(this)); 
			this.Submission = __querySubmission.FirstOrDefault();
			__result.Submission = this.Submission;
				__processed.Add("Submission");
			}
			return __result;
		}
	}

}
