using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoScrap.Data;
using AutoScrap.Models;


namespace AutoScrap.Controllers
{
    public class PartsController : Controller
    {
        private readonly AutoScrapContext _context;

        public PartsController(AutoScrapContext context)
        {
            _context = context;
        }

        // GET: Parts
        public async Task<IActionResult> Index(string partSystem, string searchString)
        {
              //return _context.Part != null ? 
              //            View(await _context.Part.ToListAsync()) :
              //            Problem("Entity set 'AutoScrapContext.Part'  is null.");
              if(_context.Part==null)
              {
                return Problem("Entity set 'AutoScrapContext.Part'  is null.");
              }

            //Use LINQ to get list of systems
            IQueryable<string> systemQuery = from p in _context.Part
                                             orderby p.System
                                             select p.System;

            var parts = from p in _context.Part
                        select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                parts = parts.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(partSystem))
            {
                parts = parts.Where(x => x.System == partSystem);
            }

            var partSystemVM = new PartSystemViewModel
            {
                Systems = new SelectList(await systemQuery.Distinct().ToListAsync()),
                Parts = await parts.ToListAsync()
            };

            return View(partSystemVM);



        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Part == null)
            {
                return NotFound();
            }

            var part = await _context.Part
                .FirstOrDefaultAsync(m => m.Part_Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // GET: Parts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Part_Id,Title,ManufactureeDate,Condition,System,Price")] Part part)
        {
            if (ModelState.IsValid)
            {
                _context.Add(part);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(part);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Part == null)
            {
                return NotFound();
            }

            var part = await _context.Part.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Part_Id,Title,ManufactureeDate,Condition,System,Price")] Part part)
        {
            if (id != part.Part_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(part);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartExists(part.Part_Id))
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
            return View(part);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Part == null)
            {
                return NotFound();
            }

            var part = await _context.Part
                .FirstOrDefaultAsync(m => m.Part_Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Part == null)
            {
                return Problem("Entity set 'AutoScrapContext.Part'  is null.");
            }
            var part = await _context.Part.FindAsync(id);
            if (part != null)
            {
                _context.Part.Remove(part);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartExists(int id)
        {
          return (_context.Part?.Any(e => e.Part_Id == id)).GetValueOrDefault();
        }
    }
}
