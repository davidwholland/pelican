using Pelican.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Pelican.Controllers
{
    public class UserController : BaseController
    {
        private PelicanContext db = new PelicanContext();

        // GET: /User/
        public ActionResult Index()
        {
            //TODO: should this return a 404?
            return View(db.Persons.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = db.Persons.Find(id);

            if (person == null)
            {
                return HttpNotFound();
            }
            
            return View(person);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId, UserId, FirstName, LastName, Email, WorkPhone, MobilePhone")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();

                //TODO: needs to redirect somewhere else
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = db.Persons.Find(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PersonId, UserId, FirstName, LastName, Email, WorkPhone, MobilePhone")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                
                //TODO: redirect somewhere else
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = db.Persons.Find(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();

            // TODO: redirect to somewhere else
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