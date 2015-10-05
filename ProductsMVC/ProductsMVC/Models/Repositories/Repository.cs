using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace ProductsMVC.Models.Repositories
{
    public class Repository<T> where T : class
    {
          //<T> står för typen jag letar efter... .

            //private ProductDb context = null;

        private ProductDb context = new ProductDb();


            protected DbSet<T> DbSet { get; set; }


            public Repository()
            {
                //context = new ProductDb();
                DbSet = context.Set<T>();
            }


            public Repository(ProductDb context)
            {
                this.context = context;
            }


            public List<T> GetAll()
            {
                return DbSet.ToList();

            }

            public T GetId(int? id)
            {
                return DbSet.Find(id);
            }


          

            public void Add(T entity)
            {
                DbSet.Add(entity);
            }


            public void Edit(T entity)
            {
               DbSet.AddOrUpdate(entity);
            }

            public void Delete(T entity)
            {
                DbSet.Remove(entity);
            }

            public void SaveChanges()
            {
                context.SaveChanges();
            }
        }
    }
