using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Controllers
{
    public class WorkFieldsController : Controller
    {
        private readonly MyDbContext _context;

        public WorkFieldsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: WorkFields
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkeFields.ToListAsync());
        }

        // GET: WorkFields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workField = await _context.WorkeFields
                .FirstOrDefaultAsync(m => m.WorkFieldId == id);
            if (workField == null)
            {
                return NotFound();
            }

            return View(workField);
        }

        // GET: WorkFields/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkFields/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkFieldId,Name")] WorkField workField)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workField);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workField);
        }

        // GET: WorkFields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workField = await _context.WorkeFields.FindAsync(id);
            if (workField == null)
            {
                return NotFound();
            }
            return View(workField);
        }

        // POST: WorkFields/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkFieldId,Name")] WorkField workField)
        {
            if (id != workField.WorkFieldId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workField);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkFieldExists(workField.WorkFieldId))
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
            return View(workField);
        }

        // GET: WorkFields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workField = await _context.WorkeFields
                .FirstOrDefaultAsync(m => m.WorkFieldId == id);
            if (workField == null)
            {
                return NotFound();
            }

            return View(workField);
        }

        // POST: WorkFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workField = await _context.WorkeFields.FindAsync(id);
            _context.WorkeFields.Remove(workField);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkFieldExists(int id)
        {
            return _context.WorkeFields.Any(e => e.WorkFieldId == id);
        }
    }
}
