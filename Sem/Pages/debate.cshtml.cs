using System.Collections.Generic;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class debate : PageModel
	{
		public int UserId;

		public Entity Debate;

		public Dictionary<bool, List<Entity>> Comments;
		
		public async Task<IActionResult> OnGet(string debateId)
		{
			await RestrictedPageModel.AddSessionIfRemembered(HttpContext);
			var user_id = HttpContext.Session.GetInt32("user_id");
			if (user_id == null)
				return Redirect("/login?desired_path="+HttpContext.Request.Path.ToString());
			UserId = (int)user_id;

			Debate = await Debates.GetById(int.Parse(debateId));
			Comments = await Database.Comments.Get(Debate);
			return null;
		}
	}
}