using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiEspeciales.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiEspeciales.Controllers
{
    public class ArlController : Controller
    {
        private readonly PruebaContext _context;

        public ArlController(PruebaContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Arl.ToList());
        }

        // GET: ArlController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arl = _context.Arl
                .FirstOrDefault(m => m.idarl == id);
            if (arl == null)
            {
                return NotFound();
            }

            return View(arl);
        }

        // GET: ArlController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArlController/Create
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

        // GET: ArlController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArlController/Edit/5
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

        // GET: ArlController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArlController/Delete/5
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
