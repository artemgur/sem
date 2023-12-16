using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class news : PageModel
	{
		public Entity Article;
		public bool IsFavorite;
		
		public async Task<IActionResult> OnGet(string articleId)
		{
			if (!int.TryParse(articleId, out var parsed))
				return Redirect("/index");
			Article = await Database.Article.GetById(parsed);
			var userId = HttpContext.Session.GetInt32("user_id");
			if (userId == null)
				IsFavorite = false;
			else
				IsFavorite = await Database.Article.IsFavorite((int)userId, parsed);
			return null;
		}
	}
}