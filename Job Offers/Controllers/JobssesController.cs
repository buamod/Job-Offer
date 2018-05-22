using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Job_Offers.Models;
using WebApplication5.Models;

namespace Job_Offers.Controllers
{
    public class JobssesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobsses
        public ActionResult Index()
        {
            var jobsses = db.Jobsses.Include(j => j.Category);
            return View(jobsses.ToList());
        }

        // GET: Jobsses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobss jobss = db.Jobsses.Find(id);
            if (jobss == null)
            {
                return HttpNotFound();
            }
            return View(jobss);
        }

        // GET: Jobsses/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName");
            return View();
        }

        // POST: Jobsses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Jobss jobss, HttpPostedFileBase upload)
        {
            string path;
            if (ModelState.IsValid && upload == null)
            {
                
                path = "No_Image_Available.jpg";

                
                jobss.JobImage = path;
                db.Jobsses.Add(jobss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid && upload != null)
            {
                path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                jobss.JobImage = upload.FileName;
                db.Jobsses.Add(jobss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", jobss.CategoryID);
            return View(jobss);
        }

        // GET: Jobsses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobss jobss = db.Jobsses.Find(id);
            if (jobss == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", jobss.CategoryID);
            return View(jobss);
        }

        // POST: Jobsses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Jobss jobss, HttpPostedFileBase upload)
        {
            string path;
            if (ModelState.IsValid && upload == null)
            {

                path = "No_Image_Available.jpg";


                jobss.JobImage = path;
                db.Entry(jobss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid && upload != null)
            {
                path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                jobss.JobImage = upload.FileName;
                db.Entry(jobss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", jobss.CategoryID);
            return View(jobss);
            
        }

        // GET: Jobsses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobss jobss = db.Jobsses.Find(id);
            if (jobss == null)
            {
                return HttpNotFound();
            }
            return View(jobss);
        }

        // POST: Jobsses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jobss jobss = db.Jobsses.Find(id);
            db.Jobsses.Remove(jobss);
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
