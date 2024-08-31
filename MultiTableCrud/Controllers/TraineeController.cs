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
    public class TraineeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trainee
        [Authorize(Roles = "Admin")]

        public ActionResult Index()
        {
            return View(db.Trainees.ToList());
        }

        // GET: Trainee/Details/5
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        public JsonResult ExamDetails(int id)
        {
            var examInfo = db.ExamDetails.Where(o => o.TraineeID == id).AsEnumerable().Select(o => new { id = o.TraineeID, examName = o.ExamName, examDate = o.ExamDate.ToString("dd-MM-yyyy"), resultdate = o.ResultPublishDate.ToString("dd-MM-yyyy"), totalMarks = o.TotalMarks });
            return Json(examInfo, JsonRequestBehavior.AllowGet);
        }

        // GET: Trainee/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Manager")]

        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraineeID,Name,CoreSubject,Round,TSP,Email,DateOfBirth")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainee);
        }

        // GET: Trainee/Edit/5

        [Authorize(Roles = "HR" , Users = "mounir@gmail.com")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: Trainee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraineeID,Name,CoreSubject,Round,TSP,Email,DateOfBirth")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }

        // GET: Trainee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: Trainee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainee trainee = db.Trainees.Find(id);
            db.Trainees.Remove(trainee);
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
