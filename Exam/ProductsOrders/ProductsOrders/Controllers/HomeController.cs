using Microsoft.AspNetCore.Mvc;
using ProductsOrders.Data;
using ProductsOrders.Models;
using System.Diagnostics;

namespace ProductsOrders.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		public HomeController(ApplicationDbContext context)
		{
			_context= context;
		}
		public async Task<IActionResult> Choose(string user)
		{
			TempData["User"] = user;
			TempData.Keep("User");
			return View();
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
