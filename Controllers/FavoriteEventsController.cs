using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace A16.Controllers
{
    public class FavoriteEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoriteEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FavoriteEvents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FavoriteEvents.Include(f => f.Event);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FavoriteEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FavoriteEvents == null)
            {
                return NotFound();
            }

            var favoriteEvent = await _context.FavoriteEvents
                .Include(f => f.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteEvent == null)
            {
                return NotFound();
            }

            return View(favoriteEvent);
        }

        // GET: FavoriteEvents/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name");
            return View();
        }

        // POST: FavoriteEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,EventId,FavoritedAt")] FavoriteEvent favoriteEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name", favoriteEvent.EventId);
            return View(favoriteEvent);
        }

        // GET: FavoriteEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FavoriteEvents == null)
            {
                return NotFound();
            }

            var favoriteEvent = await _context.FavoriteEvents.FindAsync(id);
            if (favoriteEvent == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name", favoriteEvent.EventId);
            return View(favoriteEvent);
        }

        // POST: FavoriteEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,EventId,FavoritedAt")] FavoriteEvent favoriteEvent)
        {
            if (id != favoriteEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteEventExists(favoriteEvent.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name", favoriteEvent.EventId);
            return View(favoriteEvent);
        }

        // GET: FavoriteEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FavoriteEvents == null)
            {
                return NotFound();
            }

            var favoriteEvent = await _context.FavoriteEvents
                .Include(f => f.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteEvent == null)
            {
                return NotFound();
            }

            return View(favoriteEvent);
        }

        // POST: FavoriteEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FavoriteEvents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FavoriteEvents'  is null.");
            }
            var favoriteEvent = await _context.FavoriteEvents.FindAsync(id);
            if (favoriteEvent != null)
            {
                _context.FavoriteEvents.Remove(favoriteEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteEventExists(int id)
        {
          return (_context.FavoriteEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
