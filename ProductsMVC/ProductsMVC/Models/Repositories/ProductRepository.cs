using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductsMVC.Models.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public List<Product> GetByName(String name)
        {
            return DbSet.Where(p => p.Name.Contains(name)).ToList();
        }
    }
}