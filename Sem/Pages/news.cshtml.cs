using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class news : PageModel
	{
		public Entity Article;
		
		public async Task<IActionResult> OnGet(string id)
		{
			if (!int.TryParse(id, out var parsed))
				return Redirect("index");
			Article = await Database.Article.GetById(parsed);
			return null;
		}
	}
}