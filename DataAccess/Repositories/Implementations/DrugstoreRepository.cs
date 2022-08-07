using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class DrugstoreRepository : IRepository<Drugstore>
    {
        private static int id;

        public Drugstore Create(Drugstore entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContexts.Drugstores.Add(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Drugstore entity)
        {
            try
            {
                DbContexts.Drugstores.Remove(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Drugstore Get(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContexts.Drugstores[0];
                }
                else
                {
                    return DbContexts.Drugstores.Find(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return null;
        }

        public List<Drugstore> GetAll(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContexts.Drugstores;

                }
                else
                {
                    return DbContexts.Drugstores.FindAll(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Update(Drugstore entity)
        {
            try
            {
                var Drugstore = DbContexts.Drugstores.Find(d => d.Id == entity.Id);
                if (Drugstore != null)
                {
                    Drugstore.Name = entity.Name;
                    Drugstore.ContactNumber = entity.ContactNumber;
                    Drugstore.Id = Drugstore.Id;
                    Drugstore.Address = entity.Address;
                    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
  
    }
}
