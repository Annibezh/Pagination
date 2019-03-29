using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryRepository
    {
        ShopModel db = new ShopModel();
        public void CreateOrUpdate(Category c)
        {
            db.Categories.AddOrUpdate(c);
        }
        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }
        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }
        public void Remove(Category c)
        {
            db.Entry(c).State = EntityState.Deleted;
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
