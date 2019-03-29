using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Pagination_Shop.Controllers
{
    public class ManufacturerController : Controller
    {
        int countPerPage = 5;
        ManufacturerRepository repo;
        public ManufacturerController()
        {
            repo = new ManufacturerRepository();
        }
        // GET: Manufacturer
        public ActionResult Index(int id = 1)
        {
            Session["LastPage"] = id;

            int countOfPages = (int)Math.Ceiling((double)(repo.GetAll().ToList().Count) / countPerPage);
            ViewBag.Manufacturers = repo.GetAll()
                                .ToList()
                                .Skip((id - 1) * countPerPage)
                                .Take(countPerPage);
            ViewBag.CountOfPages = countOfPages;
            return View();
        }
        public ActionResult Delete(int id)
        {
            repo.Remove(repo.Get(id));
            repo.SaveChanges();

            int redirectPage = (int)Session["LastPage"];

            return RedirectToAction("Index", new { id = redirectPage });
        }
        public ActionResult NewManufacturer(int id = 0)
        {
            return View(repo.Get(id));
        }
        [HttpPost]
        public ActionResult NewManufacturer(Manufacturer newManufacturer)
        {
            repo.CreateOrUpdate(newManufacturer);
            repo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ShowGood()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ShowCategory()
        {
            return RedirectToAction("Index", "Category");
        }
    }
}