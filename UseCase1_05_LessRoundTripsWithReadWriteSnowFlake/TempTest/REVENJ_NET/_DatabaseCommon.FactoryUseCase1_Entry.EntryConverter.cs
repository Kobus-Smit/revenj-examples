
namespace _DatabaseCommon.FactoryUseCase1_Entry
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


	
	
	internal class EntryConverter : IPostgresTypeConverter
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
			return CreateTupleFrom(instance as global::UseCase1.Entry);
		}

		public static IPostgresTuple CreateExtendedTupleFrom(global::UseCase1.Entry item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			items[ExtendedProperty_Description_Index] = _DatabaseCommon.Utility.StringToTuple(item.Description);
			items[ExtendedProperty_ColumnName_Index] = _DatabaseCommon.Utility.StringToTuple(item.ColumnName);
			items[ExtendedProperty_DataType_Index] = _DatabaseCommon.FactoryUseCase1_DataType.DataTypeConverter.CreateTupleFrom(item.DataType);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateExtendedRecordTupleFrom(global::UseCase1.Entry item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			if (useColumn[ExtendedProperty_Description_Index]) items[ExtendedProperty_Description_Index] = _DatabaseCommon.Utility.StringToTuple(item.Description);
			if (useColumn[ExtendedProperty_ColumnName_Index]) items[ExtendedProperty_ColumnName_Index] = _DatabaseCommon.Utility.StringToTuple(item.ColumnName);
			if (useColumn[ExtendedProperty_DataType_Index]) items[ExtendedProperty_DataType_Index] = _DatabaseCommon.FactoryUseCase1_DataType.DataTypeConverter.CreateTupleFrom(item.DataType);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateTupleFrom(global::UseCase1.Entry item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			items[Property_Description_Index] = _DatabaseCommon.Utility.StringToTuple(item.Description);
			items[Property_ColumnName_Index] = _DatabaseCommon.Utility.StringToTuple(item.ColumnName);
			items[Property_DataType_Index] = _DatabaseCommon.FactoryUseCase1_DataType.DataTypeConverter.CreateTupleFrom(item.DataType);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateRecordTupleFrom(global::UseCase1.Entry item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			if (useColumn[Property_Description_Index]) items[Property_Description_Index] = _DatabaseCommon.Utility.StringToTuple(item.Description);
			if (useColumn[Property_ColumnName_Index]) items[Property_ColumnName_Index] = _DatabaseCommon.Utility.StringToTuple(item.ColumnName);
			if (useColumn[Property_DataType_Index]) items[Property_DataType_Index] = _DatabaseCommon.FactoryUseCase1_DataType.DataTypeConverter.CreateTupleFrom(item.DataType);
			return RecordTuple.From(items);
		}

		private static int ColumnCount;
		private static int ExtendedColumnCount;

		internal static void InitializeProperties(System.Data.DataTable columnsInfo)
		{
			System.Data.DataRow row = null;
			
			ColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = 'Entry'").Length;
			ExtendedColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = '-ngs_Entry_type-'").Length;
			
			ReaderConfiguration = new Action<global::UseCase1.Entry, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ColumnCount > 0 ? ColumnCount : 1];
			ReaderExtendedConfiguration = new Action<global::UseCase1.Entry, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ExtendedColumnCount > 0 ? ExtendedColumnCount : 1];
			for(int i = 0;i < ColumnCount; i++)
				ReaderConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ColumnCount != ReaderConfiguration.Length)
				ReaderConfiguration[0] = (agg, tr, c, sl) => tr.Read();
			for(int i = 0;i < ExtendedColumnCount; i++)
				ReaderExtendedConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ExtendedColumnCount != ReaderExtendedConfiguration.Length)
				ReaderExtendedConfiguration[0] = (agg, tr, c, sl) => tr.Read();
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Entry", "Description" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Description in type UseCase1.Entry. Check if database is out of sync with code");
			Property_Description_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Description_Index] = (item, reader, context, locator) => item._Description = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Entry_type-", "Description" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Description in type UseCase1.Entry. Check if database is out of sync with code");
			ExtendedProperty_Description_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Description_Index] = (item, reader, context, locator) => item._Description = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Entry", "ColumnName" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ColumnName in type UseCase1.Entry. Check if database is out of sync with code");
			Property_ColumnName_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_ColumnName_Index] = (item, reader, context, locator) => item._ColumnName = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Entry_type-", "ColumnName" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column ColumnName in type UseCase1.Entry. Check if database is out of sync with code");
			ExtendedProperty_ColumnName_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_ColumnName_Index] = (item, reader, context, locator) => item._ColumnName = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "Entry", "DataType" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column DataType in type UseCase1.Entry. Check if database is out of sync with code");
			Property_DataType_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_DataType_Index] = (item, reader, context, locator) => item._DataType = _DatabaseCommon.FactoryUseCase1_DataType.DataTypeConverter.ParseFromPostgres(reader);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_Entry_type-", "DataType" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column DataType in type UseCase1.Entry. Check if database is out of sync with code");
			ExtendedProperty_DataType_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_DataType_Index] = (item, reader, context, locator) => item._DataType = _DatabaseCommon.FactoryUseCase1_DataType.DataTypeConverter.ParseFromPostgres(reader);
			
		}

		private static Action<global::UseCase1.Entry, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderConfiguration;
		private static Action<global::UseCase1.Entry, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderExtendedConfiguration;

		public static global::UseCase1.Entry CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.Entry CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.Entry(locator);
			foreach (var config in ReaderConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			return item;
		}

		public static global::UseCase1.Entry CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromExtendedRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.Entry CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.Entry(locator);
			foreach (var config in ReaderExtendedConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			return item;
		}

		
		private static int Property_Description_Index;
		private static int ExtendedProperty_Description_Index;
		private static int Property_ColumnName_Index;
		private static int ExtendedProperty_ColumnName_Index;
		private static int Property_DataType_Index;
		private static int ExtendedProperty_DataType_Index;
	}

}
