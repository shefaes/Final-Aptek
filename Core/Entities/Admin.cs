using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Admin : IEntity
    {
        public int Id { get; set; }

        public string Username1 { get; set; }

        public string Password1 { get; set; }

        public Admin(string username1, string password1)
        {
            Username1 = username1;
            Password1 = password1;
        }
        public string Username2 { get; set; }
        public string Password2 { get; set; }
  
    }
 }
