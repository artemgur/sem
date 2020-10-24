using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sem.ViewComponents
{
	public class NewsIndexViewComponent : ViewComponent
	{
		public NewsIndexViewComponent()
		{
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("NewsIndex");
		}
	}
}