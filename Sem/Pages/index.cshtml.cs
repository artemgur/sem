using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace Sem.Pages
{
	public class IndexModel : PageModel
	{
		public IAsyncEnumerable<Entity> Articles;
		
		public void OnGet()//TODO offset limit
		{
			var searchText = Request.Query["search_text"];
			var searchTag = Request.Query["search_tag"];
			if (searchText != StringValues.Empty)
			{
				if (searchTag != StringValues.Empty)
					Articles = Article.SearchByNameAndTag(searchText, searchTag);
				else
					Articles = Article.SearchByName(searchText);
			}
			else
				Articles = Article.Get();
		}
	}
}