using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.ViewModels;
using X.PagedList;

namespace MVC5Course.Controllers
{
    public class CoursesController : MemberBaseController
    {
        CourseRepository repo;
        DepartmentRepository deptRepo;

        public CoursesController()
        {
            repo = RepositoryHelper.GetCourseRepository();
            deptRepo = RepositoryHelper.GetDepartmentRepository(repo.UnitOfWork);

            //db.Database.Log = (msg) =>
            //{
            //    Debug.WriteLine(msg);
            //};
        }

        // GET: Courses
        public ActionResult Index(int? Department, int PageNo = 1)
        {
            ViewData["Department"] = new SelectList(
                items: deptRepo.All(),
                dataValueField: "DepartmentId",
                dataTextField: "Name");

            repo.查詢一個非常複雜的課程資料();

            var course = repo.All(true).OrderBy(p => p.CourseID).AsQueryable();

            course = course.Include(c => c.Department);

            if (Department.HasValue)
            {
                course = course.Where(p => p.DepartmentID == Department);
            }

            return View(course.ToPagedList(PageNo, 3));
        }

        [HttpPost]
        public ActionResult Index(CourseBatchUpdate[] data)
        {
            //data[0].CourseID
            //data[0].Credits
            //data[0].OpenDate

            //data[1].CourseID

            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var one = repo.Find(item.CourseID);

                    if (item.IsConfirmDelete)
                    {
                        repo.Delete(one);
                    }
                    else
                    {
                        one.Credits = item.Credits;
                        one.OpenDate = item.OpenDate;
                    }
                }

                //repo.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            var course = repo.All();
            course = course.Include(c => c.Department);
            return View(course.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Course course = db.Course.Find(id);
            Course course = repo.Find(id.Value);
            if (course == null)
            {
                return View("NotFound");
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {

            ViewBag.DepartmentID = new SelectList(deptRepo.All(), "DepartmentID", "Name");
            return View();
        }

        // POST: Courses/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "CourseID,Title,Credits,DepartmentID,OpenDate")] Course course)
        {
            if (ModelState.IsValid)
            {
                //db.Course.Add(course);
                //db.SaveChanges();
                repo.Add(course);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(deptRepo.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repo.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(deptRepo.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID,OpenDate,IsEnabled")] Course item)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(course).State = EntityState.Modified;
                //db.SaveChanges();

                Course course = repo.All().FirstOrDefault(p => p.CourseID == item.CourseID);

                course.Title = item.Title;
                course.Credits = item.Credits;
                course.OpenDate = item.OpenDate;
                course.IsEnabled = item.IsEnabled;

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(deptRepo.All(), "DepartmentID", "Name", item.DepartmentID);
            return View(item);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repo.Find(id.Value);
            if (course == null || course.Credits >= 3)
            {
                // LOG: id, User.Identity.Name, Request.UserHostAddress
                return View("NotFound");
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = repo.Find(id);

            if (course == null || course.Credits >= 3)
            {
                return HttpNotFound();
            }

            repo.Delete(course);


            //var list = db.Course.Where(p => p.Title.Contains("JavaScript"));
            //db.Course.RemoveRange(list);

            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
