using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class IndexModel : PageModel
	{
		public IAsyncEnumerable<Entity> Articles;
		
		public void OnGet()
		{
			Articles = Article.Get(0, 6);
		}
	}
}