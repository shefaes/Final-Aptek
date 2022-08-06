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
    public class AdminRepository : IRepository<Admin>
    {
        private static int id;

        public Admin Create(Admin entity)

        {
            id++;
            entity.Id = id;
            try
            {
                DbContexts.Admins.Add(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Admin entity)
        {
            try
            {
                DbContexts.Admins.Remove(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }

        }

        public void Update(Admin entity)
        {
            try
            {
                var admin = DbContexts.Admins.Find(a => a.Id == entity.Id);
                if (admin != null)
                {
                    admin.Username = entity.Username;
                    admin.Password= entity.Password;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Admin Get (Predicate<Admin> filter = null)
        {
            try
            {
                if (filter != null)
                {
                   return DbContexts.Admins.Find(filter);
                }
                else
                {
                   return DbContexts.Admins[0];
                }
            }
            catch (Exception)
            {

                throw;
                return null;
            }
        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContexts.Admins;
                }
                else
                {
                    return DbContexts.Admins.FindAll(filter);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }
    }
}
