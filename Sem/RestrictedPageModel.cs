using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem
{
	public abstract class RestrictedPageModel : PageModel
	{
		public Entity User;
		
		public async Task<IActionResult> OnGet()
		{
			User = await Authentication.GetUserInfoOrRedirect(HttpContext);
			if (User == null)
				return Redirect("login");
			return null;
		}
	}
}