using Microsoft.AspNetCore.Mvc;
using System.Text;
using DigitalPortfolio.Models;

namespace DigitalPortfolio.Controllers
{
	public class LoginController : Controller
	{
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DataBase", "DB_Simulation.txt");

				bool userExists = false;
				if (System.IO.File.Exists(filePath))
				{
					var lines = System.IO.File.ReadAllLines(filePath);
					foreach (var line in lines)
					{
						var parts = line.Split(':');
						if (parts[0] == model.Username && parts[1] == model.Password)
						{
							userExists = true;
							break;
						}
					}
				}

				if (userExists)
					return RedirectToAction("LoginSuccess");

				return RedirectToAction("LoginFail");
			}

			return View(model);
		}

		public ActionResult LoginSuccess()
		{
			return View();
		}

		public ActionResult LoginFail()
		{
			return View();
		}
	}
}