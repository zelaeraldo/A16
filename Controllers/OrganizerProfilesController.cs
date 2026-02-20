using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace A16.Controllers
{
    public class OrganizerProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizerProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizerProfiles
        public async Task<IActionResult> Index()
        {
              return _context.OrganizerProfiles != null ? 
                          View(await _context.OrganizerProfiles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.OrganizerProfiles'  is null.");
        }

        // GET: OrganizerProfiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.OrganizerProfiles == null)
            {
                return NotFound();
            }

            var organizerProfile = await _context.OrganizerProfiles
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (organizerProfile == null)
            {
                return NotFound();
            }

            return View(organizerProfile);
        }

        // GET: OrganizerProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizerProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,OrganizationName,ContactEmail,Website,Bio")] OrganizerProfile organizerProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizerProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizerProfile);
        }

        // GET: OrganizerProfiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.OrganizerProfiles == null)
            {
                return NotFound();
            }

            var organizerProfile = await _context.OrganizerProfiles.FindAsync(id);
            if (organizerProfile == null)
            {
                return NotFound();
            }
            return View(organizerProfile);
        }

        // POST: OrganizerProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,OrganizationName,ContactEmail,Website,Bio")] OrganizerProfile organizerProfile)
        {
            if (id != organizerProfile.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizerProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizerProfileExists(organizerProfile.UserId))
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
            return View(organizerProfile);
        }

        // GET: OrganizerProfiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.OrganizerProfiles == null)
            {
                return NotFound();
            }

            var organizerProfile = await _context.OrganizerProfiles
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (organizerProfile == null)
            {
                return NotFound();
            }

            return View(organizerProfile);
        }

        // POST: OrganizerProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.OrganizerProfiles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrganizerProfiles'  is null.");
            }
            var organizerProfile = await _context.OrganizerProfiles.FindAsync(id);
            if (organizerProfile != null)
            {
                _context.OrganizerProfiles.Remove(organizerProfile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizerProfileExists(string id)
        {
          return (_context.OrganizerProfiles?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
