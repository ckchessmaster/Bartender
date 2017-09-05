using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ckingdon.Bartender.Data_Access;
using ckingdon.Bartender.Models;

namespace ckingdon.Bartender.Controllers
{
    public class DrinksController : Controller
    {
        private BartenderContext db = new BartenderContext();

        // GET: Drinks
        public ActionResult Index()
        {
            return View(db.Drinks.ToList());
        }

        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }

            Random rnd = new Random();
            int pin = rnd.Next(1, 9999);

            while(db.Orders.FirstOrDefault(o => o.CustomerPIN == pin) != null)
            {
                pin = rnd.Next(1, 9999);
            }

            ViewBag.PIN = pin;
            return View(drink);
        }//end Order

        [HttpPost]
        public ActionResult Order(string Name, string PIN, int DrinkID)
        {
            Drink drink = db.Drinks.Find(DrinkID);
            if (drink == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = new Order();
            order.Drink = drink;
            order.Customer = Name;
            order.CustomerPIN = int.Parse(PIN);
            order.isBeingMade = false;
            order.isReadyForPickup = false;

            db.Orders.Add(order);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ConfirmOrder()
        {
            return RedirectToAction("Index", "Home");
        }//end ConfirmOrder

        [HttpPost]
        public ActionResult EditOrder(string UserPIN)
        {
            return RedirectToAction("EditOrder", "Orders", 1);
        }

        public ActionResult Manage()
        {
            return View(db.Drinks.ToList());
        }

        // GET: Drinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // GET: Drinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrinkID,Name,Image")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                db.Drinks.Add(drink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drink);
        }

        // GET: Drinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrinkID,Name,Image")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drink);
        }

        // GET: Drinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drink drink = db.Drinks.Find(id);
            db.Drinks.Remove(drink);
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
