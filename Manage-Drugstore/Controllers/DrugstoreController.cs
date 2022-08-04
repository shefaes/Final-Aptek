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
    public class DrugstoreController
    {
        private DrugstoreRepository _drugstoreRepository;
        private OwnerRepository _ownerRepository;

        public DrugstoreController()
        {
            _drugstoreRepository = new DrugstoreRepository();
            _ownerRepository = new OwnerRepository();
        }

        public void CreateDrugstore()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count>0)
            {
              ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore name:");
              string name = Console.ReadLine();

              ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore address:");
              string address = Console.ReadLine();

              ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore contactnumber:");
              string contactnumber = Console.ReadLine();
              AllOwnersList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "All owners:");
                foreach ( Owner in owners)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Id{Owner.Id}, owner name{Owner.Name}");
                }
                 Id: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner Id:");
                string ownerId = Console.ReadLine();
                int Id;
                bool result = int.TryParse(ownerId, out Id);

                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner!=null)
                    {
                        var drugstore = new Drugstore
                        {
                            Name = name,
                            Address = address,
                            ContactNumber = contactnumber,
                        };
                          var createdDrugstore = _drugstoreRepository.Create(Drugstore);
                          ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{createdDrugstore.Name} is successfully created with name:");
                    } 
                     else
                     {
                         ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter drugstore address:");
                     }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, Enter drugstore Contactnumber:");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, Enter drugstore Id:");
                goto Id;
            }
         }   

        public void UpdateDrugstore()
        {

        }

        public void DeleteDrugstore()
        {

        }

        public void GetAllDrugstores()
        {

        }

        public void GetAllDrugstoresByOwner()
        {

        }

        public void Sale()
        {

        }

    }
}
