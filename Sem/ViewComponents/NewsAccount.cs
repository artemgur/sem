using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Sem.ViewComponents
{
	public class NewsAccountViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(Entity entity)
		{
			return View("NewsAccount", entity);
		}
	}
}