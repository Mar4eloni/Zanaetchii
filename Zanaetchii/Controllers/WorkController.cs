using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Zanaetchii.Contracts.Interfaces;
using Zanaetchii.Models.ViewModels;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Controllers
{
    public class WorkController : Controller
    {

        private readonly IWorkRepo _context;
        private readonly IMapper _mapper;

        public WorkController(IWorkRepo context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: WorkController
        public ActionResult Index()
        {
            var AllJobs = _context.GetAllJobs();
            if (AllJobs != null)
            {
                var AllJobsMapped = AllJobs.Select(_mapper.Map<Work, WorkViewModel>);

                return View(AllJobsMapped);
            }
            return View();
        }

        // GET: WorkController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: WorkController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: WorkController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: WorkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkController/Delete/5
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
