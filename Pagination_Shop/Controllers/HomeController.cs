using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Pagination_Shop.Controllers
{
    public class HomeController : Controller
    {
        int countPerPage = 5;

        GoodRepository repo;
        ManufacturerRepository manufRepo;
        CategoryRepository catRepo;
        IEnumerable<Manufacturer> Manufs;
        IEnumerable<Category> Cats;
        public HomeController()
        {
            repo = new GoodRepository();

            manufRepo = new ManufacturerRepository();
            catRepo = new CategoryRepository();
            
            Manufs = manufRepo.GetAll().ToList();
            Cats = catRepo.GetAll().ToList();

            ViewBag.Manufs = Manufs;
            ViewBag.Cats = Cats;
        }
        // GET: Home
        public ActionResult Index(int id = 1)
        {
            Session["LastPage"] = id;

            int countOfPages = (int)Math.Ceiling((double)(repo.GetAll().ToList().Count) / countPerPage);
            ViewBag.Goods = repo.GetAll()
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
        public ActionResult NewGood(int id = 0)
        {
            return View(repo.Get(id));
        }
        [HttpPost]
        public ActionResult NewGood(Good newGood)
        {
            newGood.ManyfacturerId = int.Parse(Request.Form["Manufs"]);
            newGood.CategoryId = int.Parse(Request.Form["Cats"]);
            repo.CreateOrUpdate(newGood);
            repo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ShowCategory()
        {
            return RedirectToAction("Index", "Category");
        }
        public ActionResult ShowManufacturer()
        {
            return RedirectToAction("Index", "Manufacturer");
        }
    }
}
