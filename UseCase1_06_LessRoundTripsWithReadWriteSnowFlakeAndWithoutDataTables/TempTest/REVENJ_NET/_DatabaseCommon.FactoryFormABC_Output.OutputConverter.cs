
namespace _DatabaseCommon.FactoryFormABC_Output
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


	
	
	internal class OutputConverter : IPostgresTypeConverter
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
			return CreateTupleFrom(instance as global::FormABC.Output);
		}

		public static IPostgresTuple CreateExtendedTupleFrom(global::FormABC.Output item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			items[ExtendedProperty_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (item.SubmissionURI != null)items[ExtendedProperty_SubmissionURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.SubmissionURI);;
			items[ExtendedProperty_SubmissionID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.SubmissionID);
			items[ExtendedProperty_ABC_Index] = _DatabaseCommon.Utility.DecimalToTuple(item.ABC);
			items[ExtendedProperty_XYZ_Index] = _DatabaseCommon.Utility.DecimalToTuple(item.XYZ);
			items[ExtendedProperty_HasQQQ_Index] = _DatabaseCommon.Utility.BoolToTuple(item.HasQQQ);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateExtendedRecordTupleFrom(global::FormABC.Output item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			if (useColumn[ExtendedProperty_ID_Index]) items[ExtendedProperty_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (item.SubmissionURI != null)if (useColumn[ExtendedProperty_SubmissionURI_Index]) items[ExtendedProperty_SubmissionURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.SubmissionURI);;
			if (useColumn[ExtendedProperty_SubmissionID_Index]) items[ExtendedProperty_SubmissionID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.SubmissionID);
			if (useColumn[ExtendedProperty_ABC_Index]) items[ExtendedProperty_ABC_Index] = _DatabaseCommon.Utility.DecimalToTuple(item.ABC);
			if (useColumn[ExtendedProperty_XYZ_Index]) items[ExtendedProperty_XYZ_Index] = _DatabaseCommon.Utility.DecimalToTuple(item.XYZ);
			if (useColumn[ExtendedProperty_HasQQQ_Index]) items[ExtendedProperty_HasQQQ_Index] = _DatabaseCommon.Utility.BoolToTuple(item.HasQQQ);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateTupleFrom(global::FormABC.Output item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			items[Property_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (item.SubmissionURI != null)items[Property_SubmissionURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.SubmissionURI);;
			items[Property_SubmissionID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.SubmissionID);
			items[Property_ABC_Index] = _DatabaseCommon.Utility.DecimalToTuple(item.ABC);
			items[Property_XYZ_Index] = _DatabaseCommon.Utility.DecimalToTuple(item.XYZ);
			items[Property_HasQQQ_Index] = _DatabaseCommon.Utility.BoolToTuple(item.HasQQQ);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateRecordTupleFrom(global::FormABC.Output item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			if (useColumn[Property_ID_Index]) items[Property_ID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.ID);
			if (item.SubmissionURI != null)if (useColumn[Property_SubmissionURI_Index]) items[Property_SubmissionURI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.SubmissionURI);;
			if (useColumn[Property_SubmissionID_Index]) items[Property_SubmissionID_Index] = _DatabaseCommon.Utility.GuidToTuple(item.SubmissionID);
			if (useColumn[Property_ABC_Index]) items[Property_ABC_Index] = _DatabaseCommon.Utility.DecimalToTuple(item.ABC);
			if (useColumn[Property_XYZ_Index]) items[Property_XYZ_Index] = _DatabaseCommon.Utility.DecimalToTuple(item.XYZ);
			if (useColumn[Property_HasQQQ_Index]) items[Property_HasQQQ_Index] = _DatabaseCommon.Utility.BoolToTuple(item.HasQQQ);
			return RecordTuple.From(items);
		}

		private static int ColumnCount;
		private static int ExtendedColumnCount;

		internal static void InitializeProperties(System.Data.DataTable columnsInfo)
		{
			System.Data.DataRow row = null;
			
			ColumnCount = columnsInfo.Select("type_schema = 'FormABC' AND type_name = 'Output_entity'").Length;
			ExtendedColumnCount = columnsInfo.Select("type_schema = 'FormABC' AND type_name = '-ngs_Output_type-'").Length;
			
			ReaderConfiguration = new Action<global::FormABC.Output, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ColumnCount > 0 ? ColumnCount : 1];
			ReaderExtendedConfiguration = new Action<global::FormABC.Output, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ExtendedColumnCount > 0 ? ExtendedColumnCount : 1];
			for(int i = 0;i < ColumnCount; i++)
				ReaderConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ColumnCount != ReaderConfiguration.Length)
				ReaderConfiguration[0] = (agg, tr, c, sl) => tr.Read();
			for(int i = 0;i < ExtendedColumnCount; i++)
				ReaderExtendedConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ExtendedColumnCount != ReaderExtendedConfiguration.Length)
				ReaderExtendedConfiguration[0] = (agg, tr, c, sl) => tr.Read();
				
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "Output_entity", "ID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ID in type FormABC.Output_entity. Check if database is out of sync with code");
			Property_ID_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_ID_Index] = (item, reader, context, locator) => item._ID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "-ngs_Output_type-", "ID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ID in type FormABC.Output. Check if database is out of sync with code");
			ExtendedProperty_ID_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_ID_Index] = (item, reader, context, locator) => item._ID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "Output_entity", "SubmissionURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column SubmissionURI in type FormABC.Output_entity. Check if database is out of sync with code");
			Property_SubmissionURI_Index = (short)row["column_index"] - 1;
				
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "-ngs_Output_type-", "SubmissionURI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column SubmissionURI in type FormABC.Output. Check if database is out of sync with code");
			ExtendedProperty_SubmissionURI_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_SubmissionURI_Index] = (item, reader, context, locator) => item._SubmissionURI = StringConverter.Parse(reader, context);
			
			ReaderExtendedConfiguration[ExtendedProperty_SubmissionURI_Index] = (item, reader, context, locator) => item._SubmissionURI = StringConverter.Parse(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "Output_entity", "SubmissionID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column SubmissionID in type FormABC.Output_entity. Check if database is out of sync with code");
			Property_SubmissionID_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_SubmissionID_Index] = (item, reader, context, locator) => item._SubmissionID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "-ngs_Output_type-", "SubmissionID" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column SubmissionID in type FormABC.Output. Check if database is out of sync with code");
			ExtendedProperty_SubmissionID_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_SubmissionID_Index] = (item, reader, context, locator) => item._SubmissionID = _DatabaseCommon.Utility.ParseGuid(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "Output_entity", "ABC" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ABC in type FormABC.Output_entity. Check if database is out of sync with code");
			Property_ABC_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_ABC_Index] = (item, reader, context, locator) => item._ABC = _DatabaseCommon.Utility.ParseDecimal(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "-ngs_Output_type-", "ABC" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ABC in type FormABC.Output. Check if database is out of sync with code");
			ExtendedProperty_ABC_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_ABC_Index] = (item, reader, context, locator) => item._ABC = _DatabaseCommon.Utility.ParseDecimal(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "Output_entity", "XYZ" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column XYZ in type FormABC.Output_entity. Check if database is out of sync with code");
			Property_XYZ_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_XYZ_Index] = (item, reader, context, locator) => item._XYZ = _DatabaseCommon.Utility.ParseDecimal(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "-ngs_Output_type-", "XYZ" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column XYZ in type FormABC.Output. Check if database is out of sync with code");
			ExtendedProperty_XYZ_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_XYZ_Index] = (item, reader, context, locator) => item._XYZ = _DatabaseCommon.Utility.ParseDecimal(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "Output_entity", "HasQQQ" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column HasQQQ in type FormABC.Output_entity. Check if database is out of sync with code");
			Property_HasQQQ_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_HasQQQ_Index] = (item, reader, context, locator) => item._HasQQQ = _DatabaseCommon.Utility.ParseBool(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "FormABC", "-ngs_Output_type-", "HasQQQ" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column HasQQQ in type FormABC.Output. Check if database is out of sync with code");
			ExtendedProperty_HasQQQ_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_HasQQQ_Index] = (item, reader, context, locator) => item._HasQQQ = _DatabaseCommon.Utility.ParseBool(reader, context);
			
			
			TableTuples = new bool[ColumnCount];
			PrimaryKeyUpdateTuples = new bool[ColumnCount];
			PrimaryKeyDeleteTuples = new bool[ColumnCount];
			TableTuples[Property_ID_Index] = true;
			TableTuples[Property_SubmissionID_Index] = true;
			TableTuples[Property_ABC_Index] = true;
			TableTuples[Property_XYZ_Index] = true;
			TableTuples[Property_HasQQQ_Index] = true;
			
			PrimaryKeyUpdateTuples[Property_ID_Index] = true;
			PrimaryKeyDeleteTuples[Property_ID_Index] = true;
		}

		private static Action<global::FormABC.Output, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderConfiguration;
		private static Action<global::FormABC.Output, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderExtendedConfiguration;

		public static global::FormABC.Output CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::FormABC.Output CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::FormABC.Output(locator);
			foreach (var config in ReaderConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			item.URI = _DatabaseCommon.FactoryFormABC_Output.OutputConverter.BuildURI(reader.CharBuffer, item.ID);
			item.__DataCacheSubmission = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
			item.__ResetChangeTracking();
			return item;
		}

		public static global::FormABC.Output CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromExtendedRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::FormABC.Output CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::FormABC.Output(locator);
			foreach (var config in ReaderExtendedConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			item.URI = _DatabaseCommon.FactoryFormABC_Output.OutputConverter.BuildURI(reader.CharBuffer, item.ID);
			item.__DataCacheSubmission = new Lazy<IDataCache<global::UseCase1.Submission>>(() => locator.Resolve<IDataCache<global::UseCase1.Submission>>());
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
		private static int Property_SubmissionURI_Index;
		private static int ExtendedProperty_SubmissionURI_Index;
		private static int Property_SubmissionID_Index;
		private static int ExtendedProperty_SubmissionID_Index;
		private static int Property_ABC_Index;
		private static int ExtendedProperty_ABC_Index;
		private static int Property_XYZ_Index;
		private static int ExtendedProperty_XYZ_Index;
		private static int Property_HasQQQ_Index;
		private static int ExtendedProperty_HasQQQ_Index;
	}

}
