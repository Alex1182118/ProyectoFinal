using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoED1.Models;
using ProyectoED1.Repositories;

namespace ProyectoED1.Controllers
{
    public class TablaController : Controller
    {
        ITablaRepository _tablaRepository;
        public TablaController(ITablaRepository tablaRepository)
        {
            _tablaRepository = tablaRepository;
        }
        // GET: Tabla
        public ActionResult Columnas(string resultado)
        {
            List<DefColumna> columnas = new List<DefColumna>();
            columnas = _tablaRepository.VerColumnas();
            return View(columnas);

        }
        public ActionResult Insert(string resultado)
        {
            List<DefColumna> columnas = new List<DefColumna>();
            columnas = _tablaRepository.VerColumnas();
            return View(columnas);
        }
        public ActionResult ColumnasSelect(string resultado)
        {
            List<DefColumna> columnas = new List<DefColumna>();
            columnas = _tablaRepository.VerColumnas();
            return View(columnas);
        }
        public ActionResult Tablas()
        {
            List<DefTabla> tablas = new List<DefTabla>();
            tablas = _tablaRepository.VerTablas();
            return View(tablas);
        }

        // GET: Tabla/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tabla/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tabla/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Columnas));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tabla/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tabla/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Columnas));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tabla/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tabla/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Columnas));
            }
            catch
            {
                return View();
            }
        }
    }
}