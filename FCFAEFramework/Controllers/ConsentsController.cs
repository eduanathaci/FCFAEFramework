using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FCFAEFramework.Models;

namespace FCFAEFramework.Controllers
{
    public class ConsentsController : Controller
    {
        private FinnovateEF db = new FinnovateEF();

        // GET: Consents
        public ActionResult Index()
        {
            return View(db.Consents.ToList());
        }

        // GET: Consents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consent consent = db.Consents.Find(id);
            if (consent == null)
            {
                return HttpNotFound();
            }
            return View(consent);
        }

        // GET: Consents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,InsertDate")] Consent consent, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
              
                Data data = new Data();
                for (int i = 2; i < collection.Count; i++)
                {
                    string nameOFData = collection[i].ToString();
                    var query1 = (from m in db.Datas where m.NameOfData == nameOFData select m.ID);

                    db.Consents.Add(consent);
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }

            return View(consent);
        }

        // GET: Consents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consent consent = db.Consents.Find(id);
            if (consent == null)
            {
                return HttpNotFound();
            }
            return View(consent);
        }

        // POST: Consents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,InsertDate")] Consent consent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consent).State = EntityState.Modified;
                db.SaveChanges();

               
                return RedirectToAction("Index");
            }
            return View(consent);
        }

        // GET: Consents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consent consent = db.Consents.Find(id);
            if (consent == null)
            {
                return HttpNotFound();
            }
            return View(consent);
        }

        // POST: Consents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consent consent = db.Consents.Find(id);
            db.Consents.Remove(consent);
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


        [HttpPost]
        public void Add()
        {
            TempData["Add"] = 1;

        }
    }
}
