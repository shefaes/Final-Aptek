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
    class DruggistRepository : IRepository<Druggist>
    {
        public Druggist Create(Druggist entity)
        {
            try
            {
                DbContexts.Druggists.Add(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Druggist entity)
        {
            try
            {
                DbContexts.Druggists.Remove(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }

        }

        public List<Druggist> GetAll(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContexts.Druggists;

                }
                else
                {
                    return DbContexts.Druggists.FindAll(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return null;
        }

        public Druggist Get(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContexts.Druggists[0];
                }
                else
                {
                    return DbContexts.Druggists.Find(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return null;
        }

        public void Update(Druggist entity)
        {
            try
            {
               var Druggist = DbContexts.Druggists.Find(d => d.Id == entity.Id);
               if (Druggist != null)
               {
                 Druggist.Name = entity.Name;
                 Druggist.Surname = entity.Surname;
               }
            }
             catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }

        }

        public void Create(Druggist druggist)
        {
            throw new NotImplementedException();
        }
    }
}
