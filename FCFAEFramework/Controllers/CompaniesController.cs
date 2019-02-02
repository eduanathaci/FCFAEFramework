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
    public class CompaniesController : Controller
    {
        private FinnovateEF db = new FinnovateEF();

        // GET: Companies
        public ActionResult Index()
        {
            if (Session["Company"]!=null)
            {
                return View(db.Companies.ToList());
            }
            return RedirectToAction("Login", "Companies");
           
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Password,BusinessNo,FiscalNo,PhoneNo,Address/*,IsActive,InsertDate*/")] Company company)
        {
            if (ModelState.IsValid)
            {
                if (!db.Companies.Any(c=>c.Email==company.Email))
                {
                    db.Companies.Add(company);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Exists = "A Company with this email already exists.";
                    return View();
                }
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Password,BusinessNo,FiscalNo,PhoneNo,Address,IsActive,InsertDate")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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

        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(Company company)
        {
            
            if (ModelState.IsValid)
            {
                var f = db.Companies.Any(a => a.Email.Equals(company.Email) && a.Password.Equals(company.Password));
                if (f!=false)
                {
                    List<Company> cObj = db.Companies.Where(c => c.Email == company.Email && c.Password == company.Password).ToList();
                    Session["Company"] = cObj;
                    return RedirectToAction("Index","Services");

                }
                return View();
            }
            return View();

        }

        [HttpGet]
        public ActionResult LogOut()
        {
            if (Session["Company"]!=null)
            {
                Session["Company"] = null;

            }

            return RedirectToAction("Login");

        }
    }
}
