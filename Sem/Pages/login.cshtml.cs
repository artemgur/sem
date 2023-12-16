using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class login : PageModel
	{
		public string DesiredPath;
		
		public void OnGet()
		{
			Authentication.Exit(HttpContext);
			DesiredPath = Request.Query["desired_path"].ToString() ?? "";
			if (DesiredPath != "")
				DesiredPath = "?desired_path=" + DesiredPath;
		}
	}
}