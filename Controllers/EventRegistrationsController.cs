using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace A16.Controllers
{
    public class EventRegistrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventRegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventRegistrations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventRegistrations.Include(e => e.Event).Include(e => e.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventRegistrations == null)
            {
                return NotFound();
            }

            var eventRegistration = await _context.EventRegistrations
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventRegistration == null)
            {
                return NotFound();
            }

            return View(eventRegistration);
        }

        // GET: EventRegistrations/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: EventRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventId,UserId,RegistrationDate,IsConfirmed")] EventRegistration eventRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name", eventRegistration.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", eventRegistration.UserId);
            return View(eventRegistration);
        }

        // GET: EventRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventRegistrations == null)
            {
                return NotFound();
            }

            var eventRegistration = await _context.EventRegistrations.FindAsync(id);
            if (eventRegistration == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name", eventRegistration.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", eventRegistration.UserId);
            return View(eventRegistration);
        }

        // POST: EventRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventId,UserId,RegistrationDate,IsConfirmed")] EventRegistration eventRegistration)
        {
            if (id != eventRegistration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventRegistrationExists(eventRegistration.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name", eventRegistration.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", eventRegistration.UserId);
            return View(eventRegistration);
        }

        // GET: EventRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventRegistrations == null)
            {
                return NotFound();
            }

            var eventRegistration = await _context.EventRegistrations
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventRegistration == null)
            {
                return NotFound();
            }

            return View(eventRegistration);
        }

        // POST: EventRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventRegistrations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EventRegistrations'  is null.");
            }
            var eventRegistration = await _context.EventRegistrations.FindAsync(id);
            if (eventRegistration != null)
            {
                _context.EventRegistrations.Remove(eventRegistration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventRegistrationExists(int id)
        {
          return (_context.EventRegistrations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
