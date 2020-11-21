using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem
{
	public class RestrictedPageModel: PageModel
	{
		public Entity User;

		public async Task<IActionResult> OnGet()
		{
			var id = HttpContext.Session.GetInt32("user_id");
			if (id == null)
				return Redirect("login");
			User = await Database.User.GetById((int) id);
			return null;
		}
	}
}