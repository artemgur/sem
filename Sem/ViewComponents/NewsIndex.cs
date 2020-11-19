using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Sem.ViewComponents
{
	public class NewsIndexViewComponent : ViewComponent
	{
		// public Entity Article;
		
		public NewsIndexViewComponent()
		{
		}
		public async Task<IViewComponentResult> InvokeAsync(Entity entity)
		{
			return View("NewsIndex", entity);
		}
	}
}