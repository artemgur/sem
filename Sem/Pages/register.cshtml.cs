using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class register : PageModel
	{
		public string DesiredPath;
		
		public void OnGet()
		{
			if (HttpContext.Session.GetInt32("user_id") != null)
				HttpContext.Session.Remove("user_id");
			DesiredPath = Request.Query["desired_path"].ToString() ?? "";
			if (DesiredPath != "")
				DesiredPath = "?desired_path=" + DesiredPath;
		}
	}
}