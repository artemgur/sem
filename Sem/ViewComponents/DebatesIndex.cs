using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Sem.ViewComponents
{
	public class DebatesIndexViewComponent : ViewComponent
	{
		public IViewComponentResult InvokeAsync(Entity entity)
		{
			return View("DebatesIndex", entity);
		}
	}
}