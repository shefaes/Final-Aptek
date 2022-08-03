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
    public class DrugRepository : IRepository<Drug>
    {
        public Drug Create(Drug entity)
        {
            try
            {
                DbContexts.Drugs.Add(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Drug entity)
        {
            try
            {
                DbContexts.Drugs.Remove(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Drug Get(Predicate<Drug> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContexts.Drugs[0];
                }
                else
                {
                    return DbContexts.Drugs.Find(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return null;
        }


        public List<Drug> GetAll(Predicate<Drug> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContexts.Drugs;

                }
                else
                {
                    return DbContexts.Drugs.FindAll(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return null;
        }

        public void Update(Drug entity)
        {
            try
            {
                var Drug = DbContexts.Drugs.Find(d => d.Id == entity.Id);
                if (Drug != null)
                {
                    Drug.Name = entity.Name;
                    Drug.Count = entity.Count;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
