using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Drugstore.Controllers
{
    public class AdminController
    {
        private AdminRepository _adminRepository;

        public AdminController()
        {
            _adminRepository = new AdminRepository();
        }
        public Admin Authenticate()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "Enter admin username:");
            string username = Console.ReadLine();

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "Enter admin password:");
            string password = Console.ReadLine();

            var admin = _adminRepository.Get(a => a.Username.ToLower() == username.ToLower()
                                             && PasswordHasher.Decrypt(a.Password) == password);
            return admin;

        }
    }
}
