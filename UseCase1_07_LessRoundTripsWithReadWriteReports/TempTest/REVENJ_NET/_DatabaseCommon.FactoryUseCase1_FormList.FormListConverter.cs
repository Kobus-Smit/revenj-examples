
namespace _DatabaseCommon.FactoryUseCase1_FormList
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


	
	
	internal class FormListConverter : IPostgresTypeConverter
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
			return CreateTupleFrom(instance as global::UseCase1.FormList);
		}

		public static IPostgresTuple CreateExtendedTupleFrom(global::UseCase1.FormList item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			items[ExtendedProperty_URI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.URI);
			items[ExtendedProperty_Name_Index] = _DatabaseCommon.Utility.StringToTuple(item.Name);
			items[ExtendedProperty_Group_Index] = _DatabaseCommon.Utility.StringToTuple(item.Group);
			items[ExtendedProperty_Status_Index] = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.CreateTupleFrom(item.Status);
			items[ExtendedProperty_SubmissionsCount_Index] = _DatabaseCommon.Utility.IntegerToTuple(item.SubmissionsCount);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateExtendedRecordTupleFrom(global::UseCase1.FormList item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			if (useColumn[ExtendedProperty_URI_Index]) items[ExtendedProperty_URI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.URI);
			if (useColumn[ExtendedProperty_Name_Index]) items[ExtendedProperty_Name_Index] = _DatabaseCommon.Utility.StringToTuple(item.Name);
			if (useColumn[ExtendedProperty_Group_Index]) items[ExtendedProperty_Group_Index] = _DatabaseCommon.Utility.StringToTuple(item.Group);
			if (useColumn[ExtendedProperty_Status_Index]) items[ExtendedProperty_Status_Index] = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.CreateTupleFrom(item.Status);
			if (useColumn[ExtendedProperty_SubmissionsCount_Index]) items[ExtendedProperty_SubmissionsCount_Index] = _DatabaseCommon.Utility.IntegerToTuple(item.SubmissionsCount);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateTupleFrom(global::UseCase1.FormList item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			items[Property_URI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.URI);
			items[Property_Name_Index] = _DatabaseCommon.Utility.StringToTuple(item.Name);
			items[Property_Group_Index] = _DatabaseCommon.Utility.StringToTuple(item.Group);
			items[Property_Status_Index] = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.CreateTupleFrom(item.Status);
			items[Property_SubmissionsCount_Index] = _DatabaseCommon.Utility.IntegerToTuple(item.SubmissionsCount);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateRecordTupleFrom(global::UseCase1.FormList item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			if (useColumn[Property_URI_Index]) items[Property_URI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.URI);
			if (useColumn[Property_Name_Index]) items[Property_Name_Index] = _DatabaseCommon.Utility.StringToTuple(item.Name);
			if (useColumn[Property_Group_Index]) items[Property_Group_Index] = _DatabaseCommon.Utility.StringToTuple(item.Group);
			if (useColumn[Property_Status_Index]) items[Property_Status_Index] = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.CreateTupleFrom(item.Status);
			if (useColumn[Property_SubmissionsCount_Index]) items[Property_SubmissionsCount_Index] = _DatabaseCommon.Utility.IntegerToTuple(item.SubmissionsCount);
			return RecordTuple.From(items);
		}

		private static int ColumnCount;
		private static int ExtendedColumnCount;

		internal static void InitializeProperties(System.Data.DataTable columnsInfo)
		{
			System.Data.DataRow row = null;
			
			ColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = 'FormList'").Length;
			ExtendedColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = '-ngs_FormList_type-'").Length;
			
			ReaderConfiguration = new Action<global::UseCase1.FormList, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ColumnCount > 0 ? ColumnCount : 1];
			ReaderExtendedConfiguration = new Action<global::UseCase1.FormList, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ExtendedColumnCount > 0 ? ExtendedColumnCount : 1];
			for(int i = 0;i < ColumnCount; i++)
				ReaderConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ColumnCount != ReaderConfiguration.Length)
				ReaderConfiguration[0] = (agg, tr, c, sl) => tr.Read();
			for(int i = 0;i < ExtendedColumnCount; i++)
				ReaderExtendedConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ExtendedColumnCount != ReaderExtendedConfiguration.Length)
				ReaderExtendedConfiguration[0] = (agg, tr, c, sl) => tr.Read();
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "FormList", "URI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column URI in type UseCase1.FormList. Check if database is out of sync with code");
			Property_URI_Index = (short)row["column_index"] - 1;
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_FormList_type-", "URI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column URI in type UseCase1.FormList. Check if database is out of sync with code");
			ExtendedProperty_URI_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_URI_Index] = (item, reader, context, locator) => item.URI = StringConverter.Parse(reader, context);
			
			ReaderExtendedConfiguration[ExtendedProperty_URI_Index] = (item, reader, context, locator) => item.URI = StringConverter.Parse(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "FormList", "Name" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Name in type UseCase1.FormList. Check if database is out of sync with code");
			Property_Name_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Name_Index] = (item, reader, context, locator) => item._Name = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_FormList_type-", "Name" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Name in type UseCase1.FormList. Check if database is out of sync with code");
			ExtendedProperty_Name_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Name_Index] = (item, reader, context, locator) => item._Name = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "FormList", "Group" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Group in type UseCase1.FormList. Check if database is out of sync with code");
			Property_Group_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Group_Index] = (item, reader, context, locator) => item._Group = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_FormList_type-", "Group" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Group in type UseCase1.FormList. Check if database is out of sync with code");
			ExtendedProperty_Group_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Group_Index] = (item, reader, context, locator) => item._Group = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "FormList", "Status" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Status in type UseCase1.FormList. Check if database is out of sync with code");
			Property_Status_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Status_Index] = (item, reader, context, locator) => item._Status = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.ParseFromPostgres(reader);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_FormList_type-", "Status" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Status in type UseCase1.FormList. Check if database is out of sync with code");
			ExtendedProperty_Status_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Status_Index] = (item, reader, context, locator) => item._Status = _DatabaseCommon.FactoryUseCase1_FormStatus.FormStatusConverter.ParseFromPostgres(reader);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "FormList", "SubmissionsCount" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column SubmissionsCount in type UseCase1.FormList. Check if database is out of sync with code");
			Property_SubmissionsCount_Index = (short)row["column_index"] - 1;
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_FormList_type-", "SubmissionsCount" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column SubmissionsCount in type UseCase1.FormList. Check if database is out of sync with code");
			ExtendedProperty_SubmissionsCount_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_SubmissionsCount_Index] = (item, reader, context, locator) => item._SubmissionsCount = _DatabaseCommon.Utility.ParseInt(reader, context);
			
			ReaderExtendedConfiguration[ExtendedProperty_SubmissionsCount_Index] = (item, reader, context, locator) => item._SubmissionsCount = _DatabaseCommon.Utility.ParseInt(reader, context);
			
		}

		private static Action<global::UseCase1.FormList, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderConfiguration;
		private static Action<global::UseCase1.FormList, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderExtendedConfiguration;

		public static global::UseCase1.FormList CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.FormList CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.FormList(locator);
			foreach (var config in ReaderConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			return item;
		}

		public static global::UseCase1.FormList CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromExtendedRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.FormList CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.FormList(locator);
			foreach (var config in ReaderExtendedConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			return item;
		}

		
		private static int Property_URI_Index;
		private static int ExtendedProperty_URI_Index;
		private static int Property_Name_Index;
		private static int ExtendedProperty_Name_Index;
		private static int Property_Group_Index;
		private static int ExtendedProperty_Group_Index;
		private static int Property_Status_Index;
		private static int ExtendedProperty_Status_Index;
		private static int Property_SubmissionsCount_Index;
		private static int ExtendedProperty_SubmissionsCount_Index;
	}

}
