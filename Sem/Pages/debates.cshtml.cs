using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class debates : PageModel
	{
		public IAsyncEnumerable<Entity> Debates;

		public void OnGet()
		{
			Debates = Database.Debates.Get(0, 6);
		}
	}
}