using ProdMVC.DAL;
using ProdMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProdMVCDBContext db;

        public ProductController()
        {
            db = new ProdMVCDBContext();
        }

        public ActionResult Index()
        {
            var list = new List<Product>();
            list = db.Products.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var Categories = db.Categories.ToList();
            var selectList = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = selectList;

            var Companies = db.Companies.ToList();
            var selectList1 = new SelectList(Companies, "Id", "PersianName");
            ViewBag.Companies = selectList1;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product Entity)
        {
            if(!ModelState.IsValid)
            {

            }

            if(db.Products.Any(x => x.Id == Entity.Id))
            {
                ViewBag.Message = "این محصول پیشتر ثبت گردیده است";
                return View(Entity);
            }

            db.Products.Add(Entity);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var Entity = db.Products.Find(Id);
            
            if(Entity == null)
            {
                ViewBag.Message = "محصول مورد نطر یافت نشد!";
                return RedirectToAction("Index");
            }

            var Categories = db.Categories.ToList();
            var selectlist = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = selectlist;

            var Companies = db.Companies.ToList();
            var selectList1 = new SelectList(Companies, "Id", "PersianName");
            ViewBag.Companies = selectList1;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Product Entity)
        {
            var Categories = db.Categories.ToList();
            var selectlist = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = selectlist;

            var Companies = db.Companies.ToList();
            var selectList1 = new SelectList(Companies, "Id", "PersianName");
            ViewBag.Companies = selectList1;

            db.Entry(Entity).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var Entity = db.Products.FirstOrDefault(x => x.Id == Id);

            if(Entity == null)
            {
                ViewBag.Message = "موردی جهت حذف انتخاب نشده است!";
                return RedirectToAction("Index");
            }

            db.Products.Remove(Entity);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}