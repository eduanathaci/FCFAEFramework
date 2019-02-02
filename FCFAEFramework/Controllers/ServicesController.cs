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
    public class ServicesController : Controller
    {
        private FinnovateEF db = new FinnovateEF();
        

        // GET: Services
        public ActionResult Index()
        {
            if (Session["Company"]!=null)
            {
                List<Company> c = (List<Company>)Session["Company"];
                Service service = db.Services.Find(c[0].ID);
                int companyID = c[0].ID;
                //var services = db.Services.Include(s => s.Company);

                List<Service> services = db.Services.Where(s => s.CompanyID == companyID).ToList();
               
                return View(services);
            }
            return RedirectToAction("Login","Companies");
           
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Banner,Description,StartDate,EndDate,IsActive,CompanyID")] Service service,FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();


                //Loop-a per me i shti ne dictionary krejt vlerat per krejt inputat ne forme
                for (int i = 6; i < collection.Count; i++)
                {
                    string[] nameOfItem = Request.Form[collection.AllKeys[i]].Split(',');
                   
                    if (i>6)
                    {
                        int x;
                        for ( x = 0; x < nameOfItem.Length; x++)
                        {
                            if (nameOfItem[x]=="on")
                            {
                                nameOfItem[x + 1] = null;
                            }
                        }
                        nameOfItem = nameOfItem.Where(y => y != null).ToArray();
                       
                    }
                    dictionary.Add(collection.AllKeys[i], nameOfItem);
                }



                //Loop-a per me i nda vlerat per consentat e vecante.
                for (int a = 0; a < dictionary["Purpose"].Length; a++)
                {
                    Dictionary<string, string> pairs = new Dictionary<string, string>();
                    foreach (KeyValuePair<string,string[]> item in dictionary)
                    {
                        string myKey = item.Key;
                        pairs.Add(item.Key,dictionary[item.Key.ToString()].GetValue(a).ToString());
                    }

                    foreach (KeyValuePair<string,string> item in pairs.ToList())
                    {
                        if (item.Value=="false")
                        {
                            pairs.Remove(item.Key);
                            
                        }
                    }
                }
               
               
                List<Company> c = (List<Company>)Session["Company"];

                service.CompanyID = c[0].ID;
                db.Services.Add(service);
                db.SaveChanges();

                int serviceID = service.ID;
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", service.CompanyID);



            //Kemi mbete qysh me marr id sipas emrit te te dhenes ne databaze.
            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", service.CompanyID);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Banner,Description,StartDate,EndDate,IsActive,CompanyID")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", service.CompanyID);
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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
