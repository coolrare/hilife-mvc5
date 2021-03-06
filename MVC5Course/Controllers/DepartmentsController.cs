using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MVC5Course.Models;
using Omu.ValueInjecter;

namespace MVC5Course.Controllers
{
    public class DepartmentsController : MemberBaseController
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();

        // GET: Departments
        //[OutputCache(Location = OutputCacheLocation.Client, Duration = 60)]
        public ActionResult Index()
        {
            var department = db.Department.Include(d => d.Person);
            return View(department.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            //ViewData["CourseList"] = db.Course.Where(p => p.DepartmentID == id.Value);

            return View(department);
        }

        [ChildActionOnly]
        public ActionResult DepartmentCourseList(int departmentId)
        {
            return PartialView(db.Course.Where(p => p.DepartmentID == departmentId));
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "LastName");
            return View();
        }

        // POST: Departments/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,Name,Budget,StartDate,InstructorID,RowVersion")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "LastName", department.InstructorID);
            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "LastName", department.InstructorID);

            //var dept = (new DepartmentEdit()).InjectFrom(department);
            var dept = Mapper.Map<DepartmentEdit>(department);

            return View(dept);
        }

        // POST: Departments/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        //[ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentEdit data)
        {
            var department = db.Department.Find(data.DepartmentID);

            if (ModelState.IsValid)
            {
                department.Name = data.Name;
                department.Budget = data.Budget;
                department.InstructorID = data.InstructorID;
                department.StartDate = data.StartDate;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "LastName", department.InstructorID);

            var dept = Mapper.Map<DepartmentEdit>(department);

            return View(dept);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Department.Find(id);
            db.Department.Remove(department);
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
