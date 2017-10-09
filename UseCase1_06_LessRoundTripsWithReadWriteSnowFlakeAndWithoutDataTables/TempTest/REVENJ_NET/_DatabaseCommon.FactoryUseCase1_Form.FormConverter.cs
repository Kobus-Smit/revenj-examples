
namespace _DatabaseCommon.FactoryUseCase1_Form
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	
	
	using global::System.Globalization;
	using global::System.IO;
	using global::Revenj;
	using global::Revenj.DomainPatterns;
	using global::Revenj.Extensibility;
	using global::Revenj.DatabasePersistence;
	using global::Revenj.DatabasePersistence.Postgres;
	using global::Revenj.DatabasePersistence.Postgres.Converters;
	using global::Revenj.DomainPatterns;
	using global::Revenj.Utility;


	
	
	internal class FormConverter : IPostgresTypeConverter
	{
		public object CreateInstance(object value, Revenj.Utility.BufferedTextReader reader, IServiceProvider locator)
		{
			if (value == null)
				return null;
			var str = value as string;
			if (str != null)
				return CreateFromRecord(reader.Reuse(str), 0, locator);
			using(var sr = value as System.IO.TextReader ?? new System.IO.StringReader(value.ToString()))
				return CreateFromRecord(reader.Reuse(sr), 0, locator);
		}

		public IPostgresTuple ToTuple(object instance)
		{
			return CreateTupleFrom(instance as global::UseCase1.Form);
		}

		public static IPostgresTuple CreateExtendedTupleFrom(global::UseCase1.Form item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			items[ExtendedProperty_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			items[ExtendedProperty_Name_Index] = _DatabaseCommon.Utility.StringToTuple(item.Name);
			items[ExtendedProperty_Schema_Index] = _DatabaseCommon.Utility.StringToTuple(item.Schema);
			if (item.GroupURI != null)items[ExtendedProperty_GroupURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.GroupURI);;
			items[ExtendedProperty_GroupID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.GroupID);
			items[ExtendedProperty_Status_Index] = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.CreateTupleFrom(item.Status);
			items[ExtendedProperty_Inputs_Index] = ArrayTuple.Create(item.Inputs, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateExtendedTupleFrom);
			items[ExtendedProperty_Outputs_Index] = ArrayTuple.Create(item.Outputs, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateExtendedTupleFrom);
			if (item.SubmissionsURI != null) items[ExtendedProperty_SubmissionsURI_Index] = ArrayTuple.Create(item.SubmissionsURI, it => new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(it));;
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateExtendedRecordTupleFrom(global::UseCase1.Form item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			if (useColumn[ExtendedProperty_ID_Index]) items[ExtendedProperty_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (useColumn[ExtendedProperty_Name_Index]) items[ExtendedProperty_Name_Index] = _DatabaseCommon.Utility.StringToTuple(item.Name);
			if (useColumn[ExtendedProperty_Schema_Index]) items[ExtendedProperty_Schema_Index] = _DatabaseCommon.Utility.StringToTuple(item.Schema);
			if (item.GroupURI != null)if (useColumn[ExtendedProperty_GroupURI_Index]) items[ExtendedProperty_GroupURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.GroupURI);;
			if (useColumn[ExtendedProperty_GroupID_Index]) items[ExtendedProperty_GroupID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.GroupID);
			if (useColumn[ExtendedProperty_Status_Index]) items[ExtendedProperty_Status_Index] = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.CreateTupleFrom(item.Status);
			if (useColumn[ExtendedProperty_Inputs_Index]) items[ExtendedProperty_Inputs_Index] = ArrayTuple.Create(item.Inputs, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateExtendedTupleFrom);
			if (useColumn[ExtendedProperty_Outputs_Index]) items[ExtendedProperty_Outputs_Index] = ArrayTuple.Create(item.Outputs, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateExtendedTupleFrom);
			if (item.SubmissionsURI != null) if (useColumn[ExtendedProperty_SubmissionsURI_Index]) items[ExtendedProperty_SubmissionsURI_Index] = ArrayTuple.Create(item.SubmissionsURI, it => new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(it));;
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateTupleFrom(global::UseCase1.Form item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			items[Property_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			items[Property_Name_Index] = _DatabaseCommon.Utility.StringToTuple(item.Name);
			items[Property_Schema_Index] = _DatabaseCommon.Utility.StringToTuple(item.Schema);
			if (item.GroupURI != null)items[Property_GroupURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.GroupURI);;
			items[Property_GroupID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.GroupID);
			items[Property_Status_Index] = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.CreateTupleFrom(item.Status);
			items[Property_Inputs_Index] = ArrayTuple.Create(item.Inputs, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateTupleFrom);
			items[Property_Outputs_Index] = ArrayTuple.Create(item.Outputs, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateTupleFrom);
			if (item.SubmissionsURI != null) items[Property_SubmissionsURI_Index] = ArrayTuple.Create(item.SubmissionsURI, it => new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(it));;
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateRecordTupleFrom(global::UseCase1.Form item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			if (useColumn[Property_ID_Index]) items[Property_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (useColumn[Property_Name_Index]) items[Property_Name_Index] = _DatabaseCommon.Utility.StringToTuple(item.Name);
			if (useColumn[Property_Schema_Index]) items[Property_Schema_Index] = _DatabaseCommon.Utility.StringToTuple(item.Schema);
			if (item.GroupURI != null)if (useColumn[Property_GroupURI_Index]) items[Property_GroupURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.GroupURI);;
			if (useColumn[Property_GroupID_Index]) items[Property_GroupID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.GroupID);
			if (useColumn[Property_Status_Index]) items[Property_Status_Index] = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.CreateTupleFrom(item.Status);
			if (useColumn[Property_Inputs_Index]) items[Property_Inputs_Index] = ArrayTuple.Create(item.Inputs, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateTupleFrom);
			if (useColumn[Property_Outputs_Index]) items[Property_Outputs_Index] = ArrayTuple.Create(item.Outputs, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateTupleFrom);
			if (item.SubmissionsURI != null) if (useColumn[Property_SubmissionsURI_Index]) items[Property_SubmissionsURI_Index] = ArrayTuple.Create(item.SubmissionsURI, it => new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(it));;
			return RecordTuple.From(items);
		}

		private static int ColumnCount;
		private static int ExtendedColumnCount;

		internal static void InitializeProperties(System.Data.DataTable columnsInfo)
		{
			System.Data.DataRow row = null;
			
			ColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = 'Form_entity'").Length;
			ExtendedColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = '-ngs_Form_type-'").Length;
			
			ReaderConfiguration = new Action<global::UseCase1.Form, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ColumnCount > 0 ? ColumnCount : 1];
			ReaderExtendedConfiguration = new Action<global::UseCase1.Form, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ExtendedColumnCount > 0 ? ExtendedColumnCount : 1];
			for(int i = 0;i < ColumnCount; i++)
				ReaderConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ColumnCount != ReaderConfiguration.Length)
				ReaderConfiguration[0] = (agg, tr, c, sl) => tr.Read();
			for(int i = 0;i < ExtendedColumnCount; i++)
				ReaderExtendedConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ExtendedColumnCount != ReaderExtendedConfiguration.Length)
				ReaderExtendedConfiguration[0] = (agg, tr, c, sl) => tr.Read();
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Form_entity", "ID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ID in type UseCase1.Form_entity. Check if database is out of sync with code");
			Property_ID_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_ID_Index] = (item, reader, context, locator) => item._ID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Form_type-", "ID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ID in type UseCase1.Form. Check if database is out of sync with code");
			ExtendedProperty_ID_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_ID_Index] = (item, reader, context, locator) => item._ID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Form_entity", "Name" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Name in type UseCase1.Form_entity. Check if database is out of sync with code");
			Property_Name_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Name_Index] = (item, reader, context, locator) => item._Name = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Form_type-", "Name" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Name in type UseCase1.Form. Check if database is out of sync with code");
			ExtendedProperty_Name_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Name_Index] = (item, reader, context, locator) => item._Name = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Form_entity", "Schema" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Schema in type UseCase1.Form_entity. Check if database is out of sync with code");
			Property_Schema_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Schema_Index] = (item, reader, context, locator) => item._Schema = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Form_type-", "Schema" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Schema in type UseCase1.Form. Check if database is out of sync with code");
			ExtendedProperty_Schema_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Schema_Index] = (item, reader, context, locator) => item._Schema = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Form_entity", "GroupURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column GroupURI in type UseCase1.Form_entity. Check if database is out of sync with code");
			Property_GroupURI_Index = (short)row["column_index"] - 1;
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Form_type-", "GroupURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column GroupURI in type UseCase1.Form. Check if database is out of sync with code");
			ExtendedProperty_GroupURI_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_GroupURI_Index] = (item, reader, context, locator) => item._GroupURI = StringConverter.Parse(reader, context);
			
			ReaderExtendedConfiguration[ExtendedProperty_GroupURI_Index] = (item, reader, context, locator) => item._GroupURI = StringConverter.Parse(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Form_entity", "GroupID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column GroupID in type UseCase1.Form_entity. Check if database is out of sync with code");
			Property_GroupID_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_GroupID_Index] = (item, reader, context, locator) => item._GroupID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Form_type-", "GroupID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column GroupID in type UseCase1.Form. Check if database is out of sync with code");
			ExtendedProperty_GroupID_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_GroupID_Index] = (item, reader, context, locator) => item._GroupID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Form_entity", "Status" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Status in type UseCase1.Form_entity. Check if database is out of sync with code");
			Property_Status_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Status_Index] = (item, reader, context, locator) => item._Status = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.ParseFromPostgres(reader);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Form_type-", "Status" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Status in type UseCase1.Form. Check if database is out of sync with code");
			ExtendedProperty_Status_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Status_Index] = (item, reader, context, locator) => item._Status = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.ParseFromPostgres(reader);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Form_entity", "Inputs" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Inputs in type UseCase1.Form_entity. Check if database is out of sync with code");
			Property_Inputs_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Inputs_Index] = (item, reader, context, locator) => { var __list = PostgresTypedArray.ParseCollection(reader, context, locator, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateFromRecord); if (__list != null) item._Inputs = __list; else item._Inputs = new System.Collections.Generic.List<global::UseCase1.Entry>(); };
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Form_type-", "Inputs" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Inputs in type UseCase1.Form. Check if database is out of sync with code");
			ExtendedProperty_Inputs_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Inputs_Index] = (item, reader, context, locator) => { var __list = PostgresTypedArray.ParseCollection(reader, context, locator, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateFromExtendedRecord); if (__list != null) item._Inputs = __list; else item._Inputs = new System.Collections.Generic.List<global::UseCase1.Entry>(); };
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Form_entity", "Outputs" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Outputs in type UseCase1.Form_entity. Check if database is out of sync with code");
			Property_Outputs_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Outputs_Index] = (item, reader, context, locator) => { var __list = PostgresTypedArray.ParseCollection(reader, context, locator, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateFromRecord); if (__list != null) item._Outputs = __list; else item._Outputs = new System.Collections.Generic.List<global::UseCase1.Entry>(); };
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Form_type-", "Outputs" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Outputs in type UseCase1.Form. Check if database is out of sync with code");
			ExtendedProperty_Outputs_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Outputs_Index] = (item, reader, context, locator) => { var __list = PostgresTypedArray.ParseCollection(reader, context, locator, _DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.CreateFromExtendedRecord); if (__list != null) item._Outputs = __list; else item._Outputs = new System.Collections.Generic.List<global::UseCase1.Entry>(); };
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Form_entity", "SubmissionsURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column SubmissionsURI in type UseCase1.Form_entity. Check if database is out of sync with code");
			Property_SubmissionsURI_Index = (short)row["column_index"] - 1;
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Form_type-", "SubmissionsURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column SubmissionsURI in type UseCase1.Form. Check if database is out of sync with code");
			ExtendedProperty_SubmissionsURI_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_SubmissionsURI_Index] = (item, reader, context, locator) => { var __list = StringConverter.ParseCollection(reader, context, true); if (__list != null) item._SubmissionsURI = __list.ToArray(); else item._SubmissionsURI = new string[0]; };
			
			ReaderExtendedConfiguration[ExtendedProperty_SubmissionsURI_Index] = (item, reader, context, locator) => { var __list = StringConverter.ParseCollection(reader, context, true); if (__list != null) item._SubmissionsURI = __list.ToArray(); else item._SubmissionsURI = new string[0]; };
			
			
			TableTuples = new bool[ColumnCount];
			PrimaryKeyUpdateTuples = new bool[ColumnCount];
			PrimaryKeyDeleteTuples = new bool[ColumnCount];
			TableTuples[Property_ID_Index] = true;
			TableTuples[Property_Name_Index] = true;
			TableTuples[Property_Schema_Index] = true;
			TableTuples[Property_GroupID_Index] = true;
			TableTuples[Property_Status_Index] = true;
			TableTuples[Property_Inputs_Index] = true;
			TableTuples[Property_Outputs_Index] = true;
			TableTuples[Property_SubmissionsURI_Index] = true;
			
			PrimaryKeyUpdateTuples[Property_ID_Index] = true;
			PrimaryKeyDeleteTuples[Property_ID_Index] = true;
		}

		private static Action<global::UseCase1.Form, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderConfiguration;
		private static Action<global::UseCase1.Form, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderExtendedConfiguration;

		public static global::UseCase1.Form CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.Form CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.Form(locator);
			foreach (var config in ReaderConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			item.URI = _DatabaseCommon.FactoryUseCase1_Form.FormConverter.BuildURI(reader.CharBuffer, item.ID);
			item.__DataCacheGroup = new Lazy<IDataCache<global::UseCase1.FormGroup>>(() => locator.Resolve<IDataCache<global::UseCase1.FormGroup>>());
			item.__DataCacheSubmissions = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
			item.__ResetChangeTracking();
			return item;
		}

		public static global::UseCase1.Form CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromExtendedRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.Form CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.Form(locator);
			foreach (var config in ReaderExtendedConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			item.URI = _DatabaseCommon.FactoryUseCase1_Form.FormConverter.BuildURI(reader.CharBuffer, item.ID);
			item.__DataCacheGroup = new Lazy<IDataCache<global::UseCase1.FormGroup>>(() => locator.Resolve<IDataCache<global::UseCase1.FormGroup>>());
			item.__DataCacheSubmissions = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
			item.__ResetChangeTracking();
			return item;
		}

		
		
		internal static bool[] TableTuples;
		internal static bool[] PrimaryKeyUpdateTuples;
		internal static bool[] PrimaryKeyDeleteTuples;
		private static int Property_ID_Index;
		private static int ExtendedProperty_ID_Index;
		
		internal static string BuildURI(char[] _buf, global::System.Guid ID)
		{
			int _len = 0;
			string _tmp;
			_len = _DatabaseCommon.Utility.GuidToURI(_buf, _len, ID);
			return new string(_buf, 0, _len);
		}
		
		internal static void ParseURI(IServiceProvider _locator, Revenj.Utility.ChunkedMemoryStream _cms, string URI, out global::System.Guid ID)
		{
			
			ID = _DatabaseCommon.Utility.ToGuid(URI);
		}
		private static int Property_Name_Index;
		private static int ExtendedProperty_Name_Index;
		private static int Property_Schema_Index;
		private static int ExtendedProperty_Schema_Index;
		private static int Property_GroupURI_Index;
		private static int ExtendedProperty_GroupURI_Index;
		private static int Property_GroupID_Index;
		private static int ExtendedProperty_GroupID_Index;
		private static int Property_Status_Index;
		private static int ExtendedProperty_Status_Index;
		private static int Property_Inputs_Index;
		private static int ExtendedProperty_Inputs_Index;
		private static int Property_Outputs_Index;
		private static int ExtendedProperty_Outputs_Index;
		private static int Property_SubmissionsURI_Index;
		private static int ExtendedProperty_SubmissionsURI_Index;
	}

}
