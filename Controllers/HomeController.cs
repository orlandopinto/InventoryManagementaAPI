using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	public class HomeController : Controller
	{
		[Route("/")]
		[Route("/index.html")]
		public IActionResult Index()
		{
			return new RedirectResult("~/swagger/index.html");
		}
	}
}
