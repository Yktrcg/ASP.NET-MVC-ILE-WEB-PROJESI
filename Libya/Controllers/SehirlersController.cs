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
    [Authorize(Users ="y@y.com")]
    public class SehirlersController : Controller
    {
        private sehirlerEntities db = new sehirlerEntities();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Sehirlers.ToList());
        }

        // GET: Sehirlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehirler sehirler = db.Sehirlers.Find(id);
            if (sehirler == null)
            {
                return HttpNotFound();
            }
            return View(sehirler);
        }

        // GET: Sehirlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sehirlers/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,sıra,telefonKodu,sehirAdı,nufus,yuzolcum,bölge")] Sehirler sehirler)
        {
            if (ModelState.IsValid)
            {
                db.Sehirlers.Add(sehirler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sehirler);
        }

        // GET: Sehirlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehirler sehirler = db.Sehirlers.Find(id);
            if (sehirler == null)
            {
                return HttpNotFound();
            }
            return View(sehirler);
        }

        // POST: Sehirlers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,sıra,telefonKodu,sehirAdı,nufus,yuzolcum,bölge")] Sehirler sehirler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sehirler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sehirler);
        }

        // GET: Sehirlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehirler sehirler = db.Sehirlers.Find(id);
            if (sehirler == null)
            {
                return HttpNotFound();
            }
            return View(sehirler);
        }

        // POST: Sehirlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sehirler sehirler = db.Sehirlers.Find(id);
            db.Sehirlers.Remove(sehirler);
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
