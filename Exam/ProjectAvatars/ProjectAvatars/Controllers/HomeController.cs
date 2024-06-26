using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAvatars.Data;
using ProjectAvatars.Models;
using System.Diagnostics;

namespace ProjectAvatars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Login(string userName,string password)
        {
            TempData["UserName"] = userName;
            TempData["Password"] = password;

            string username = TempData["UserName"] as string;
            string password1 = TempData["Password"] as string;

            //TempData.Keep("UserName");
            //TempData.Keep("Password");

            var users = await _context.Users
                .Where(u => u.Username == username && u.Password == password1)
                .ToListAsync();


            if (users != null)
            {
                //TempData["UserId"] = users[0].Id;
                //TempData.Keep("UserId");
                return RedirectToAction("ChooseInterval");
            }
            else
            {

                ModelState.AddModelError("", "Invalid login attempt.");
                return View();
            }
        }
        
        public async Task<IActionResult> ChooseInterval(int begin,int end)
        {

            TempData["From"] = begin;
            TempData["To"] = end;
            TempData.Keep("From");
            TempData.Keep("To");
            return View();

        }
        
        public async Task<IActionResult> Avatars(String begin, string end)
        {


            int intBegin = 0;
            int intEnd=0;
            if(begin!=null)
                intBegin=int.Parse(begin);
            if(end!=null)
                intEnd=int.Parse(end);

            var avatars = await _context.Avatar
                .Where(a => a.Value >=intBegin && a.Value <= intEnd)
                .ToListAsync();

            return View(avatars);



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
