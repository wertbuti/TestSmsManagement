using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestSmsManagement.Data;
using TestSmsManagement.Models;

namespace TestSmsManagement.Controllers
{
    public class SmsController : Controller
    {
        private TestSmsManagementContext db = new TestSmsManagementContext();

        // GET: Sms
        public ActionResult Index()
        {
            return View(db.Sms.ToList());
        }

        // GET: Sms/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sms sms = db.Sms.Find(id);
            if (sms == null)
            {
                return HttpNotFound();
            }
            return View(sms);
        }

        // GET: Sms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SmsBody")] Sms sms)
        {
            //ApiCaller apiCaller = new ApiCaller("https://localhost:44332");
            //await apiCaller.PostAsync("/api/basesms/basesendsms", sms);

            ApiCaller apiCaller = new ApiCaller("https://localhost:44374");
            await apiCaller.PostAsync("/api/sms/sendsms", sms);


            //if (ModelState.IsValid)
            //{
            //    db.Sms.Add(sms);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(sms);
        }

        // GET: Sms/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sms sms = db.Sms.Find(id);
            if (sms == null)
            {
                return HttpNotFound();
            }
            return View(sms);
        }

        // POST: Sms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SmsBody")] Sms sms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sms);
        }

        // GET: Sms/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sms sms = db.Sms.Find(id);
            if (sms == null)
            {
                return HttpNotFound();
            }
            return View(sms);
        }

        // POST: Sms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Sms sms = db.Sms.Find(id);
            db.Sms.Remove(sms);
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
