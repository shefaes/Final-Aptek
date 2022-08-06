using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Helpers;

namespace DataAccess.Contexts
{
    static class DbContexts
    {

        static DbContexts()
        {
            Drugstores = new List<Drugstore>();
            Druggists = new List<Druggist>();
            Drugs = new List<Drug>();
            Admins = new List<Admin>();

            string password = "1988";
            var hashedPassword = PasswordHasher.Encrypt(password);
            Admin admin = new Admin("admin", hashedPassword);
            Admins.Add(admin);

        }
        public static List<Admin> Admins { get; set; }

        public static List<Drugstore> Drugstores { get; set; }

        public static List<Druggist> Druggists { get; set; }

        public static List<Drug> Drugs { get; set; }
        public static List<Owner> Owners { get; set; }
    }
}
