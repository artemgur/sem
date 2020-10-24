using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sem.ViewComponents
{
	public class DebatesAccountViewComponent : ViewComponent
	{
		public DebatesAccountViewComponent()
		{
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("DebatesAccount");
		}
	}
}