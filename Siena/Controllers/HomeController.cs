using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Siena.Models;

namespace Siena.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details()
        {
            RegistroUsuario us = new RegistroUsuario();
            return View(us.RecupearTodos());
            
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            RegistroUsuario us = new RegistroUsuario();
            Usuario usr = new Usuario
            {
                Documento = int.Parse(collection["documento"]),
                TipoDocumento = collection["tipodocumento"],
                Nombre = collection["nombre"],
                Celular = int.Parse(collection["celular"]),
                Email = collection["email"],
                Genero = collection["genero"],
                //Aprendiz = Boolean.Parse(collection["aprendiz"]),
                //Egresado = Boolean.Parse(collection["egresado"]),
                AreaFormacion = collection["areaFormacion"],
                FechaEgresado = DateTime.Parse(collection["fechaegresado"].ToString()),
                Direccion = collection["direccion"],
                Barrio = collection["barrio"],
                Ciudad = collection["ciudad"],
                Departamento = collection["departamento"]

            };
            us.Insertar(usr);

            return RedirectToAction("Details");

        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
