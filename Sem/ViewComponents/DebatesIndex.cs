using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sem.ViewComponents
{
	public class DebatesIndexViewComponent : ViewComponent
	{
		public DebatesIndexViewComponent()
		{
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("DebatesIndex");
		}
	}
}