using Microsoft.AspNetCore.Mvc;
using System.Text;
using DigitalPortfolio.Models;

namespace DigitalPortfolio.Controllers
{
	public class RegistrationController : Controller
	{
		public ActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Registration(RegistrationModel model)
		{
			if (ModelState.IsValid)
			{
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DataBase", "DB_Simulation.txt");

				bool usernameExists = false;
				if (System.IO.File.Exists(filePath))
				{
					var lines = System.IO.File.ReadAllLines(filePath);
					foreach (var line in lines)
					{
						var parts = line.Split(':');
						if (parts.Length > 0 && parts[0] == model.Username)
						{
							usernameExists = true;
							break;
						}
					}
				}

				if (usernameExists)
				{
					ModelState.AddModelError("Username", "Этот логин уже занят.");
					return RedirectToAction("RegistrationFail");
				}

				using (var writer = new StreamWriter(filePath, true, Encoding.UTF8))
				{
					writer.WriteLine($"{model.Username}:{model.Password}");
				}

				return RedirectToAction("RegistrationSuccess");
			}

			return View(model);
		}

		public ActionResult RegistrationSuccess()
		{
			return View();
		}

		public ActionResult RegistrationFail()
		{
			return View();
		}
	}
}