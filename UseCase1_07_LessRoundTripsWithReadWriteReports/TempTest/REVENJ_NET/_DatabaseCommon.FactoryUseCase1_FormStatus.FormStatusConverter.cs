
namespace _DatabaseCommon.FactoryUseCase1_FormStatus
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


	
	
	internal class FormStatusConverter : IPostgresTypeConverter
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
			return CreateTupleFrom((global::UseCase1.FormStatus)instance);
		}

		private static readonly IPostgresTuple DefaultTuple = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.FormStatus.New);

		public static IPostgresTuple CreateTupleFrom(global::UseCase1.FormStatus item)
		{
			
			switch (item)
			{ 
				case global::UseCase1.FormStatus.New:
					return TupleNew;
				case global::UseCase1.FormStatus.PendingApproval:
					return TuplePendingApproval;
				case global::UseCase1.FormStatus.Approved:
					return TupleApproved;
				case global::UseCase1.FormStatus.NotApproved:
					return TupleNotApproved;
				case global::UseCase1.FormStatus.Archived:
					return TupleArchived;
			}
			return DefaultTuple;
		}

		public static string StringValue(global::UseCase1.FormStatus item)
		{
			
			switch (item)
			{ 
				case global::UseCase1.FormStatus.New:
					return "New";
				case global::UseCase1.FormStatus.PendingApproval:
					return "PendingApproval";
				case global::UseCase1.FormStatus.Approved:
					return "Approved";
				case global::UseCase1.FormStatus.NotApproved:
					return "NotApproved";
				case global::UseCase1.FormStatus.Archived:
					return "Archived";
			}
			return string.Empty;
		}

		public static IPostgresTuple CreateTupleFromNullable(global::UseCase1.FormStatus? item)
		{
			if(item == null)
				return null;
			return CreateTupleFrom(item.Value);
		}

		public static global::UseCase1.FormStatus ParseFromPostgres(Revenj.Utility.BufferedTextReader reader)
		{
			var cur = reader.Read();
			if (cur == ',' || cur == ')')
				return global::UseCase1.FormStatus.New;
			reader.InitBuffer((char)cur);
			reader.FillUntil(',', ')');
			var result = ConvertEnum(reader);
			reader.Read();
			return result;
		}

		public static global::UseCase1.FormStatus? ParseFromPostgresNullable(Revenj.Utility.BufferedTextReader reader)
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

		public static global::UseCase1.FormStatus ConvertEnum(Revenj.Utility.BufferedTextReader reader)
		{
			
			switch (reader.BufferHash())
			{ 
				case -1960563279:
					return global::UseCase1.FormStatus.New;
				case 1584218135:
					return global::UseCase1.FormStatus.PendingApproval;
				case -963047270:
					return global::UseCase1.FormStatus.Approved;
				case 1957275477:
					return global::UseCase1.FormStatus.NotApproved;
				case -1352904045:
					return global::UseCase1.FormStatus.Archived;
			}
			return global::UseCase1.FormStatus.New;
		}

		
	private static readonly IPostgresTuple TupleNew = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.FormStatus.New);
	private static readonly IPostgresTuple TuplePendingApproval = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.FormStatus.PendingApproval);
	private static readonly IPostgresTuple TupleApproved = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.FormStatus.Approved);
	private static readonly IPostgresTuple TupleNotApproved = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.FormStatus.NotApproved);
	private static readonly IPostgresTuple TupleArchived = global::Revenj.DatabasePersistence.Postgres.Converters.EnumConverter.ToTuple(global::UseCase1.FormStatus.Archived);
	}

}
