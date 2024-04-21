using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPortfolio.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Login() 
		{
			return View();
		}

		public ActionResult Registration()
		{
			return View();
		}
	}
}
