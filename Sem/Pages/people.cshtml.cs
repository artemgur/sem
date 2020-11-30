using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace Sem.Pages
{
	public class PeopleModel : PageModel
	{
		public IAsyncEnumerable<Entity> People;
		
		public void OnGet()//TODO offset limit
		{
			var searchText = Request.Query["search_text"];
			var searchTag = Request.Query["search_tag"];
			if (searchText != StringValues.Empty)
			{
				if (searchTag != StringValues.Empty)
					People = Database.People.SearchByNameAndTag(searchText, searchTag);
				else
					People = Database.People.SearchByName(searchText);
			}
			else
				People = Database.People.Get();
		}
	}
}