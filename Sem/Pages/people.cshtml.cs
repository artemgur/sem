using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class PeopleModel : PageModel
	{
		public IAsyncEnumerable<Entity> People;

		public void OnGet()
		{
			People = Database.People.Get(0, 2);
		}
	}
}