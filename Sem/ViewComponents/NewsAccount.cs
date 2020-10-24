using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sem.ViewComponents
{
	public class NewsAccountViewComponent : ViewComponent
	{
		public NewsAccountViewComponent()
		{
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("NewsAccount");
		}
	}
}