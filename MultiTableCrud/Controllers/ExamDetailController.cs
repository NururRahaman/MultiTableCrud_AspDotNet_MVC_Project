using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MultiTableCrud.Models;

namespace MultiTableCrud.Controllers
{
    public class ExamDetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExamDetail
        public ActionResult Index()
        {
            var examDetails = db.ExamDetails.Include(e => e.Trainee);
            return View(examDetails.ToList());
        }

        // GET: ExamDetail/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ExamDetail examDetail = db.ExamDetails.Find(id);
        //    if (examDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(examDetail);
        //}

        // GET: ExamDetail/Create
        public ActionResult Create()
        {
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "Name");
            return View();
        }

        // POST: ExamDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamDetailID,ExamName,ExamDate,ResultPublishDate,ExternalMarks,EvidenceMarks,TraineeID")] ExamDetail examDetail)
        {
            if (ModelState.IsValid)
            {
                db.ExamDetails.Add(examDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "Name", examDetail.TraineeID);
            return View(examDetail);
        }

        // GET: ExamDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "Name", examDetail.TraineeID);
            return View(examDetail);
        }

        // POST: ExamDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamDetailID,ExamName,ExamDate,ResultPublishDate,ExternalMarks,EvidenceMarks,TraineeID")] ExamDetail examDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "Name", examDetail.TraineeID);
            return View(examDetail);
        }

        // GET: ExamDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            return View(examDetail);
        }

        // POST: ExamDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamDetail examDetail = db.ExamDetails.Find(id);
            db.ExamDetails.Remove(examDetail);
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
