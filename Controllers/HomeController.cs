using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using DigitalPortfolio.Models;

namespace DigitalPortfolio.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Forum()
		{
			return View();
		}
	}
}
