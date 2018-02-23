
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