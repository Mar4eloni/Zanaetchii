using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zanaetchii.Contracts.Interfaces;
using Zanaetchii.Models.ViewModels;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Controllers
{
    public class WorkFieldsController : Controller
    {
        //private readonly MyDbContext _context;
        private readonly IWorkFieldsRepo _context;
        private readonly IMapper _mapper;

        public WorkFieldsController(IWorkFieldsRepo context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: WorkFields
        public IActionResult Index()
        {
            //var AllWorkFields = _context.GetAll().ToList();
            var AllWorkFieldsMapped = _mapper.Map<IEnumerable<WorkField>, IEnumerable<WorkFieldViewModel>>(_context.GetAll());//AllWorkFields.Select(_mapper.Map<WorkField, WorkFieldViewModel>);

            return View(AllWorkFieldsMapped);
        }

        // GET: WorkFields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var workField = await _context.WorkeFields
            //    .FirstOrDefaultAsync(m => m.WorkFieldId == id);
            //if (workField == null)
            //{
            //    return NotFound();
            //}

            return View();//(workField);
        }

        // GET: WorkFields/Create
        public IActionResult Create()
        {
            var model = new WorkFieldViewModel();
            return View(model);
        }

        // POST: WorkFields/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkFieldId,Name")] WorkFieldViewModel workField)
        {
            if (ModelState.IsValid)
            {
                var NewWorkField = _mapper.Map<WorkField>(workField);
                _context.Add(NewWorkField);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return View(workField);
            return View();
        }

        // GET: WorkFields/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var test = _context.Get((int)id);
            var workField = _mapper.Map<WorkFieldViewModel>(test);
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
        public IActionResult Edit(int id, [Bind("WorkFieldId,Name")] WorkFieldViewModel workField)
        {
            if (id != workField.WorkFieldId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(workField);
                    _context.Update(_mapper.Map<WorkField>(workField));
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
            //_context.Remove(_context.Get(id));
            var workField = _mapper.Map<WorkFieldViewModel>(_context.Find(x => x.WorkFieldId == id));

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
            var workField = _context.Get(id);
            _context.Remove(workField);//await _context.WorkeFields.FindAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool WorkFieldExists(int id)
        {
            //return _context.WorkeFields.Any(e => e.WorkFieldId == id);
            return false;
        }
    }
}
