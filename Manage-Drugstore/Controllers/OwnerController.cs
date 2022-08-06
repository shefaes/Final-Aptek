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
    public class OwnerController
    {
        private OwnerRepository _ownerRepository;
        

        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
            
        }
        public void CreateOwner()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner name:");
            string name = Console.ReadLine();

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner surname:");
            string surname = Console.ReadLine();

        }
        public void DeleteOwner()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter Owner name");
            string name = Console.ReadLine();
            var owner = _ownerRepository.Get(o => o.Name.ToLower() == name.ToLower());
            if (owner != null)
            {
                _ownerRepository.Delete(owner);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, $"{name} is deleted");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
            }
        }

        public void GetAllOwners()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "All owners list");

                foreach (var owner in owners)
                {
                   
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, $"Id - {owner.Id}, fullname - {owner.Name}{owner.Surname}");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }
        public void UpdateOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                foreach (var owner in owners)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Id {owner.Id}, Fullname{owner.Name}{owner.Surname}");
                Id: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner Id");
                    string id = Console.ReadLine();
                    int ownerId;
                    var result = int.TryParse(id, out ownerId);
                    if (result)
                    {
                        var dbOwner = _ownerRepository.Get(o => o.Id == ownerId);
                        if (dbOwner != null)
                        {
                            string oldName = dbOwner.Name;
                            string oldSurname = dbOwner.Surname;
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner new name:");
                            string newName = Console.ReadLine();
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter owner new surname:");
                            string newSurname = Console.ReadLine();
                            if (result)
                            {
                                var updatedOwner = new Owner
                                {
                                    Id = dbOwner.Id,
                                    Name = newName,
                                    Surname = newSurname,
                                };
                                _ownerRepository.Update(updatedOwner);
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{oldName} {oldSurname}is updated to{updatedOwner.Name}{updatedOwner.Surname}");
                            }
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter id in correct format");
                        goto Id;
                    }
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There are any owner");
            }
        }
    }
}   

