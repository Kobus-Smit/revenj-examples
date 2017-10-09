
namespace _DatabaseCommon.FactoryUseCase1_SubmissionList
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


	
	
	internal class SubmissionListConverter : IPostgresTypeConverter
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
			return CreateTupleFrom(instance as global::UseCase1.SubmissionList);
		}

		public static IPostgresTuple CreateExtendedTupleFrom(global::UseCase1.SubmissionList item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			items[ExtendedProperty_URI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.URI);
			items[ExtendedProperty_Customer_Index] = _DatabaseCommon.Utility.StringToTuple(item.Customer);
			items[ExtendedProperty_Form_Index] = _DatabaseCommon.Utility.StringToTuple(item.Form);
			items[ExtendedProperty_Group_Index] = _DatabaseCommon.Utility.StringToTuple(item.Group);
			items[ExtendedProperty_Date_Index] = _DatabaseCommon.Utility.TimestampToTuple(item.Date);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateExtendedRecordTupleFrom(global::UseCase1.SubmissionList item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ExtendedColumnCount];			
			
			if (useColumn[ExtendedProperty_URI_Index]) items[ExtendedProperty_URI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.URI);
			if (useColumn[ExtendedProperty_Customer_Index]) items[ExtendedProperty_Customer_Index] = _DatabaseCommon.Utility.StringToTuple(item.Customer);
			if (useColumn[ExtendedProperty_Form_Index]) items[ExtendedProperty_Form_Index] = _DatabaseCommon.Utility.StringToTuple(item.Form);
			if (useColumn[ExtendedProperty_Group_Index]) items[ExtendedProperty_Group_Index] = _DatabaseCommon.Utility.StringToTuple(item.Group);
			if (useColumn[ExtendedProperty_Date_Index]) items[ExtendedProperty_Date_Index] = _DatabaseCommon.Utility.TimestampToTuple(item.Date);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateTupleFrom(global::UseCase1.SubmissionList item)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			items[Property_URI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.URI);
			items[Property_Customer_Index] = _DatabaseCommon.Utility.StringToTuple(item.Customer);
			items[Property_Form_Index] = _DatabaseCommon.Utility.StringToTuple(item.Form);
			items[Property_Group_Index] = _DatabaseCommon.Utility.StringToTuple(item.Group);
			items[Property_Date_Index] = _DatabaseCommon.Utility.TimestampToTuple(item.Date);
			return RecordTuple.From(items);
		}

		public static IPostgresTuple CreateRecordTupleFrom(global::UseCase1.SubmissionList item, bool[] useColumn)
		{
			if(item == null) return null;
			var items = new IPostgresTuple[ColumnCount];			
			
			if (useColumn[Property_URI_Index]) items[Property_URI_Index] = new Revenj.DatabasePersistence.Postgres.Converters.ValueTuple(item.URI);
			if (useColumn[Property_Customer_Index]) items[Property_Customer_Index] = _DatabaseCommon.Utility.StringToTuple(item.Customer);
			if (useColumn[Property_Form_Index]) items[Property_Form_Index] = _DatabaseCommon.Utility.StringToTuple(item.Form);
			if (useColumn[Property_Group_Index]) items[Property_Group_Index] = _DatabaseCommon.Utility.StringToTuple(item.Group);
			if (useColumn[Property_Date_Index]) items[Property_Date_Index] = _DatabaseCommon.Utility.TimestampToTuple(item.Date);
			return RecordTuple.From(items);
		}

		private static int ColumnCount;
		private static int ExtendedColumnCount;

		internal static void InitializeProperties(System.Data.DataTable columnsInfo)
		{
			System.Data.DataRow row = null;
			
			ColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = 'SubmissionList'").Length;
			ExtendedColumnCount = columnsInfo.Select("type_schema = 'UseCase1' AND type_name = '-ngs_SubmissionList_type-'").Length;
			
			ReaderConfiguration = new Action<global::UseCase1.SubmissionList, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ColumnCount > 0 ? ColumnCount : 1];
			ReaderExtendedConfiguration = new Action<global::UseCase1.SubmissionList, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[ExtendedColumnCount > 0 ? ExtendedColumnCount : 1];
			for(int i = 0;i < ColumnCount; i++)
				ReaderConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ColumnCount != ReaderConfiguration.Length)
				ReaderConfiguration[0] = (agg, tr, c, sl) => tr.Read();
			for(int i = 0;i < ExtendedColumnCount; i++)
				ReaderExtendedConfiguration[i] = (agg, tr, c, sl) => StringConverter.Skip(tr, c);
			if(ExtendedColumnCount != ReaderExtendedConfiguration.Length)
				ReaderExtendedConfiguration[0] = (agg, tr, c, sl) => tr.Read();
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "SubmissionList", "URI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column URI in type UseCase1.SubmissionList. Check if database is out of sync with code");
			Property_URI_Index = (short)row["column_index"] - 1;
				
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_SubmissionList_type-", "URI" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column URI in type UseCase1.SubmissionList. Check if database is out of sync with code");
			ExtendedProperty_URI_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_URI_Index] = (item, reader, context, locator) => item.URI = StringConverter.Parse(reader, context);
			
			ReaderExtendedConfiguration[ExtendedProperty_URI_Index] = (item, reader, context, locator) => item.URI = StringConverter.Parse(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "SubmissionList", "Customer" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Customer in type UseCase1.SubmissionList. Check if database is out of sync with code");
			Property_Customer_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Customer_Index] = (item, reader, context, locator) => item._Customer = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_SubmissionList_type-", "Customer" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Customer in type UseCase1.SubmissionList. Check if database is out of sync with code");
			ExtendedProperty_Customer_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Customer_Index] = (item, reader, context, locator) => item._Customer = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "SubmissionList", "Form" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Form in type UseCase1.SubmissionList. Check if database is out of sync with code");
			Property_Form_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Form_Index] = (item, reader, context, locator) => item._Form = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_SubmissionList_type-", "Form" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Form in type UseCase1.SubmissionList. Check if database is out of sync with code");
			ExtendedProperty_Form_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Form_Index] = (item, reader, context, locator) => item._Form = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "SubmissionList", "Group" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Group in type UseCase1.SubmissionList. Check if database is out of sync with code");
			Property_Group_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Group_Index] = (item, reader, context, locator) => item._Group = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_SubmissionList_type-", "Group" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Group in type UseCase1.SubmissionList. Check if database is out of sync with code");
			ExtendedProperty_Group_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Group_Index] = (item, reader, context, locator) => item._Group = _DatabaseCommon.Utility.ParseString(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "SubmissionList", "Date" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Date in type UseCase1.SubmissionList. Check if database is out of sync with code");
			Property_Date_Index = (short)row["column_index"] - 1;
				
			
			ReaderConfiguration[Property_Date_Index] = (item, reader, context, locator) => item._Date = _DatabaseCommon.Utility.ParseTimestamp(reader, context);
			
			row = columnsInfo.Rows.Find(new[] { "UseCase1", "-ngs_SubmissionList_type-", "Date" });
			if(row == null)
				throw new System.Configuration.ConfigurationException("Couldn't find column Date in type UseCase1.SubmissionList. Check if database is out of sync with code");
			ExtendedProperty_Date_Index = (short)row["column_index"] - 1;
				
			
			ReaderExtendedConfiguration[ExtendedProperty_Date_Index] = (item, reader, context, locator) => item._Date = _DatabaseCommon.Utility.ParseTimestamp(reader, context);
			
		}

		private static Action<global::UseCase1.SubmissionList, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderConfiguration;
		private static Action<global::UseCase1.SubmissionList, Revenj.Utility.BufferedTextReader, int, IServiceProvider>[] ReaderExtendedConfiguration;

		public static global::UseCase1.SubmissionList CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.SubmissionList CreateFromRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.SubmissionList(locator);
			foreach (var config in ReaderConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			return item;
		}

		public static global::UseCase1.SubmissionList CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int context, IServiceProvider locator)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			var result = CreateFromExtendedRecord(reader, context, context == 0 ? 1 : context << 1, locator);
			reader.Read();
			return result;
		}

		public static global::UseCase1.SubmissionList CreateFromExtendedRecord(Revenj.Utility.BufferedTextReader reader, int outerContext, int context, IServiceProvider locator)
		{
			reader.Read(outerContext);
			var item = new global::UseCase1.SubmissionList(locator);
			foreach (var config in ReaderExtendedConfiguration)
				config(item, reader, context, locator);
			reader.Read(outerContext);
			
			return item;
		}

		
		private static int Property_URI_Index;
		private static int ExtendedProperty_URI_Index;
		private static int Property_Customer_Index;
		private static int ExtendedProperty_Customer_Index;
		private static int Property_Form_Index;
		private static int ExtendedProperty_Form_Index;
		private static int Property_Group_Index;
		private static int ExtendedProperty_Group_Index;
		private static int Property_Date_Index;
		private static int ExtendedProperty_Date_Index;
	}

}
