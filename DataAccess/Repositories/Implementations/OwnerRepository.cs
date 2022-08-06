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
    public class OwnerRepository : IRepository<Owner>
    {
        private static int id;

        public Owner Create(Owner entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContexts.Owners.Add(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void  Delete(Owner entity)
        {
            try
            {
                DbContexts.Owners.Remove(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            } 
        }

        public Owner Get(Predicate<Owner> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContexts.Owners[0];
                }
                else
                {
                    return DbContexts.Owners.Find(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Owner> GetAll(Predicate<Owner> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContexts.Owners;

                }
                else
                {
                    return DbContexts.Owners.FindAll(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                 return null;
            }  
        }

        public void Update(Owner entity)
        {
            try
            {
                var Owner = DbContexts.Owners.Find(o => o.Id == entity.Id);
                if (Owner != null)
                    Owner.Name = entity.Name;
                    Owner.Surname = entity.Surname;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    
    }
}
