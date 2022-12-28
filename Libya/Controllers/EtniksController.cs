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
    [AllowAnonymous]
    public class EtniksController : Controller
    {
        private etnikEntities db = new etnikEntities();

        
        public ActionResult Index()
        {
            return View(db.Etniks.ToList());
        }

        // GET: Etniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etnik etnik = db.Etniks.Find(id);
            if (etnik == null)
            {
                return HttpNotFound();
            }
            return View(etnik);
        }

        // GET: Etniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etniks/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,etnikKok,eysehiri,ehakkinda")] Etnik etnik)
        {
            if (ModelState.IsValid)
            {
                db.Etniks.Add(etnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etnik);
        }

        // GET: Etniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etnik etnik = db.Etniks.Find(id);
            if (etnik == null)
            {
                return HttpNotFound();
            }
            return View(etnik);
        }

        // POST: Etniks/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,etnikKok,eysehiri,ehakkinda")] Etnik etnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etnik);
        }

        // GET: Etniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etnik etnik = db.Etniks.Find(id);
            if (etnik == null)
            {
                return HttpNotFound();
            }
            return View(etnik);
        }

        // POST: Etniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etnik etnik = db.Etniks.Find(id);
            db.Etniks.Remove(etnik);
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
