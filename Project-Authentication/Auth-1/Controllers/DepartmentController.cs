using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auth_1;

namespace Auth_1.Controllers
{

 
    public class DepartmentController : Controller
    {
        private AuthEntities db = new AuthEntities();

        // GET: Department
        [Authorize(Roles ="User, Admin")]
        public ActionResult Index()
        {
            return View(db.tbl_Department.ToList());
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            if (tbl_Department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Department);
        }

        // GET: Department/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepId,Name,HOD")] tbl_Department tbl_Department)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Department.Add(tbl_Department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            if (tbl_Department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepId,Name,HOD")] tbl_Department tbl_Department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Department);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            if (tbl_Department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            db.tbl_Department.Remove(tbl_Department);
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
