using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormularioHelp.Models;
using FormularioHelp.Validaciones;

namespace FormularioHelp.Controllers
{
    public class RespuestasController : Controller
    {
        private Mapeo db = new Mapeo();

        // GET: Respuestas
        public ActionResult Index()
        {
            var lista = db.Respuestas.ToList();
            return View(lista);
        }

        // GET: Respuestas/Create
        public ActionResult Create()
        {
            return View();
        }

        // Método para validar si el usuario ya respondió antes
        private bool RespuestasYaExisten(int idUsuario)
        {
            return db.Respuestas.Any(r => r.Id == idUsuario);
        }

        // POST: Respuestas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RespuestasMV modelo)
        {
            var validador = new Respuestas();

            if (!ModelState.IsValid)
                return View(modelo);

           

            // Crear nueva respuesta y guardar
            var nuevaRespuesta = new Respuestas
            {
                Id = modelo.Id,
                Q1 = modelo.Q1,
                Q2 = modelo.Q2,
                Q3 = modelo.Q3,
                Q4 = modelo.Q4,
                Q5 = modelo.Q5,
                Total = modelo.Q1 + modelo.Q2 + modelo.Q3 + modelo.Q4 + modelo.Q5,
                Fecha = DateTime.Now
            };

            db.Respuestas.Add(nuevaRespuesta);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Respuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var respuesta = db.Respuestas.Find(id);
            if (respuesta == null)
                return HttpNotFound();

            return View(respuesta);
        }

        // GET: Respuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var respuesta = db.Respuestas.Find(id);
            if (respuesta == null)
                return HttpNotFound();

            return View(respuesta);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var respuesta = db.Respuestas.Find(id);
            if (respuesta != null)
            {
                db.Respuestas.Remove(respuesta);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}