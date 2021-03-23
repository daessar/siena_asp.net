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
                Aprendiz = collection["aprendiz"],
                Egresado = collection["egresado"],
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
            RegistroUsuario us = new RegistroUsuario();
            Usuario usr = us.Recuperar(id);
            return View(usr);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            RegistroUsuario us = new RegistroUsuario();
            Usuario usr = new Usuario
            {
                Id = id,
                Documento = int.Parse(collection["documento"].ToString()),
                TipoDocumento = collection["tipodocumento"].ToString(),
                Nombre = collection["nombre"].ToString(),
                Celular = int.Parse(collection["celular"].ToString()),
                Email = collection["email"].ToString(),
                Genero = collection["genero"].ToString(),
                Aprendiz = collection["aprendiz"].ToString(),
                Egresado = collection["egresado"].ToString(),
                AreaFormacion = collection["areaformacion"].ToString(),
                FechaEgresado = DateTime.Parse(collection["fechaegresado"].ToString()),
                Direccion = collection["direccion"].ToString(),
                Barrio = collection["barrio"].ToString(),
                Ciudad = collection["ciudad"].ToString(),
                Departamento = collection["departamento"].ToString(),
            };
            us.Modificar(usr);
            return RedirectToAction("Details");


        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            RegistroUsuario us = new RegistroUsuario();
            Usuario usr = us.Recuperar(id);
            return View(usr);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            RegistroUsuario us = new RegistroUsuario();
            us.Borrar(id);
            return RedirectToAction("Details");
        }
    }
}
