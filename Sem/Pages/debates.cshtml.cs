using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace Sem.Pages
{
	public class debates : PageModel
	{
		public IAsyncEnumerable<Entity> Debates;

		public void OnGet() //TODO offset limit
		{
			var searchText = Request.Query["search_text"];
			var searchTag = Request.Query["search_tag"];
			if (searchText != StringValues.Empty)
			{
				if (searchTag != StringValues.Empty)
					Debates = Database.Debates.SearchByNameAndTag(searchText, searchTag);
				else
					Debates = Database.Debates.SearchByName(searchText);
			}
			else
				Debates = Database.Debates.Get();
		}
	}
}