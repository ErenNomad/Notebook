using NotDefteri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notebook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var notes = (List<Note>)Session["Notes"];

            if (notes == null)
            {
                notes = new List<Note>();
                Session["Notes"] = notes;
            }

            ViewBag.Notes = notes;

            return View();
        }

        // Yeni not ekleme
        [HttpPost]
        public ActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                var notes = (List<Note>)Session["Notes"];
                notes.Add(note);
                Session["Notes"] = notes;
                return RedirectToAction("Index");
            }
            else
            {
                return View(note);
            }

        }
    }
}