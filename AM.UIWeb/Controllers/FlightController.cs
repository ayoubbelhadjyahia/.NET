using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;
using AM.ApplicationCore.Domain;

namespace AM.UIWeb.Controllers
{
    public class FlightController : Controller
    {
        // GET: FlightController


        IServiceFlight serviceFlight;
        IServicePlane servicePlane;
        public FlightController(IServiceFlight serviceFlight,IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane= servicePlane;
        }
        public ActionResult Index(String Destination,String Departure)
        {
            List<string> Propre = new List<string>()
            {
                "carrot",
                "fox",
                "explorer"
            };
             
            var flights = serviceFlight.GetAll();

            if (Destination != null && Departure != null)
            {
                return View(flights.Where(f => f.destination.Contains(Destination) && f.departure.Contains(Departure)));
            }
            else if (Destination != null)
            {
                return View(flights.Where(f => f.destination.Contains(Destination)));
            }
            else if (Departure != null)
            {
                return View(flights.Where(f => f.departure.Contains(Departure)));
            }
            return View(flights.ToList());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            var flight = serviceFlight.GetById(id);
            return View(flight);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.planes = new SelectList(servicePlane.GetAll(),"planeId", "Information");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection,IFormFile piloteFile)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","img",piloteFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                piloteFile.CopyTo(stream);
                collection.pilote = piloteFile.FileName;
                serviceFlight.Add(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            var flight = serviceFlight.GetById(id);
            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection)
        {
            try
            {
                serviceFlight.Update(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            var flight = serviceFlight.GetById(id);
            return View(flight);
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Flight collection)
        {
            try
            {
                var flight = serviceFlight.GetById(id);
                serviceFlight.Delete(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
