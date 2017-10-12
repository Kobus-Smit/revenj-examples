
using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Linq.Expressions;
using global::System.Text;
using global::System.Threading;
using global::System.Runtime.Serialization; 
internal static partial class __NGSHelpers
{
	internal static byte[] EmptyBinary = new byte[0];

	internal static bool CompareBinary(byte[] left, byte[] right)
	{
		if(left == null && right == null)
			return true;
		if(left != null && right != null)
		{
			if (left.Length != right.Length)
				return false;

			for (int i = 0; i < left.Length; i++)
				if (left[i] != right[i])
					return false;

			return true;
		}
		return false;
	}

	internal static bool CompareBinary(byte[][] left, byte[][] right)
	{
		if(left == null && right == null)
			return true;
		if(left != null && right != null)
		{
			if (left.Length != right.Length)
				return false;

			for (int i = 0; i < left.Length; i++)
				if(!CompareBinary(left[i], right[i]))
					return false;

			return true;
		}
		return false;
	}

	internal static bool CompareBinary(System.Collections.Generic.List<byte[]> left, System.Collections.Generic.List<byte[]> right)
	{
		if(left == null && right == null)
			return true;
		if(left != null && right != null)
		{
			if (left.Count != right.Count)
				return false;

			for (int i = 0; i < left.Count; i++)
				if(!CompareBinary(left[i], right[i]))
					return false;

			return true;
		}
		return false;
	}

	internal static bool CompareBinary<T>(T left, T right)
		where T : System.Collections.ICollection, System.Collections.Generic.IEnumerable<byte[]>
	{
		if(left == null && right == null)
			return true;
		if(left == null || right == null)
			return false;
		if (left.Count != right.Count)
			return false;

		var en1 = left.GetEnumerator();
		var en2 = right.GetEnumerator();

		while(en1.MoveNext() && en2.MoveNext())
			if(!CompareBinary(en1.Current, en2.Current))
				return false;

		return true;
	}

	internal static bool CompareBinary(System.Collections.Generic.HashSet<byte[]> left, System.Collections.Generic.HashSet<byte[]> right)
	{
		if(left == null && right == null)
			return true;
		if(left != null && right != null)
		{
			if (left.Count != right.Count)
				return false;

			foreach(var l in left)
				if(!System.Linq.Enumerable.Any(right, r => CompareBinary(r, l)))
					return false;

			return true;
		}
		return false;
	}
}