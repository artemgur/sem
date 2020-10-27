using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
	public static class Utilities
	{
		public static string ToStringPg(this object a)
		{
			if (a is string || a is DateTime)
				return '\'' + a.ToString() + '\'';
			return a.ToString();
		}

		public static string ToStringListPg(this IEnumerable<object> objects)
		{
			var builder = new StringBuilder(" (");
			foreach (var x in objects)
			{
				builder.Append(x.ToStringPg());
				builder.Append(", ");
			}
			builder.Remove(builder.Length - 2, 2);
			builder.Append(')');
			return builder.ToString();
		}
	}
}