using System;
using Database;

namespace Sem
{
	public static class Utilities
	{
		public static string DateToString(Entity entity)
			=> ((DateTime) entity["date"]).ToShortDateString();
	}
}