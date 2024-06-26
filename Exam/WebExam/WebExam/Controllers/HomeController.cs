using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebExam.Data;
using WebExam.Models;

namespace WebExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Login(string username, string documentOrMovie)
        {
            TempData["Name"] = username;
            TempData["DocMovie"] = documentOrMovie;
            TempData.Keep("Name");
            var userExists = await _context.Authors.AnyAsync(u => u.Name == username);
            if (!userExists)
            {
                ModelState.AddModelError("", "Invalid login attempt: User not found.");
                return RedirectToAction("Index");
            }
            
           
            

            var author = await _context.Authors
            .Where(u => u.Name == username && (u.DocumentList.Contains(documentOrMovie)||u.MovieList.Contains(documentOrMovie)))
            .ToListAsync();

            
            if (author != null)
            {
                
                return RedirectToAction("Choose");
            }
            else
            {
                return View("Index");
            }
        }

        public async Task<IActionResult> Choose()
        {
            string name = TempData["Name"] as string;
            TempData.Keep("Name");
            return View();
        }
        public async Task<IActionResult> AddDocument()
        {
            string name = TempData["Name"] as string;
            TempData.Keep("Name");
            return View();

        }
        public async Task<IActionResult> UpdateDocAndAuthor(string id,string name,string contents)
        {
            TempData["DocName"] = name;
            TempData["Contents"] = contents;

            string docName = TempData["DocName"] as string;
            string docContents = TempData["Contents"] as string;
            string authorName = TempData["Name"] as string;
            TempData.Keep("Name");
            Documents doc= new Documents(id,docName,docContents);
            _context.Add(doc);
            var author = await _context.Authors.Where(a => a.Name == authorName).ToListAsync();
            author[0].DocumentList = author[0].DocumentList+"," + docName;
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Choose");
            
            

        }
        public async Task<IActionResult> UpdateAuthor()
        {
            string authorName = TempData["Name"] as string;
            TempData.Keep("Name");
            var author = await _context.Authors.Where(a => a.Name == authorName).ToListAsync();
            
            if (author != null)
            {
                Authors auth = new Authors(author[0].Id, author[0].Name, author[0].DocumentList, author[0].MovieList);
                _context.Update(auth);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Choose");

        }
        public async Task<IActionResult> DisplayDocsAndMovies()
        {

            string authorName = TempData["Name"] as string;
            TempData.Keep("Name");
            
            var authors=await _context.Authors.Where(a=>a.Name==authorName).ToListAsync();
            var docs = authors[0].DocumentList.Split(',');
            var movies = authors[0].MovieList.Split(',');

            return View(authors);
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
