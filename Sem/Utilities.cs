using System;
using System.Collections.Generic;
using Database;

namespace Sem
{
	public static class Utilities
	{
		public static string DateToString(Entity entity)
			=> ((DateTime) entity["date"]).ToShortDateString();

		public static TValue ValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> d, TKey key)
		{
			if (d.TryGetValue(key, out var a))
				return a;
			return default;
		}
	}
}