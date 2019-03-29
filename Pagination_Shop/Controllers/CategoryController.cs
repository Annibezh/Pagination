using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Pagination_Shop.Controllers
{
    public class CategoryController : Controller
    {
        int countPerPage = 5;
        CategoryRepository repo;
        public CategoryController()
        {
            repo = new CategoryRepository();
        }
        // GET: Category
        public ActionResult Index(int id = 1)
        {
            Session["LastPage"] = id;

            int countOfPages = (int)Math.Ceiling((double)(repo.GetAll().ToList().Count) / countPerPage);
            ViewBag.Categories = repo.GetAll()
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
        public ActionResult NewCategory(int id = 0)
        {
            return View(repo.Get(id));
        }
        [HttpPost]
        public ActionResult NewCategory(Category newCategory)
        {
            repo.CreateOrUpdate(newCategory);
            repo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ShowGood()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ShowManufacturer()
        {
            return RedirectToAction("Index", "Manufacturer");
        }
    }

}