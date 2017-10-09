
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
namespace Common
{
	using System.Threading;
	using Revenj.Utility;

	internal static partial class Utility
	{
		private static readonly ThreadLocal<ChunkedMemoryStream> ThreadLocalStream = new ThreadLocal<ChunkedMemoryStream>(() => ChunkedMemoryStream.Static());
		internal static ChunkedMemoryStream UseThreadLocalStream()
		{
			var local = ThreadLocalStream.Value;
			local.Reset();
			return local;
		}
	}
}