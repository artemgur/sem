using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class register : PageModel
	{
		public string DesiredPath;
		
		public void OnGet()
		{
			DesiredPath = Request.Query["desired_path"].ToString() ?? "";
			if (DesiredPath != "")
				DesiredPath = "?desired_path=" + DesiredPath;
		}
	}
}