
namespace _DatabaseCommon.FactoryUseCase1_DataType
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


	
	
	internal class DataTypeConverter : IPostgresTypeConverter
	{
		public object CreateInstance(object value, Revenj.Utility.BufferedTextReader reader, IServiceProvider locator)
		{
			if (value == null)
				return null;
			var str = value as string;
			if (str != null)
				return ParseFromPostgresNullable(reader.Reuse(str));
			using(var sr = value as System.IO.TextReader ?? new System.IO.StringReader(value.ToString()))
				return ParseFromPostgresNullable(reader.Reuse(sr));
		}

		public IPostgresTuple ToTuple(object instance)
		{
			if (instance == null)
				return null;
			return CreateTupleFrom((global::UseCase1.DataType)instance);
		}

		private static readonly IPostgresTuple DefaultTuple = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.DataType.String);

		public static IPostgresTuple CreateTupleFrom(global::UseCase1.DataType item)
		{
			
			switch (item)
			{ 
				case global::UseCase1.DataType.String:
					return TupleString;
				case global::UseCase1.DataType.Int:
					return TupleInt;
				case global::UseCase1.DataType.Decimal:
					return TupleDecimal;
				case global::UseCase1.DataType.Bool:
					return TupleBool;
				case global::UseCase1.DataType.DateTime:
					return TupleDateTime;
			}
			return DefaultTuple;
		}

		public static string StringValue(global::UseCase1.DataType item)
		{
			
			switch (item)
			{ 
				case global::UseCase1.DataType.String:
					return "String";
				case global::UseCase1.DataType.Int:
					return "Int";
				case global::UseCase1.DataType.Decimal:
					return "Decimal";
				case global::UseCase1.DataType.Bool:
					return "Bool";
				case global::UseCase1.DataType.DateTime:
					return "DateTime";
			}
			return string.Empty;
		}

		public static IPostgresTuple CreateTupleFromNullable(global::UseCase1.DataType? item)
		{
			if(item == null)
				return null;
			return CreateTupleFrom(item.Value);
		}

		public static global::UseCase1.DataType ParseFromPostgres(Revenj.Utility.BufferedTextReader reader)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return global::UseCase1.DataType.String;
			reader.InitBuffer((char)cur);
			reader.FillUntil(',', ')');
			var result = ConvertEnum(reader);
			reader.Read();
			return result;
		}

		public static global::UseCase1.DataType? ParseFromPostgresNullable(Revenj.Utility.BufferedTextReader reader)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return null;
			reader.InitBuffer((char)cur);
			reader.FillUntil(',', ')');
			var result = ConvertEnum(reader);
			reader.Read();
			return result;
		}

		public static global::UseCase1.DataType ConvertEnum(Revenj.Utility.BufferedTextReader reader)
		{
			
			switch (reader.BufferHash())
			{ 
				case 1615808600:
					return global::UseCase1.DataType.String;
				case -126609922:
					return global::UseCase1.DataType.Int;
				case -1515522836:
					return global::UseCase1.DataType.Decimal;
				case 796142685:
					return global::UseCase1.DataType.Bool;
				case -1679002480:
					return global::UseCase1.DataType.DateTime;
			}
			return global::UseCase1.DataType.String;
		}

		
	private static readonly IPostgresTuple TupleString = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.DataType.String);
	private static readonly IPostgresTuple TupleInt = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.DataType.Int);
	private static readonly IPostgresTuple TupleDecimal = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.DataType.Decimal);
	private static readonly IPostgresTuple TupleBool = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.DataType.Bool);
	private static readonly IPostgresTuple TupleDateTime = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.DataType.DateTime);
	}

}
