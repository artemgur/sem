using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace Sem.Pages
{
	public class IndexModel : PageModel
	{
		public IAsyncEnumerable<Entity> Articles;
		
		public async void OnGet()//TODO offset limit
		{
			var searchText = Request.Query["search_text"];
			var searchTag = Request.Query["search_tag"];
			if (searchText != StringValues.Empty)
			{
				if (searchTag != StringValues.Empty)
					Articles = Article.SearchByNameAndTag(searchText, searchTag, 0, 6);
				else
					Articles = Article.SearchByName(searchText, 0, 6);
			}
			else
				Articles = Article.Get(0, 6);
		}
	}
}