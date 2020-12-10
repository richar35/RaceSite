using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaceSite.Models;
using RaceSite.ViewModels;

namespace RaceSite.Controllers
{
 
    public class RegistrantsController : Controller
    {
        private readonly RaceContext _context;

        public RegistrantsController(RaceContext context)
        {
            _context = context;
        }

        // GET: Registrants
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["RaceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "RaceName_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var registrants = from r in _context.Registrant.Include(r => r.Race).Include(r => r.Shoe)
                              select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                registrants = registrants.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "RaceName_desc":
                    registrants = registrants.OrderByDescending(s => s.Race);
                    break;
                case "Name_desc":
                    registrants = registrants.OrderByDescending(s => s.LastName);
                    break;
                default:
                    registrants = registrants.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Registrant>.CreateAsync(registrants.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Registrants/Details/5
        [Authorize(Roles = "Administrator,Manager")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrant = await _context.Registrant
                .Include(r => r.Race)
                .Include(r => r.Shoe)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registrant == null)
            {
                return NotFound();
            }

            return View(registrant);
        }

        //GET:Participants
        [Authorize(Roles = "Administrator,Manager,User")]
        public IActionResult ParticipantsView()
        {
            var data = new ParticipantsViewModel
            {
                Race = _context.Race.ToList(),
                Registrant = _context.Registrant.ToList()
            };

            return View(data);
            }


        //GET:Participants
        [Authorize(Roles = "Administrator,Manager,User")]
        public IActionResult ShoeView()
        {
            var data = new ShoeViewModel
            {
                Shoe = _context.Shoe.ToList(),
                Registrant = _context.Registrant.ToList()
            };

            return View(data);
        }



        // GET: Registrants/Create
        [Authorize(Roles = "Administrator,Manager,User")]

        public IActionResult Create()
        {
            ViewData["RaceId"] = new SelectList(_context.Race, "ID", "RaceName");
            ViewData["ShoeId"] = new SelectList(_context.Shoe, "ID", "Brand");
            return View();
        }

        // POST: Registrants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Age,Address,City,State,Zip,Email,PhoneNumber,RaceId,ShoeId")] Registrant registrant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RaceId"] = new SelectList(_context.Race, "ID", "RaceName", registrant.RaceId);
            ViewData["ShoeId"] = new SelectList(_context.Shoe, "ID", "Brand", registrant.ShoeId);
            return View(registrant);
        }

        // GET: Registrants/Edit/5
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrant = await _context.Registrant.FindAsync(id);
            if (registrant == null)
            {
                return NotFound();
            }
            ViewData["RaceId"] = new SelectList(_context.Race, "ID", "RaceName", registrant.RaceId);
            ViewData["ShoeId"] = new SelectList(_context.Shoe, "ID", "Brand", registrant.ShoeId);
            return View(registrant);
        }

        // POST: Registrants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Age,Address,City,State,Zip,Email,PhoneNumber,RaceId,ShoeId")] Registrant registrant)
        {
            if (id != registrant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrantExists(registrant.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RaceId"] = new SelectList(_context.Race, "ID", "RaceName", registrant.RaceId);
            ViewData["ShoeId"] = new SelectList(_context.Shoe, "ID", "Brand", registrant.ShoeId);
            return View(registrant);
        }

        // GET: Registrants/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrant = await _context.Registrant
                .Include(r => r.Race)
                .Include(r => r.Shoe)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registrant == null)
            {
                return NotFound();
            }

            return View(registrant);
        }

        // POST: Registrants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrant = await _context.Registrant.FindAsync(id);
            _context.Registrant.Remove(registrant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrantExists(int id)
        {
            return _context.Registrant.Any(e => e.ID == id);
        }
    }
}
