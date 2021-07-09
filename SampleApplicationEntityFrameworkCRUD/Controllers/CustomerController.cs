using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleApplicationEntityFrameworkCRUD.Models;

namespace SampleApplicationEntityFrameworkCRUD.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (EntityFrameworkCRUDEntities entityFrameworkCRUDEntities = new EntityFrameworkCRUDEntities())
            {
                return View(entityFrameworkCRUDEntities.Customers.ToList());
            }

        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (EntityFrameworkCRUDEntities entityFrameworkCRUDEntities = new EntityFrameworkCRUDEntities())
            {
                return View(entityFrameworkCRUDEntities.Customers.Where(cust => cust.Id == id).FirstOrDefault());
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                using (EntityFrameworkCRUDEntities entityFrameworkCRUDEntities = new EntityFrameworkCRUDEntities())
                {
                    entityFrameworkCRUDEntities.Customers.Add(customer);
                    entityFrameworkCRUDEntities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (EntityFrameworkCRUDEntities entityFrameworkCRUDEntities = new EntityFrameworkCRUDEntities())
            {
                return View(entityFrameworkCRUDEntities.Customers.Where(cust => cust.Id == id).FirstOrDefault());
            }

        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                using (EntityFrameworkCRUDEntities entityFrameworkCRUDEntities = new EntityFrameworkCRUDEntities())
                {
                    entityFrameworkCRUDEntities.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    entityFrameworkCRUDEntities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (EntityFrameworkCRUDEntities entityFrameworkCRUDEntities = new EntityFrameworkCRUDEntities())
            {
                return View(entityFrameworkCRUDEntities.Customers.Where(cust => cust.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (EntityFrameworkCRUDEntities entityFrameworkCRUDEntities = new EntityFrameworkCRUDEntities())
                {
                    Customer customer = entityFrameworkCRUDEntities.Customers.Where(x => x.Id == id).FirstOrDefault();
                    entityFrameworkCRUDEntities.Customers.Remove(customer);
                    entityFrameworkCRUDEntities.SaveChanges();
                }
                    
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
