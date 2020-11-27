using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Sem.ViewComponents
{
	public class DebatesAccountViewComponent : ViewComponent
	{
		public DebatesAccountViewComponent()
		{
		}
		public async Task<IViewComponentResult> InvokeAsync(Entity entity)
		{
			return View("DebatesAccount", entity);
		}
	}
}