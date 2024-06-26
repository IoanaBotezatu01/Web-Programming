using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Subiect922.Data;
using Subiect922.Models;
using System.Diagnostics;

namespace Subiect922.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult SetUser(string userName, string date, string destination_city)
        {
            TempData["UserName"] = userName;
            TempData["Date"] = date;
            TempData["DestinationCity"] = destination_city;
            return RedirectToAction("Choose");
        }
        public IActionResult Choose()
        {
            ViewBag.Date = TempData["Date"];
            ViewBag.DestinationCity = TempData["DestinationCity"];
            TempData.Keep("Date");
            TempData.Keep("DestinationCity");
            return View();
        }
        public async Task<IActionResult> Hotels()
        {
            string date = TempData["Date"] as string;
            string destinationCity = TempData["DestinationCity"] as string;

            TempData.Keep("Date");
            TempData.Keep("DestinationCity");

            var hotels = await _context.Hotels
                .Where(h => h.Date == date && h.City.Equals(destinationCity))
                .ToListAsync();

            return View(hotels);
        }
        public async Task<IActionResult> Flights()
        {
            string date = TempData["Date"] as string;
            string destinationCity = TempData["DestinationCity"] as string;

            TempData.Keep("Date");
            TempData.Keep("DestinationCity");

            var flights = await _context.Flights
                .Where(f => f.Date == date && f.DestinationCity.Equals(destinationCity))
                .ToListAsync();

            return View(flights);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> MakeReservation(int id, string type)
        {
            string userName = TempData["UserName"] as string;
            string date = TempData["Date"] as string;

            if (type == "Hotel")
            {
                var hotel = await _context.Hotels.FindAsync(id);
                if (hotel != null && hotel.AvailableRooms > 0)
                {
                    hotel.AvailableRooms--;
                    _context.Update(hotel);
                }
            }
            else if (type == "Flight")
            {
                var flight = await _context.Flights.FindAsync(id);
                if (flight != null && flight.AvailableSeats > 0)
                {
                    flight.AvailableSeats--;
                    _context.Update(flight);
                }
            }

            var reservation = new Reservations
            {
                Person = userName,
                ReservationType = type,
                IdReservedResource = id
            };

            _context.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(type == "Hotel" ? "Hotels" : "Flights");
        }

        [HttpPost]
        public async Task<IActionResult> CancelReservations()
        {
            string date = TempData["Date"] as string;
            string destinationCity = TempData["DestinationCity"] as string;

            var reservationsToDelete = await _context.Reservations
                .Where(r => r.ReservationType == "Hotel" && _context.Hotels.Any(h => h.Id == r.IdReservedResource && h.Date == date && h.City == destinationCity)
                         || r.ReservationType == "Flight" && _context.Flights.Any(f => f.Id == r.IdReservedResource && f.Date == date && f.DestinationCity == destinationCity))
                .ToListAsync();

            foreach (var reservation in reservationsToDelete) //restore rooms/seats
            {
                if (reservation.ReservationType == "Hotel")
                {
                    var hotel = await _context.Hotels.FindAsync(reservation.IdReservedResource);
                    if (hotel != null)
                    {
                        hotel.AvailableRooms++;
                        _context.Update(hotel);
                    }
                }
                else if (reservation.ReservationType == "Flight")
                {
                    var flight = await _context.Flights.FindAsync(reservation.IdReservedResource);
                    if (flight != null)
                    {
                        flight.AvailableSeats++;
                        _context.Update(flight);
                    }
                }
            }

            _context.Reservations.RemoveRange(reservationsToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction("Choose");
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
