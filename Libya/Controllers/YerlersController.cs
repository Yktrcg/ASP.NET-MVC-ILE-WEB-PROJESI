using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libya.Models;

namespace Libya1.Controllers
{

    [Authorize(Users = "y@y.com")]
    public class YerlersController : Controller
    {
        private yerlerEntities db = new yerlerEntities();

        // GET: Yerlers
        public ActionResult Index()
        {
            return View(db.Yerlers.ToList());
        }

        // GET: Yerlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yerler yerler = db.Yerlers.Find(id);
            if (yerler == null)
            {
                return HttpNotFound();
            }
            return View(yerler);
        }

        // GET: Yerlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yerlers/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,yerAdı,sehiri,hakkinda")] Yerler yerler)
        {
            if (ModelState.IsValid)
            {
                db.Yerlers.Add(yerler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yerler);
        }

        // GET: Yerlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yerler yerler = db.Yerlers.Find(id);
            if (yerler == null)
            {
                return HttpNotFound();
            }
            return View(yerler);
        }

        // POST: Yerlers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,yerAdı,sehiri,hakkinda")] Yerler yerler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yerler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yerler);
        }

        // GET: Yerlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yerler yerler = db.Yerlers.Find(id);
            if (yerler == null)
            {
                return HttpNotFound();
            }
            return View(yerler);
        }

        // POST: Yerlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yerler yerler = db.Yerlers.Find(id);
            db.Yerlers.Remove(yerler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
