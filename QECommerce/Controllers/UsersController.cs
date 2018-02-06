using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QECommerce.Models;
using QECommerce.Classes;

namespace QECommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private QECommerceContext db = new QECommerceContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Cities).Include(u => u.Company).Include(u => u.Departaments);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(0), "CityId", "Name");
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name");
            return View();
        }

        // POST: Users/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    UserHelper.CreateUserASP(user.UserName, "User");

                    if (user.PhotoFile != null)
                    {
                        var pic = string.Empty;
                        var folder = "~/Content/Users";
                        var file = string.Format("{0}.jpg", user.UserId);

                        var response = FilesHelper.UploadPhoto(user.PhotoFile, folder, file);
                        if (response)
                        {
                            pic = string.Format("{0}/{1}", folder, file);
                            user.Photo = pic;
                            db.Entry(user).State = EntityState.Modified;
                            db.SaveChanges();
                        }

                    }

                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, responseSave.Message);
            }

            ViewBag.CityId = new SelectList(CombosHelper.GetCities(user.DepartamentsId), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name", user.DepartamentsId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(user.DepartamentsId), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name", user.DepartamentsId);
            return View(user);
        }

        // POST: Users/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {

                if (user.PhotoFile != null)
                {

                    var pic = string.Empty;
                    var folder = "~/Content/Users";
                    var file = string.Format("{0}.jpg", user.UserId);

                    var response = FilesHelper.UploadPhoto(user.PhotoFile, folder, file);
                    if (response)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        user.Photo = pic;

                    }

                }

                var db2 = new QECommerceContext();
                var currentUser = db2.Users.Find(user.UserId);
                if (currentUser.UserName != user.UserName)
                {
                    UserHelper.UpdateUserName(currentUser.UserName, user.UserName);
                }
                db2.Dispose();

                db.Entry(user).State = EntityState.Modified;

                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, responseSave.Message);
            }

            ViewBag.CityId = new SelectList(CombosHelper.GetCities(user.DepartamentsId), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartamentsId = new SelectList(CombosHelper.GetDepartaments(), "DepartamentsId", "Name", user.DepartamentsId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            var responseSave = DBHelper.SaveChanges(db);
            if (responseSave.Succeeded)
            {
                UserHelper.DeleteUser(user.UserName, "User");
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, responseSave.Message);
            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //CONTROLE DE LIST VIEW EM CASCATA
        //public JsonResult GetCities(int departmentId)
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    var cities = db.Cities.Where(m => m.DepartamentsId == departmentId);
        //    return Json(cities);
        //}
    }
}
