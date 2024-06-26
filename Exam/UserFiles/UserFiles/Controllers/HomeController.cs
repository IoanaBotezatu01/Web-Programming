using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UserFiles.Data;
using UserFiles.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserFiles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async  Task<IActionResult> Login(string userName,string password) 
        {
            TempData["UserName"] = userName;
            TempData["Password"] = password;

            string username = TempData["UserName"] as string;
            string password1 = TempData["Password"] as string;

            //TempData.Keep("UserName");
            //TempData.Keep("Password");

            var users = await _context.User
                .Where(u => u.Username == username && u.Password==password1)
                .ToListAsync();


            if (users != null)
            {
                TempData["UserId"] = users[0].Id;
                TempData.Keep("UserId");
                return RedirectToAction("Files");
            }
            else
            {

                ModelState.AddModelError("", "Invalid login attempt.");
                return View();
            }
                
        }

        public async Task<IActionResult> Files(int pageNumber=1)
        {
            const int pageSize = 5;
            string userId = TempData["UserId"] as string;
            TempData.Keep("UserId");

            var filesQuery = _context.File.Where(f => f.UserId == userId);
            var totalFiles = await filesQuery.CountAsync();
            var files = await filesQuery
                .OrderBy(f => f.Filename)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new Pages
            {
                Files = files,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(totalFiles / (double)pageSize)
            };
            return View(viewModel);


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
