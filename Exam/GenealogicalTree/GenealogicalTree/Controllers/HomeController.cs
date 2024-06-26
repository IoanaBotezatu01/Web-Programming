using GenealogicalTree.Data;
using GenealogicalTree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace GenealogicalTree.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Login(string username,string mother,string father)
		{
			TempData["User"] = username;
			TempData.Keep("User");

            var userExists = await _context.Users.AnyAsync(u => u.Username == username);
            if (!userExists)
            {
                ModelState.AddModelError("", "Invalid login attempt: User not found.");
                return RedirectToAction("Index");
            }

            var users = await _context.FamilyRelations
                    .Where(u => u.Username == username && (u.Father == father || u.Mother == mother))
                    .ToListAsync();
            if (users.Count > 0)
				return RedirectToAction("Index", "FamilyRelations");
			else{
                ModelState.AddModelError("", "Invalid login attempt.");
                return RedirectToAction("Index");
            }

            
            

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
