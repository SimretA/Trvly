using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trvly.Models;

namespace Trvly.Controllers
{
    public class TourController : Controller
    {
        private ApplicationDbContext _context;

        public  TourController(){
            _context = new ApplicationDbContext();
        
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles =RoleName.canManageTours)]
        public ActionResult New() {
            Tour tour = new Tour();
            return View(tour);
        }
        [HttpPost]
        [Authorize(Roles = RoleName.canManageTours)]
        public ActionResult Create(Tour tour) {
            if (!ModelState.IsValid)
            {
                Tour t = tour;

                return View("New",tour);

            }
            _context.Tours.Add(tour);
            _context.SaveChanges();

            return RedirectToAction("Index", "Tour");
        }
        // GET: Tour
        [Authorize]
        public ActionResult Index()
        {
            
            List<Tour> tours = _context.Tours.ToList(); 

            if (User.IsInRole(RoleName.canManageTours))
            {
                return View("Index_Editable",tours);
            }
            return View(tours);
        }
        public ActionResult Delete(int id)
        {
            
            _context.Tours.Remove(_context.Tours.Single(t => t.id == id));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var tour = _context.Tours.SingleOrDefault(t=>t.id==id);
            if (tour == null)
           { 

                return HttpNotFound();
            }

            return View(tour);
        }
    }
}