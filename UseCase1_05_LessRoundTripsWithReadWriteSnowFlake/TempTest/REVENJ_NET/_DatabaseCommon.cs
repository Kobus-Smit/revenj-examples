
using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Linq.Expressions;
using global::System.Text;
using global::System.Threading;
using global::System.Runtime.Serialization; 
using global::Revenj;
using global::Revenj.DomainPatterns;
using global::Revenj.Extensibility;
namespace _DatabaseCommon
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	internal static partial class Utility
	{
		public static T[] ConvertToArray<T>(List<T> source)
		{
			return source != null ? source.ToArray() : null;
		}
		public static List<T> ConvertToList<T>(List<T> source)
		{
			return source;
		}
		public static HashSet<T> ConvertToSet<T>(List<T> source)
		{
			return source != null ? new HashSet<T>(source) : null;
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static Guid? ToNullableGuid(this string value)
		{
			if(!string.IsNullOrWhiteSpace(value)) 
				return Guid.Parse(value);
			return null;
		}

		public static int NullableGuidToURI(char[] buf, int pos, Guid? value)
		{
			if (value == null)
				return pos;
			GuidConverter.Serialize(value.Value, buf, pos);
			return pos + 36;
		}

		public static IPostgresTuple NullableGuidToTuple(Guid? value)
		{
			return value != null ? GuidConverter.ToTuple(value.Value) : null;
		}

		public static Guid? ParseNullableGuid(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return GuidConverter.ParseNullable(reader);
		}

		public static List<Guid?> ParseNullableListGuid(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return GuidConverter.ParseNullableCollection(reader, context);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static Guid ToGuid(this string value)
		{
			if(!string.IsNullOrWhiteSpace(value)) 
				return Guid.Parse(value);
			return Guid.Empty;
		}

		public static int GuidToURI(char[] buf, int pos, Guid value)
		{
			GuidConverter.Serialize(value, buf, pos);
			return pos + 36;
		}

		public static IPostgresTuple GuidToTuple(Guid value)
		{
			return GuidConverter.ToTuple(value);
		}

		public static Guid ParseGuid(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return GuidConverter.Parse(reader);
		}

		public static List<Guid> ParseListGuid(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return GuidConverter.ParseCollection(reader, context);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static string FormatNullableString(string value)
		{
			return value;
		}

		public static int NullableStringToURI(char[] buf, int pos, string value)
		{
			if (value == null)
				return pos;
			value.CopyTo(0, buf, pos, value.Length);
			return pos + value.Length;
		}

		public static int NullableStringToCompositeURI(char[] buf, int pos, string value)
		{
			if (value == null)
				return pos;
			return StringConverter.SerializeCompositeURI(value, buf, pos);
		}

		public static IPostgresTuple NullableStringToTuple(string value)
		{
			return value != null ? Revenj.DatabasePersistence.Postgres.Converters.ValueTuple.From(value) : null;
		}

		public static string ParseNullableString(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return StringConverter.Parse(reader, context);
		}

		public static List<string> ParseNullableListString(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return StringConverter.ParseCollection(reader, context, true);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static string FormatString(string value)
		{
			return value ?? string.Empty;
		}

		public static int StringToURI(char[] buf, int pos, string value)
		{
			value.CopyTo(0, buf, pos, value.Length);
			return pos + value.Length;
		}

		public static int StringToCompositeURI(char[] buf, int pos, string value)
		{
			return StringConverter.SerializeCompositeURI(value, buf, pos);
		}

		public static IPostgresTuple StringToTuple(string value)
		{
			return Revenj.DatabasePersistence.Postgres.Converters.ValueTuple.From(value ?? string.Empty);
		}

		public static string ParseString(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return StringConverter.Parse(reader, context) ?? string.Empty;
		}

		public static List<string> ParseListString(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return StringConverter.ParseCollection(reader, context, false);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static int ToInt(this string value)
		{
			if(!string.IsNullOrWhiteSpace(value)) 
				return int.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
			return 0;
		}

		public static int IntegerToURI(char[] buf, int pos, int value)
		{
			return IntConverter.Serialize(value, buf, pos);
		}

		public static IPostgresTuple IntegerToTuple(int value)
		{
			return IntConverter.ToTuple(value);
		}

		public static int ParseInt(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return IntConverter.Parse(reader);
		}

		public static List<int> ParseListInt(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return IntConverter.ParseCollection(reader, context);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static int? ToNullableInt(this string value)
		{
			if(!string.IsNullOrWhiteSpace(value)) 
				return int.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
			return null;
		}

		public static int NullableIntegerToURI(char[] buf, int pos, int? value)
		{
			if (value == null)
				return pos;
			return IntConverter.Serialize(value.Value, buf, pos);
		}

		public static IPostgresTuple NullableIntegerToTuple(int? value)
		{
			return value != null ? IntConverter.ToTuple(value.Value) : null;
		}

		public static int? ParseNullableInt(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return IntConverter.ParseNullable(reader);
		}

		public static List<int?> ParseNullableListInt(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return IntConverter.ParseNullableCollection(reader, context);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		private readonly static System.TimeZone CurrentNullableZone = System.TimeZone.CurrentTimeZone;

		public static DateTime? ToNullableDateTime(this string value)
		{
			if(!string.IsNullOrWhiteSpace(value)) 
				return TimestampConverter.FromDatabase(value);
			return null;
		}

		public static int NullableTimestampToURI(char[] buf, int pos, DateTime? value)
		{
			if (value == null)
				return pos;
			var v = value.Value;
			if (v.Kind == DateTimeKind.Utc)
				v = v.ToLocalTime();
			var offset = CurrentZone.GetUtcOffset(v);
			if (offset.Minutes != 0)
				return TimestampConverter.Serialize(v.AddMinutes(offset.Minutes), buf, pos, offset.Hours);
			return TimestampConverter.Serialize(v, buf, pos, offset.Hours);
		}

		public static IPostgresTuple NullableTimestampToTuple(DateTime? value)
		{
			if(value.HasValue) 
				return TimestampConverter.ToTuple(value.Value);
			return null;
		}

		public static DateTime? ParseNullableTimestamp(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return TimestampConverter.ParseNullable(reader, context);
		}

		public static List<DateTime?> ParseNullableListTimestamp(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return TimestampConverter.ParseNullableCollection(reader, context);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		private readonly static System.TimeZone CurrentZone = System.TimeZone.CurrentTimeZone;

		public static DateTime ToDateTime(this string value)
		{
			if(!string.IsNullOrWhiteSpace(value)) 
				return TimestampConverter.FromDatabase(value);
			return DateTime.Now;
		}

		public static int TimestampToURI(char[] buf, int pos, DateTime value)
		{
			if (value.Kind == DateTimeKind.Utc)
				value = value.ToLocalTime();
			var offset = CurrentZone.GetUtcOffset(value);
			if (offset.Minutes != 0)
				return TimestampConverter.Serialize(value.AddMinutes(offset.Minutes), buf, pos, offset.Hours);
			return TimestampConverter.Serialize(value, buf, pos, offset.Hours);
		}

		public static IPostgresTuple TimestampToTuple(DateTime value)
		{
			return TimestampConverter.ToTuple(value);
		}

		public static DateTime ParseTimestamp(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return TimestampConverter.Parse(reader, context);
		}

		public static List<DateTime> ParseListTimestamp(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return TimestampConverter.ParseCollection(reader, context);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static decimal ToDecimal(this string value)
		{
			if(!string.IsNullOrWhiteSpace(value)) 
				return decimal.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
			return 0;
		}

		public static int DecimalToURI(char[] buf, int pos, decimal value)
		{
			return DecimalConverter.Serialize(value, buf, pos);
		}

		public static IPostgresTuple DecimalToTuple(decimal value)
		{
			return DecimalConverter.ToTuple(value);
		}

		public static decimal ParseDecimal(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return DecimalConverter.Parse(reader);
		}

		public static List<decimal> ParseListDecimal(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return DecimalConverter.ParseCollection(reader, context);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static decimal? ToNullableDecimal(this string value)
		{
			if(!string.IsNullOrWhiteSpace(value)) 
				return decimal.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
			return null;
		}

		public static int NullableDecimalToURI(char[] buf, int pos, decimal? value)
		{
			if (value == null)
				return pos;
			return DecimalConverter.Serialize(value.Value, buf, pos);
		}

		public static IPostgresTuple NullableDecimalToTuple(decimal? value)
		{
			return value != null ? DecimalConverter.ToTuple(value.Value) : null;
		}

		public static decimal? ParseNullableDecimal(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return DecimalConverter.ParseNullable(reader);
		}

		public static List<decimal?> ParseNullableListDecimal(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return DecimalConverter.ParseNullableCollection(reader, context);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static bool? ToNullableBool(this string value)
		{
			if(!string.IsNullOrWhiteSpace(value))
				return value == "t";
			return null;
		}

		public static int NullableBoolToURI(char[] buf, int pos, bool? value)
		{
			if (value == null)
				return pos;
			return BoolConverter.SerializeURI(value.Value, buf, pos);
		}

		public static IPostgresTuple NullableBoolToTuple(bool? value)
		{
			return value != null ? BoolConverter.ToTuple(value.Value) : null;
		}

		public static bool? ParseNullableBool(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return BoolConverter.ParseNullable(reader);
		}

		public static List<bool?> ParseNullableListBool(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return BoolConverter.ParseNullableCollection(reader, context);
		}
	}
}
namespace _DatabaseCommon
{
	using System.IO;
	using Revenj.DatabasePersistence.Postgres;
	using Revenj.DatabasePersistence.Postgres.Converters;

	internal static partial class Utility
	{
		public static bool ToBool(this string value)
		{
			return value == "t";
		}

		public static int BoolToURI(char[] buf, int pos, bool value)
		{
			return BoolConverter.SerializeURI(value, buf, pos);
		}

		public static IPostgresTuple BoolToTuple(bool value)
		{
			return BoolConverter.ToTuple(value);
		}

		public static bool ParseBool(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return BoolConverter.Parse(reader);
		}

		public static List<bool> ParseListBool(Revenj.Utility.BufferedTextReader reader, int context)
		{
			return BoolConverter.ParseCollection(reader, context);
		}
	}
}