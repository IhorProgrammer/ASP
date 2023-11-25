using ASP.Models;
using ASP.Models.Home;
using ASP.Services.Hash;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        // залежність (від служби) заявляється як private readonly поле
        private readonly IHashService _hashService; // DIP - тип залежності - це інтерфейс
        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, IHashService hashService)
		{
			_logger = logger;
			_hashService = hashService;
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Razor()
        {
            ViewData["formController"] = "Hello from Controller";
            return View();
        }
		public ViewResult Transfer(TransferFormModel? formModel)
		{
			if (HttpContext.Session.Keys.Contains("formModel"))
			{
				//TransferFormModel? formModel Є збережжені у сесії дані, отже відновлюємо їх та видаляємо сесії
				formModel = JsonSerializer.Deserialize<TransferFormModel>(HttpContext.Session.GetString("formModel")!);
				HttpContext.Session.Remove("formModel");
			}
			else formModel = null;

			TransferViewModel model = new()
			{
				Date = DateOnly.FromDateTime(DateTime.Today),
				Time = TimeOnly.FromDateTime(DateTime.Now),
				ControllerName = this.GetType().Name,
				FormModel = formModel,
			};

			return View(model);
		}

		public ViewResult Ioc()
        {

            ViewData["hash"] = _hashService.HexString("123");
            ViewData["objHash"] = _hashService.GetHashCode();
            return View();
        }

		public ViewResult DB()
		{
			return View();
		}


        [HttpPost]
		public RedirectToActionResult ProcessTraansferForm(TransferFormModel? formModel)
		{
			if (formModel != null)
			{
				//Зберігаємо у сессії серіалізований об'єкт formModel під іменем "formModel"
				HttpContext.Session.SetString(
					"formModel",
					JsonSerializer.Serialize(formModel)
					);
			}
			
			return RedirectToAction(nameof(Transfer));
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}