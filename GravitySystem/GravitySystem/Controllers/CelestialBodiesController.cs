using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GravitySystem.Models;

namespace GravitySystem.Controllers
{
    public class CelestialBodiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CelestialBodiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CelestialBodies
        public async Task<IActionResult> Index()
        {
            return View(await _context.CelestialBodies.ToListAsync());
        }

        // GET: CelestialBodies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celestialBody = await _context.CelestialBodies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celestialBody == null)
            {
                return NotFound();
            }

            return View(celestialBody);
        }

        // GET: CelestialBodies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CelestialBodies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mass,PositionX,PositionY,VelocityX,VelocityY,Type,IsActive")] CelestialBody celestialBody)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celestialBody);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(celestialBody);
        }

        // GET: CelestialBodies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celestialBody = await _context.CelestialBodies.FindAsync(id);
            if (celestialBody == null)
            {
                return NotFound();
            }
            return View(celestialBody);
        }

        // POST: CelestialBodies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Mass,PositionX,PositionY,VelocityX,VelocityY,Type,IsActive")] CelestialBody celestialBody)
        {
            if (id != celestialBody.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celestialBody);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelestialBodyExists(celestialBody.Id))
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
            return View(celestialBody);
        }

        // GET: CelestialBodies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celestialBody = await _context.CelestialBodies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celestialBody == null)
            {
                return NotFound();
            }

            return View(celestialBody);
        }

        // POST: CelestialBodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celestialBody = await _context.CelestialBodies.FindAsync(id);
            if (celestialBody != null)
            {
                _context.CelestialBodies.Remove(celestialBody);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelestialBodyExists(int id)
        {
            return _context.CelestialBodies.Any(e => e.Id == id);
        }
    }
}