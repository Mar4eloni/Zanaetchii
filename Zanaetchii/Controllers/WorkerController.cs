using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zanaetchii.Contracts.Interfaces;
using Zanaetchii.Models.ViewModels;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IWorkerRepo _context;
        private readonly IMapper _mapper;

        public WorkerController(IWorkerRepo context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: WorkerController
        public ActionResult Index()
        {
            var Workers = _context.GetAll();
            IEnumerable<WorkerViewModel> MappedWorkers = _mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerViewModel>>(Workers);
            return View(MappedWorkers);
        }

        // GET: WorkerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkerController/Create
        public ActionResult Create()
        {
            var model = new WorkerViewModel();
            return View(model);
        }

        // POST: WorkerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var NewWorker = _mapper.Map<Worker>(model);
                    _context.Add(NewWorker);

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkerController/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _context.Get(id);
            if (entity == null)
            {
                return View();
            }
            var model = _mapper.Map<WorkerViewModel>(entity);
            return View(model);
        }

        // POST: WorkerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkerViewModel collection)
        {
            try
            {
                var mappedModel = _mapper.Map<Worker>(collection);
                var result = _context.Update(mappedModel);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkerController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: WorkerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
