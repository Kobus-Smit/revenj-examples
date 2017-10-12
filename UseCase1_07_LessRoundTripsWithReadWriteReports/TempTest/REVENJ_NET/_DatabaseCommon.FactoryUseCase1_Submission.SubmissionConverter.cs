
namespace _DatabaseCommon.FactoryUseCase1_Submission
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


	
	
	internal class SubmissionConverter : IPostgresTypeConverter
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
			return CreateTupleFrom(instance as global::UseCase1.Submission);
		}

		public static IPostgresTuple CreateExtendedTupleFrom(global::UseCase1.Submission item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			items[ExtendedProperty_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (item.CustomerURI != null)items[ExtendedProperty_CustomerURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.CustomerURI);;
			items[ExtendedProperty_CustomerID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.CustomerID);
			if (item.FormURI != null)items[ExtendedProperty_FormURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.FormURI);;
			items[ExtendedProperty_FormID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.FormID);
			items[ExtendedProperty_Comments_Index] = _DatabaseCommon.Utility.StringToTuple(item.Comments);
			items[ExtendedProperty_Date_Index] = _DatabaseCommon.Utility.TimestampToTuple(item.Date);
			items[ExtendedProperty_InputsBytes_Index] = _DatabaseCommon.Utility.BinaryToTuple(item.InputsBytes);
			items[ExtendedProperty_OutputBytes_Index] = _DatabaseCommon.Utility.BinaryToTuple(item.OutputBytes);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateExtendedRecordTupleFrom(global::UseCase1.Submission item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			if (useColumn[ExtendedProperty_ID_Index]) items[ExtendedProperty_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (item.CustomerURI != null)if (useColumn[ExtendedProperty_CustomerURI_Index]) items[ExtendedProperty_CustomerURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.CustomerURI);;
			if (useColumn[ExtendedProperty_CustomerID_Index]) items[ExtendedProperty_CustomerID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.CustomerID);
			if (item.FormURI != null)if (useColumn[ExtendedProperty_FormURI_Index]) items[ExtendedProperty_FormURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.FormURI);;
			if (useColumn[ExtendedProperty_FormID_Index]) items[ExtendedProperty_FormID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.FormID);
			if (useColumn[ExtendedProperty_Comments_Index]) items[ExtendedProperty_Comments_Index] = _DatabaseCommon.Utility.StringToTuple(item.Comments);
			if (useColumn[ExtendedProperty_Date_Index]) items[ExtendedProperty_Date_Index] = _DatabaseCommon.Utility.TimestampToTuple(item.Date);
			if (useColumn[ExtendedProperty_InputsBytes_Index]) items[ExtendedProperty_InputsBytes_Index] = _DatabaseCommon.Utility.BinaryToTuple(item.InputsBytes);
			if (useColumn[ExtendedProperty_OutputBytes_Index]) items[ExtendedProperty_OutputBytes_Index] = _DatabaseCommon.Utility.BinaryToTuple(item.OutputBytes);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateTupleFrom(global::UseCase1.Submission item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			items[Property_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (item.CustomerURI != null)items[Property_CustomerURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.CustomerURI);;
			items[Property_CustomerID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.CustomerID);
			if (item.FormURI != null)items[Property_FormURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.FormURI);;
			items[Property_FormID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.FormID);
			items[Property_Comments_Index] = _DatabaseCommon.Utility.StringToTuple(item.Comments);
			items[Property_Date_Index] = _DatabaseCommon.Utility.TimestampToTuple(item.Date);
			items[Property_InputsBytes_Index] = _DatabaseCommon.Utility.BinaryToTuple(item.InputsBytes);
			items[Property_OutputBytes_Index] = _DatabaseCommon.Utility.BinaryToTuple(item.OutputBytes);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateRecordTupleFrom(global::UseCase1.Submission item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			if (useColumn[Property_ID_Index]) items[Property_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (item.CustomerURI != null)if (useColumn[Property_CustomerURI_Index]) items[Property_CustomerURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.CustomerURI);;
			if (useColumn[Property_CustomerID_Index]) items[Property_CustomerID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.CustomerID);
			if (item.FormURI != null)if (useColumn[Property_FormURI_Index]) items[Property_FormURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.FormURI);;
			if (useColumn[Property_FormID_Index]) items[Property_FormID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.FormID);
			if (useColumn[Property_Comments_Index]) items[Property_Comments_Index] = _DatabaseCommon.Utility.StringToTuple(item.Comments);
			if (useColumn[Property_Date_Index]) items[Property_Date_Index] = _DatabaseCommon.Utility.TimestampToTuple(item.Date);
			if (useColumn[Property_InputsBytes_Index]) items[Property_InputsBytes_Index] = _DatabaseCommon.Utility.BinaryToTuple(item.InputsBytes);
			if (useColumn[Property_OutputBytes_Index]) items[Property_OutputBytes_Index] = _DatabaseCommon.Utility.BinaryToTuple(item.OutputBytes);
			return RecordTuple.From(items);
		}

		private static int ColumnCount;
		private static int ExtendedColumnCount;

		internal static void InitializeProperties(System.Data.DataTable columnsInfo)
		{
			System.Data.DataRow row = null;
			
			ColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = 'Submission_entity'").Length;
			ExtendedColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = '-ngs_Submission_type-'").Length;
			
			ReaderConfiguration = new Action<global::UseCase1.Submission, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ColumnCount > 0 ? ColumnCount : 1];
			ReaderExtendedConfiguration = new Action<global::UseCase1.Submission, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ExtendedColumnCount > 0 ? ExtendedColumnCount : 1];
			for(int i = 0;i < ColumnCount; i++)
				ReaderConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ColumnCount != ReaderConfiguration.Length)
				ReaderConfiguration[0] = (agg, tr, c, sl) => tr.Read();
			for(int i = 0;i < ExtendedColumnCount; i++)
				ReaderExtendedConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ExtendedColumnCount != ReaderExtendedConfiguration.Length)
				ReaderExtendedConfiguration[0] = (agg, tr, c, sl) => tr.Read();
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Submission_entity", "ID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ID in type UseCase1.Submission_entity. Check if database is out of sync with code");
			Property_ID_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_ID_Index] = (item, reader, context, locator) => item._ID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Submission_type-", "ID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ID in type UseCase1.Submission. Check if database is out of sync with code");
			ExtendedProperty_ID_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_ID_Index] = (item, reader, context, locator) => item._ID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Submission_entity", "CustomerURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column CustomerURI in type UseCase1.Submission_entity. Check if database is out of sync with code");
			Property_CustomerURI_Index = (short)row["column_index"] - 1;
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Submission_type-", "CustomerURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column CustomerURI in type UseCase1.Submission. Check if database is out of sync with code");
			ExtendedProperty_CustomerURI_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_CustomerURI_Index] = (item, reader, context, locator) => item._CustomerURI = StringConverter.Parse(reader, context);
			
			ReaderExtendedConfiguration[ExtendedProperty_CustomerURI_Index] = (item, reader, context, locator) => item._CustomerURI = StringConverter.Parse(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Submission_entity", "CustomerID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column CustomerID in type UseCase1.Submission_entity. Check if database is out of sync with code");
			Property_CustomerID_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_CustomerID_Index] = (item, reader, context, locator) => item._CustomerID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Submission_type-", "CustomerID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column CustomerID in type UseCase1.Submission. Check if database is out of sync with code");
			ExtendedProperty_CustomerID_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_CustomerID_Index] = (item, reader, context, locator) => item._CustomerID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Submission_entity", "FormURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column FormURI in type UseCase1.Submission_entity. Check if database is out of sync with code");
			Property_FormURI_Index = (short)row["column_index"] - 1;
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Submission_type-", "FormURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column FormURI in type UseCase1.Submission. Check if database is out of sync with code");
			ExtendedProperty_FormURI_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_FormURI_Index] = (item, reader, context, locator) => item._FormURI = StringConverter.Parse(reader, context);
			
			ReaderExtendedConfiguration[ExtendedProperty_FormURI_Index] = (item, reader, context, locator) => item._FormURI = StringConverter.Parse(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Submission_entity", "FormID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column FormID in type UseCase1.Submission_entity. Check if database is out of sync with code");
			Property_FormID_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_FormID_Index] = (item, reader, context, locator) => item._FormID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Submission_type-", "FormID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column FormID in type UseCase1.Submission. Check if database is out of sync with code");
			ExtendedProperty_FormID_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_FormID_Index] = (item, reader, context, locator) => item._FormID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Submission_entity", "Comments" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Comments in type UseCase1.Submission_entity. Check if database is out of sync with code");
			Property_Comments_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Comments_Index] = (item, reader, context, locator) => item._Comments = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Submission_type-", "Comments" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Comments in type UseCase1.Submission. Check if database is out of sync with code");
			ExtendedProperty_Comments_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Comments_Index] = (item, reader, context, locator) => item._Comments = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Submission_entity", "Date" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Date in type UseCase1.Submission_entity. Check if database is out of sync with code");
			Property_Date_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Date_Index] = (item, reader, context, locator) => item._Date = _DatabaseCommon.Utility.ParseTimestamp(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Submission_type-", "Date" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Date in type UseCase1.Submission. Check if database is out of sync with code");
			ExtendedProperty_Date_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Date_Index] = (item, reader, context, locator) => item._Date = _DatabaseCommon.Utility.ParseTimestamp(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Submission_entity", "InputsBytes" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column InputsBytes in type UseCase1.Submission_entity. Check if database is out of sync with code");
			Property_InputsBytes_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_InputsBytes_Index] = (item, reader, context, locator) => item._InputsBytes = _DatabaseCommon.Utility.ParseBinary(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Submission_type-", "InputsBytes" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column InputsBytes in type UseCase1.Submission. Check if database is out of sync with code");
			ExtendedProperty_InputsBytes_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_InputsBytes_Index] = (item, reader, context, locator) => item._InputsBytes = _DatabaseCommon.Utility.ParseBinary(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Submission_entity", "OutputBytes" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column OutputBytes in type UseCase1.Submission_entity. Check if database is out of sync with code");
			Property_OutputBytes_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_OutputBytes_Index] = (item, reader, context, locator) => item._OutputBytes = _DatabaseCommon.Utility.ParseBinary(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Submission_type-", "OutputBytes" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column OutputBytes in type UseCase1.Submission. Check if database is out of sync with code");
			ExtendedProperty_OutputBytes_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_OutputBytes_Index] = (item, reader, context, locator) => item._OutputBytes = _DatabaseCommon.Utility.ParseBinary(reader, context);
			
			
			TableTuples = new bool[ColumnCount];
			PrimaryKeyUpdateTuples = new bool[ColumnCount];
			PrimaryKeyDeleteTuples = new bool[ColumnCount];
			TableTuples[Property_ID_Index] = true;
			TableTuples[Property_CustomerID_Index] = true;
			TableTuples[Property_FormID_Index] = true;
			TableTuples[Property_Comments_Index] = true;
			TableTuples[Property_Date_Index] = true;
			TableTuples[Property_InputsBytes_Index] = true;
			TableTuples[Property_OutputBytes_Index] = true;
			
			PrimaryKeyUpdateTuples[Property_ID_Index] = true;
			PrimaryKeyDeleteTuples[Property_ID_Index] = true;
		}

		private static Action<global::UseCase1.Submission, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderConfiguration;
		private static Action<global::UseCase1.Submission, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderExtendedConfiguration;

		public static global::UseCase1.Submission CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.Submission CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.Submission(locator);
			foreach (var config in ReaderConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			item.URI = _DatabaseCommon.FactoryUseCase1_Submission.SubmissionConverter.BuildURI(reader.CharBuffer, item.ID);
			item.__DataCacheCustomer = new Lazy<IDataCache<global::UseCase1.Customer>>(() => locator.Resolve<IDataCache<global::UseCase1.Customer>>());
			item.__DataCacheForm = new Lazy<IDataCache<global::UseCase1.Form>>(() => locator.Resolve<IDataCache<global::UseCase1.Form>>());
			item.__ResetChangeTracking();
			return item;
		}

		public static global::UseCase1.Submission CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromExtendedRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.Submission CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.Submission(locator);
			foreach (var config in ReaderExtendedConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			item.URI = _DatabaseCommon.FactoryUseCase1_Submission.SubmissionConverter.BuildURI(reader.CharBuffer, item.ID);
			item.__DataCacheCustomer = new Lazy<IDataCache<global::UseCase1.Customer>>(() => locator.Resolve<IDataCache<global::UseCase1.Customer>>());
			item.__DataCacheForm = new Lazy<IDataCache<global::UseCase1.Form>>(() => locator.Resolve<IDataCache<global::UseCase1.Form>>());
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
		private static int Property_CustomerURI_Index;
		private static int ExtendedProperty_CustomerURI_Index;
		private static int Property_CustomerID_Index;
		private static int ExtendedProperty_CustomerID_Index;
		private static int Property_FormURI_Index;
		private static int ExtendedProperty_FormURI_Index;
		private static int Property_FormID_Index;
		private static int ExtendedProperty_FormID_Index;
		private static int Property_Comments_Index;
		private static int ExtendedProperty_Comments_Index;
		private static int Property_Date_Index;
		private static int ExtendedProperty_Date_Index;
		private static int Property_InputsBytes_Index;
		private static int ExtendedProperty_InputsBytes_Index;
		private static int Property_OutputBytes_Index;
		private static int ExtendedProperty_OutputBytes_Index;
	}

}
