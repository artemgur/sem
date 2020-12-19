using System;
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
			await AddSessionIfRemembered(HttpContext);
			var id = HttpContext.Session.GetInt32("user_id");
			if (id == null)
				return Redirect("login?desired_path="+HttpContext.Request.Path.ToString());
			User = await Database.User.GetById((int) id);
			return null;
		}

		public static async Task AddSessionIfRemembered(HttpContext context)
		{
			var guid = context.Request.Cookies["guid"];//If no cookie - exception or default?
			if (guid != null && guid != "null")
			{
				var id = await RememberedGuids.GetIdOr0(Guid.Parse(guid));
				if (id > 0)
					context.Session.SetInt32("user_id", id);
			}
		}
	}
}