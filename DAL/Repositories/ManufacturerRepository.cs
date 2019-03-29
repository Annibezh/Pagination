using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManufacturerRepository
    {
        ShopModel db = new ShopModel();
        public void CreateOrUpdate(Manufacturer m)
        {
            db.Manufacturers.AddOrUpdate(m);
        }
        public Manufacturer Get(int id)
        {
            return db.Manufacturers.Find(id);
        }
        public IEnumerable<Manufacturer> GetAll()
        {
            return db.Manufacturers;
        }
        public void Remove(Manufacturer m)
        {
            db.Entry(m).State = EntityState.Deleted;
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
